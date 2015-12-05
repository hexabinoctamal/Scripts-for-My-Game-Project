using UnityEngine;
using System.Collections;

public class IntroCameraSwitching : MonoBehaviour {

    
    public GameObject[] theCameras = new GameObject[4]; //made public because i don't know how to set/get between scripts
    //the cameras will be switching on and off from the following order
    //top angle, left angle, right angle, and neutral view angle with having the ball rolling away
    //the camera is stationary 
    //when switching cameras, it will go black and then not black

    //int currentCamera = 0;

    void Awake()
    {
        //set all cameras off at the beginning
        for (int i = 0; i < theCameras.Length; i++)
            theCameras[i].SetActive(false);
    }

    void Start()
    {
        //set the first camera on
        theCameras[0].SetActive(true);
    }

}
