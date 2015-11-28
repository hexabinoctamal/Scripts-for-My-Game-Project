using UnityEngine;
using System.Collections;

public class CubeTrigger : MonoBehaviour {

    public GameObject theBlocks;
    GameObject destroyBlocks;


	void OnTriggerEnter(Collider obj)
	{
        if (obj.gameObject.CompareTag("Player"))
		{
			print ("IN");
            destroyBlocks = Instantiate(theBlocks, transform.position, Quaternion.identity) as GameObject;
		}
	}

	void OnTriggerExit(Collider obj)
	{
		if(obj.gameObject.CompareTag("Player"))
		{
			print ("GONE");
            Destroy(destroyBlocks, 2f);
            
		}

	}

}
