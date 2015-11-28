using UnityEngine;
using System.Collections;

public class OffMapWarp : MonoBehaviour {

    [SerializeField]
    GameObject thePlayer;

    void OnTriggerEnter(Collider obj)
    {
        

        if (obj.gameObject.CompareTag("Player"))
        {
            Debug.Log("left side");
            //if on the left side, warp to right side
            if (obj.transform.position.x < 0)
            {
                Debug.Log("left side");
                thePlayer.transform.position = new Vector3(-thePlayer.transform.position.x - 5f,
                    thePlayer.transform.position.y,
                    thePlayer.transform.position.z
                    );
            }
            else if (obj.transform.position.x > 0)
            {
                Debug.Log("right side");
                thePlayer.transform.position = new Vector3(-thePlayer.transform.position.x + 5f,
                    thePlayer.transform.position.y,
                    thePlayer.transform.position.z
                    );
            }
            
        }
    
    }

}
