using UnityEngine;
using System.Collections;

public class SpikeTrapTrigger : MonoBehaviour {

    [SerializeField]
    GameObject[] theSpikes = new GameObject[10];

    GameObject[] destroySpikes = new GameObject[10];

    [SerializeField]
    float dropHeight = 70f;
    [SerializeField]
    float dropSpeed = 150f;



    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            
            for (int i = 0; i < theSpikes.Length; i++)
            {
                //works fine at the moment
                destroySpikes[i] = Instantiate(theSpikes[i],
                    new Vector3(transform.position.x - transform.localScale.x/2 + (float)(i+1)*8f, 
                        transform.position.y + dropHeight, 
                        transform.position.z + transform.localScale.z/2 ),
                    Random.rotation) as GameObject;

                destroySpikes[i].GetComponentInChildren<Rigidbody>().velocity = Vector3.down * dropSpeed;
            }
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {

            for (int i = 0; i < theSpikes.Length; i++)
            {
                Destroy(destroySpikes[i], 3f);
            }
        }
    }

}
