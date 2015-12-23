using UnityEngine;
using System.Collections;

public class IntroCameraSwitchTrigger : MonoBehaviour {

    [SerializeField]
    IntroCameraSwitching cameraSwitchingScript;
    static int currentCamera = 0;
    

    void OnTriggerEnter(Collider obj)
    {
        Debug.Log(currentCamera);
        //go black
        //don't switch camera off yet
        GoBlack();
    }

    void OnTriggerExit(Collider obj)
    {
        //go unblack
        //if x camera is on, turn it off
        //if x+1 is off, turn it on
        if (obj.CompareTag("Player"))
        {
            if (currentCamera >= 1)
            {
                StartCoroutine(WaitToLoadLevel());
            }

            if (cameraSwitchingScript.theCameras[currentCamera].activeSelf)
            {
                cameraSwitchingScript.theCameras[currentCamera + 1].SetActive(true);
                cameraSwitchingScript.theCameras[currentCamera].SetActive(false);
            }

            GoUnblack();

            Debug.Log("Player left");
            currentCamera++;
        }
    }

    IEnumerator WaitToLoadLevel()
    {
        yield return new WaitForSeconds(1.65f); // 1.65 seconds is the number I found to be good when switching to the next level
        //this is because the particles the flow behind the ball take around 1.5 seconds to die out.
        //so when it hits 1.65, the particles are really small and or already gone from the scene.
        //now when the scene switches, you wont see a big particle in the screen but small/no particles.

        currentCamera = 0; // reset counter just incase we go back to the level
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    void GoBlack()
    {

    }

    void GoUnblack()
    {

    }
}
