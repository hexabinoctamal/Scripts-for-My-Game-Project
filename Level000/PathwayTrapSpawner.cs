using UnityEngine;
using System.Collections;

public class PathwayTrapSpawner : MonoBehaviour {

    Vector3 initialPosition;

	// Use this for initialization
	void Start () 
    {
        initialPosition = new Vector3(transform.localPosition.x, -100f, transform.localPosition.z);
        //start with its current position but lowered all the the time.
        transform.localPosition = new Vector3(transform.localPosition.x, -100f, transform.localPosition.z);
	}
    
    void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            StartCoroutine(RaisePathway());
        }
    }


    IEnumerator RaisePathway()
    {

        // moved objects closer so don't really need this anymore
        // yield return new WaitForSeconds(1f);
        Vector3 raisedPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);

        //while the object hasn't raised up
        while(transform.localPosition.y != 0f)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, raisedPosition, 600f * Time.deltaTime);
            yield return null;
            //yield return new WaitForSeconds(0.006f);
        }
        Debug.Log(transform.localPosition);
        Debug.Log("Done now lower path");
        StartCoroutine(LowerPathway());
    }

    IEnumerator LowerPathway()
    {
        yield return new WaitForSeconds(3f);

        //while object is not at the initial starting position
        while(transform.localPosition != initialPosition)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, initialPosition, 100 * Time.deltaTime);
            yield return null;
        }
    }



   
}
