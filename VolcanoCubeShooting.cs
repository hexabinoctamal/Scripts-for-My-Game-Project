using UnityEngine;
using System.Collections;

public class VolcanoCubeShooting : MonoBehaviour 
{

    [SerializeField]
    GameObject enemyCubes;
    [SerializeField]
    GameObject eruptionParticles;

	// Use this for initialization
	void Start () 
    {
        GameObject particleClone = (GameObject)Instantiate(eruptionParticles, transform.position, Quaternion.identity);
        Destroy(particleClone, 5f);
        InvokeRepeating("Spawn", 0, 0.001f);
	}




    void Spawn()
    {
        //Debug.Log(transform.position);
        //Debug.Log(GetComponent<BoxCollider>().size);

        //Debug.Log(((float)Random.Range(-10, 11))/10);
        /*
        Vector3 randomSpot = new Vector3(
                            transform.position.x + Random.Range(-GetComponent<BoxCollider>().size.x, GetComponent<BoxCollider>().size.x),
                            transform.position.y,
                            transform.position.z + Random.Range(-GetComponent<BoxCollider>().size.z, GetComponent<BoxCollider>().size.z));
        */


        //GameObject clone = Instantiate(enemyCubes, randomSpot, Random.rotation) as GameObject;
        //clone.GetComponent<Rigidbody>().velocity = new Vector3(((float)Random.Range(-10, 11)) / 10, 1, ((float)Random.Range(-10, 11)) / 10) * Random.Range(50, 100);
        //clone.GetComponent<Rigidbody>().velocity = Vector3.down * down;

        GameObject clone = Instantiate(enemyCubes, transform.position, Quaternion.identity) as GameObject;
        clone.GetComponent<Rigidbody>().velocity = Vector3.up * 50f;
        Destroy(clone, 6f);
        
    }
}
