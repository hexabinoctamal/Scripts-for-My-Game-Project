using UnityEngine;
using System.Collections;

public class CloudSpawnerMoveLeft : MonoBehaviour {

    [SerializeField]
    GameObject theClouds;


	// Use this for initialization
	void Start () 
    {
        InvokeRepeating("CloudSpawner", 0f, 1f);
        //CloudSpawner();
	}

    void CloudSpawner()
    {
        GameObject clone = (GameObject)Instantiate(theClouds, transform.position, theClouds.GetComponent<Transform>().rotation);
            
        StartCoroutine(CloudMoving(clone));
        
        Destroy(clone, 20f);
    }

    IEnumerator CloudMoving(GameObject cloud)
    {
        float randomSpeedPerCloud = Random.Range(1f, 4f);
        //Debug.Log(randomSpeedPerCloud);

        //this loop will finish roughly around 16-17 seconds when i < 1000.
        for (int i = 0; i < 1000 ; i++)
        {
            //Debug.Log("Looping");
            cloud.transform.position += Vector3.left * 1;
            yield return new WaitForSeconds(0.01f);
            //performing this loop at 1/100 a second
            //pretty cool stuff

        }

        Debug.Log("done looping at " + Time.time);
        
    }
}
