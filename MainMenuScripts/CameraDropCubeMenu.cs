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
        GetComponent<FadeScreen>().SetFadeSpeed(0.6f);
        GetComponent<FadeScreen>().BeginFade(-1);
        cameraDropCube = GetComponent<Rigidbody>();
        cameraDropCube.velocity = Vector3.down * 500f;
        Invoke("ShowUI", 6f);

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
