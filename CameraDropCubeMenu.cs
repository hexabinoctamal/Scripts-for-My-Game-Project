using UnityEngine;
using System.Collections;

public class CameraDropCubeMenu : MonoBehaviour {

   
    Rigidbody cameraDropCube;
    float startingPosition = 3000f;

	// Use this for initialization
	void Start () 
    {
        transform.position = new Vector3(0f, startingPosition, 0f);
        GetComponent<FadeScreen>().BeginFade(-1);
        cameraDropCube = GetComponent<Rigidbody>();
        cameraDropCube.velocity = Vector3.down * 1000f;
	}


	
	
}
