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


    void GoBlack()
    {

    }

    void GoUnblack()
    {

    }
}
