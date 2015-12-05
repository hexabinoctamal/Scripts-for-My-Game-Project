using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {


    [SerializeField]
    PlayerController thePlayerScript;
	//public Transform[] waypoints = new Transform[2];

	Vector3 offset;
	//Vector3 newOffset;
	Vector3 startingPosition;
	//Vector3 fastPosition;

	//float thePlayerSpeed = 150f;

	//float yCounter = 0;
	//float zCounter = 0;

	// Use this for initialization
	void Start () 
	{

		startingPosition = new Vector3(thePlayerScript.GetPlayerPosition().x,
                                    thePlayerScript.GetPlayerPosition().y + 8f,
                                    thePlayerScript.GetPlayerPosition().z - 18f);
		//fastPosition = new Vector3(startingPosition.x, startingPosition.y + 5f, startingPosition.z - 10f);

		transform.position = startingPosition;
		transform.rotation = Quaternion.Euler(8f, 0f, 0f);
        offset = transform.position - thePlayerScript.GetPlayerPosition(); //distance btwn the thePlayer and camera

	}
	
	// LateUpdate is called once per frame - generally used for camera rendering
	/*
	 * trying to figure out how ot make the camera move back when going a certain speed 
	 * but it isn't working out lol
	void LateUpdate () 
	{
		//transform.position = thePlayer.transform.position + offset;

		//fastPosition = new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z - 15f);

		if(thePlayer.gameObject.GetComponent<Rigidbody>().velocity.z >= thePlayerSpeed)
		{

			if(yCounter <= 15f && zCounter <= 20f)
			{
				yCounter+= 0.025f;
				zCounter+= 0.05f;

				print (yCounter + " " + zCounter);
			}

			fastPosition = new Vector3(thePlayer.transform.position.x, thePlayer.transform.position.y + yCounter + 5f, thePlayer.transform.position.z - zCounter - 10f);
			transform.position = fastPosition;


			if(yCounter <= 2f && zCounter <= 4f)
			{
				yCounter+= 0.025f;
				zCounter+= 0.05f;
				offset = new Vector3(offset.x, offset.y + yCounter/10, offset.z - zCounter/10);
				print (yCounter + " " + zCounter);
			}


			transform.position = thePlayer.transform.position + offset;

		}
		else
		{
			transform.position = thePlayer.transform.position + offset;
		}
	}
	*/
	

	void LateUpdate()
	{
        transform.position = thePlayerScript.GetPlayerPosition() + offset;
	}



}//CameraController
