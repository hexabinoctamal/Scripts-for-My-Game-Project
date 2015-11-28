using UnityEngine;
using System.Collections;

public class CloudSpawnerMoveLeft : MonoBehaviour {

    [SerializeField]
    GameObject theClouds;


	// Use this for initialization
	void Start () 
    {
        InvokeRepeating("CloudSpawner", 0f, 2f);
        //CloudSpawner();
	}

    void CloudSpawner()
    {
        Transform boxSize = GetComponent<Transform>();

        Debug.Log(boxSize.localScale);
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

        //After typing all that garbage above, I ended up making it flexible to wherever the gameObject is...lol
        Vector3 randomSpotWithinGrid = new Vector3(transform.position.x,
                        transform.position.y + Random.Range(-boxSize.localScale.y/2, boxSize.localScale.y/2),
                        transform.position.z + Random.Range(-boxSize.localScale.z/2, boxSize.localScale.z/2));


        GameObject clone = (GameObject)Instantiate(theClouds, randomSpotWithinGrid, Quaternion.Euler(-90, 90, 0));
            
        StartCoroutine(CloudMoving(clone));
        
        Destroy(clone, 70f);
    }

    IEnumerator CloudMoving(GameObject cloud)
    {
        float randomSpeedPerCloud = Random.Range(1f, 3f);
        //Debug.Log(randomSpeedPerCloud);

        //this loop will finish roughly around 16-17 seconds when i < 1000.
        // ~34 seconds when i < 2000, ~41 at i < 2500, ~67 at i < 4000
        for (int i = 0; i < 4000 ; i++)
        {
            //Debug.Log("Looping");
            cloud.transform.position += Vector3.left * randomSpeedPerCloud;
            yield return new WaitForSeconds(0.01f);
            //performing this loop at 1/100 a second
            //pretty cool stuff

        }

        Debug.Log("done looping at " + Time.time);
        
    }
}
