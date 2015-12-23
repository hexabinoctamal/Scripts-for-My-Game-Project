using UnityEngine;
using System.Collections;

public class CameraDropCubeMenu : MonoBehaviour {

   
    Rigidbody cameraDropCube;
    float startingPosition = 3000f;
    float distanceToGround;
    Vector3 move;

    [SerializeField]
    GameObject theUI;

    [SerializeField]
    GameMaster gm;

    

	// Use this for initialization
	void Start () 
    {
        theUI.SetActive(false);
        transform.position = new Vector3(0f, startingPosition, 0f);
        GetComponent<FadeScreen>().SetFadeSpeed(0.6f); // 0.6 because it will dramatically go out of the fade
        GetComponent<FadeScreen>().BeginFade(-1);
        cameraDropCube = GetComponent<Rigidbody>();
        cameraDropCube.velocity = Vector3.down * 500f; // 500 because it gives it a good push on startup
        Invoke("ShowUI", 6f); // 6 - every 6 seconds it will call thsi function. I chose 6 seconds because it 
        // is a good amount of pause after the cube falls down and stops bouncing. Note that this time reflects
        // on when the volcano explodes in VolcanoTimer.cs. It explodes at the 6 second mark as well on start up.

        distanceToGround = GetComponent<Collider>().bounds.extents.y;
	}

    void Update()
    {
        if (theUI.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                GetComponent<FadeScreen>().SetFadeSpeed(0.4f);
                GetComponent<FadeScreen>().BeginFade(1);   
                //gm.LoadNextLevel();
                StartCoroutine(GoingToNextLevel());
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }

    void FixedUpdate()
    { 
        //if the cube hasn't hit the floor yet
        if (!IsGrounded())
        {
            move = Vector3.down * 200f;
            // 200 is a good number to push the cube camera down once it bounces.
            // it gives a good sense that there is gravity pushing down on the camera
            // and is not really floaty.
        }
        else
            move = Vector3.zero;

        cameraDropCube.AddForce(move);
    }


    void ShowUI()
    {
        theUI.SetActive(true);
    }

    IEnumerator GoingToNextLevel()
    {
        yield return new WaitForSeconds(5f);
        gm.LoadNextLevel();
    }

    bool IsGrounded()
    {
        //1.1 because if the ball is rolling on slants, you'll still be able to control it 
        //it wont receive it as not on the ground if it is any lower
        //thus not being able to control it
        return Physics.Raycast(transform.position, Vector3.down, distanceToGround + 1.1f);
    }

}
