using UnityEngine;
using System.Collections;

public class EnemyCubes : MonoBehaviour {

	//publics
	public GameObject cube;
    public Transform cubeSpawnerBox;

    //privates
    Transform thisPos;
    
    float widthOfSpawnBox;
    float lengthOfSpawnBox;

	[SerializeField]
	float delayTime;

    [SerializeField]
    float spawnRate;

    

	// Use this for initialization
	void Start () 
	{
        thisPos = GetComponent<Transform>();
		InvokeRepeating ("Spawn", delayTime, spawnRate/500); //(the function it calls, when it will call it, rate of how many times it will call it)
        widthOfSpawnBox = cubeSpawnerBox.localScale.x/2;
        lengthOfSpawnBox = cubeSpawnerBox.localScale.z/2;
	}
	
	void Spawn () 
	{
		//Vector3 randomSpot = new Vector3 (Random.Range (-50, 50), Random.Range(10,20), Random.Range(-50,150));
        Vector3 randomSpot = new Vector3(thisPos.position.x + Random.Range(-widthOfSpawnBox, widthOfSpawnBox), 
                            thisPos.position.y + 100f,
                            thisPos.position.z + Random.Range(0 , lengthOfSpawnBox));
		//Quaternion randomAngle = Quaternion.Euler (Random.Range(0,360),0,Random.Range(0,360));

		GameObject clone = (GameObject)Instantiate (cube, randomSpot , Random.rotation);
        //clone.GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * 100f;
        clone.GetComponent<Rigidbody>().velocity = Vector3.down * 80f;
		Destroy(clone, 1.15f);
	}
}
