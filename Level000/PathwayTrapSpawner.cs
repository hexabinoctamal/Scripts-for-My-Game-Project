using UnityEngine;
using System.Collections;

public class PathwayTrapSpawner : MonoBehaviour {

    //[SerializeField] PlayerHealth player;
    Vector3 initialPosition;
    bool objectIsMoving = false;

	// Use this for initialization
	void Start () 
    {
        initialPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 100f, transform.localPosition.z);
        //start with its current position but lowered all the the time.
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 100f, transform.localPosition.z);
	}
    

    void OnTriggerEnter(Collider obj)
    {
        //Debug.Log("Is player dead when enters trigger? " + player.GetIsPlayerDead());
        if (obj.CompareTag("Player") && !objectIsMoving)
        {
            StartCoroutine(RaisePathway());
        }
    }


    IEnumerator RaisePathway()
    {
        //to prevent the object raising inbetween times it is lowering,
        //i made this variable to prevent it from doing so.
        //so the only times it will raise back up is when it is done lowering
        //it will be switched to false at the end.
        objectIsMoving = true;

        // moved objects closer so don't really need this anymore
        // yield return new WaitForSeconds(1f);
        Vector3 raisedPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 100f, transform.localPosition.z);

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

        //here it is done and it can raise again afterwards
        objectIsMoving = false;
    }



   
}
