using UnityEngine;
using System.Collections;

public class BounceOff : MonoBehaviour {

    void OnCollisionEnter(Collision obj)
    {
        //Debug.Log("A CUBE HAS LONDED ON ME");
        obj.gameObject.GetComponent<Rigidbody>().velocity = Vector3.up * 100f; // 100 - gives the cubes a good noticeable bounce
        // but the bounce is also not too much.
    }

}
