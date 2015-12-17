using UnityEngine;
using System.Collections;

public class PathwayTrapSpawner : MonoBehaviour {

    Vector3 initialPosition;

	// Use this for initialization
	void Start () 
    {
        initialPosition = new Vector3(0f, -100f, 0f);
        //start with this position initially so it can pop up later
        transform.localPosition = initialPosition;
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

        yield return new WaitForSeconds(1f);

        while(transform.localPosition != Vector3.zero)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, 300f * Time.deltaTime);
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

        while(transform.localPosition != initialPosition)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, initialPosition, 100 * Time.deltaTime);
            yield return null;
        }
    }



   
}
