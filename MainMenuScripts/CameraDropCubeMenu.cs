using UnityEngine;
using System.Collections;

public class CameraDropCubeMenu : MonoBehaviour {

   
    Rigidbody cameraDropCube;
    float startingPosition = 3000f;

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
        cameraDropCube.velocity = Vector3.down * 1000f;
        Invoke("ShowUI", 7f);
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

    void ShowUI()
    {
        theUI.SetActive(true);
    }

    IEnumerator GoingToNextLevel()
    {
        yield return new WaitForSeconds(5f);
        gm.LoadNextLevel();
    }
	
}
