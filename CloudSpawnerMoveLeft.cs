using UnityEngine;
using System.Collections;

public class CloudSpawnerMoveLeft : MonoBehaviour {

    [SerializeField]
    GameObject theClouds;

    Transform boxSize;

	// Use this for initialization
	void Start () 
    {
        boxSize = GetComponent<Transform>();
        InvokeRepeating("CloudSpawner", 0f, 4f);
        //CloudSpawner();
	}

    void CloudSpawner()
    {
        //Transform boxSize = GetComponent<Transform>();

        //Debug.Log(boxSize.localScale);
        /*
         * The values given are specific for the main menu 
         * if needed to reuse this script (or game object) for different settings,
         * these values would need to be changed to be flexible.
         * at the moment, i just hardcoded the numbers because since the camera is stationary,
         * I have it so that it is within the camera's rendering spots.
         * When I think about it, it is flexible to the position of the game object's x.position.
         * One way to do it would be to get the size of the gameObject and choose a random number between its
         * neg. value and pos. value
        */ 
        //Vector3 randomSpotWithinGrid = new Vector3(transform.position.x, Random.Range(95f, 520f), Random.Range(760f, 1120f));

        //After typing all that garbage above, I ended up making it flexible to wherever the gameObject is depending on 
        //the size of the game object...lol
        Vector3 randomSpotWithinGrid = new Vector3(transform.position.x,
                        transform.position.y + Random.Range(-boxSize.localScale.y/2, boxSize.localScale.y/2),
                        transform.position.z + Random.Range(-boxSize.localScale.z/2, boxSize.localScale.z/2));


        //GameObject clone = (GameObject)Instantiate(theClouds, randomSpotWithinGrid, Quaternion.Euler(-90, 90, 0));
            
        StartCoroutine(CloudMoving(randomSpotWithinGrid));
        
        //Destroy(clone, 70f);
    }

    IEnumerator CloudMoving(Vector3 randomSpot)
    {
        GameObject cloudClone = (GameObject)Instantiate(theClouds, randomSpot, Quaternion.Euler(-90, 90, 0));
        float randomSpeedPerCloud = Random.Range(0.3f, 1.5f);
        //Debug.Log(randomSpeedPerCloud);

        // ******************************************************************
        // ******************************************************************
        // PROBLEM WITH THIS
        // The times i have listed varies between computers
        // So even though i < 4000, the time it takes to complete varies +/-
        // therefore this isn't reliable. so redo this part
        // ******************************************************************
        // ******************************************************************
        // Update 12/17/2015
        // I updated it so now it relies on a distance constraint 
        // instead of a time constraint on when to destroy itself or reach the end.
        // It is now flexible to other computers...I think.


        while(cloudClone.transform.localPosition.x >= -1500f)
        {
            cloudClone.transform.position += Vector3.left * randomSpeedPerCloud;
            yield return new WaitForSeconds(1f / 120); //cycles at 120hz 
            // 120 because it seems smoother
        }

        Destroy(cloudClone);
        Debug.Log("done looping at " + Time.time);
        
    }
}
