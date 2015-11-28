using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
	GameObject deathParticles;
    bool isDead = false;
    float autoKillHeight = -1000f;
    float lenghtOfDeathTime = 5f;
    Vector3 initialPosition;

    [SerializeField]
    CameraShake camShake;

    int playerHP = 3;

	// Use this for initialization
	void Start () 
    {
        initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        //if the player is dead, run this
        if (!isDead)
        {
            //if player crashes, you die
            //if some glitch happens and you fall to the end of the earth, you die
            if (CrashedIntoWall() || transform.position.y < autoKillHeight)
            {
                YouDied();
            }
        }
	}

    void StopBall()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    bool CrashedIntoWall()
    {
        if (GetComponent<Rigidbody>().velocity.z < 0)
            return true;
        else
            return false;
    }

    void YouDied()
    {
        //create death particles and destroy in 2 seconds
        //mark that the player has died
        //go into coroutine to make the player wait 3 seconds to respawn
        GameObject clone = (GameObject)Instantiate(deathParticles, transform.position, Quaternion.identity);
        Destroy(clone, 2);
        isDead = true;
        camShake.Shake(0.3f, lenghtOfDeathTime);
        StartCoroutine(RespawnPlayer());
    }

    IEnumerator RespawnPlayer()
    {
        //after 3 seconds, the player will be marked as not dead
        //I made a StopBall() because when respawning, the velocity of the ball is not resetted
        //
        yield return new WaitForSeconds(lenghtOfDeathTime);
        isDead = false;
        StopBall(); //resets the speed from when it gets knocked back or whatever
        transform.position = initialPosition; // respawns you to the beginning
        //Application.LoadLevel(Application.loadedLevel);

    }


    void OnCollisionEnter(Collision obj)
    {
        //for non static enemies
        //if you hit an enemy and you're not dead
        if (obj.gameObject.CompareTag("Enemy") && !isDead)
        {
            if (playerHP > 0)
            {
                playerHP--;
            }
            else if (playerHP <= 0)
            {
                YouDied();
                playerHP = 3;
            }
        }//if you hit an enemy and you are not currently dead
    }


    void OnTriggerEnter(Collider obj)
    {
        //If the ball hits a static object
        if (obj.gameObject.CompareTag("Enemy") && !isDead)
        {
            if (playerHP > 0)
            {
                playerHP--;
            }
            else if (playerHP <= 0)
            {
                YouDied();
                playerHP = 3;
            }
        }
    }

    public bool GetIsPlayerDead()
    {
        return isDead;
    }
}
