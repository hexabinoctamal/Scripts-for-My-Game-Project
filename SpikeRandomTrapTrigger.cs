using UnityEngine;
using System.Collections;

public class SpikeRandomTrapTrigger : MonoBehaviour {

    [SerializeField]
    private GameObject[] theSpikes = new GameObject[10];

    GameObject[] destroySpikes = new GameObject[10];

    [SerializeField]
    float dropHeight = 70f;
    [SerializeField]
    float dropSpeed = 150f;

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            //because i am choosing a random number from 0-9
            //there's a 50% chance of having the trigger being activated
            //even numbers being 0,2,4,6,8
            //odd numbers being 1,3,5,7,9
            int randomNumber = Random.Range(0, 10);

            //if the number is even, do this
            if ((randomNumber % 2) == 0)
            {
                //Debug.Log("randomSpawn");
                for (int i = 0; i < theSpikes.Length; i++)
                {
                    

                    //values need to be recoded
                    //not flexible if I decide to change the size of the trap
                    //works fine at the moment
                    destroySpikes[i] = Instantiate(theSpikes[i],
                        new Vector3(transform.position.x - transform.localScale.x / 2 + (float)(i + 1) * 8f, transform.position.y + dropHeight, transform.position.z + transform.localScale.z / 2),
                        Random.rotation) as GameObject;
                    destroySpikes[i].GetComponentInChildren<Rigidbody>().velocity = Vector3.down * dropSpeed;
                }

                //for (int i = 0; i < theSpikes.Length; i++)
                //    destroySpikes[i].GetComponentInChildren<Rigidbody>().velocity = Vector3.down * dropSpeed;
                
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
