using UnityEngine;
using System.Collections;

public class VolcanoEruptionTrigger : MonoBehaviour {

    [SerializeField]
    GameObject cubeErupt;
    GameObject destroyCubeErupt;

    [SerializeField]
    Transform cubeEruptLocation;


    void OnTriggerEnter(Collider obj)
    {

        if(obj.CompareTag("Player"))
        {
            Debug.Log("BOOM!");
            destroyCubeErupt = Instantiate(cubeErupt, 
                cubeEruptLocation.position, 
                Quaternion.identity) as GameObject;

            Destroy(destroyCubeErupt, 1.2f);
        }

    }

    public void EruptVolcano()
    {
        destroyCubeErupt = Instantiate(cubeErupt,
                cubeEruptLocation.position,
                Quaternion.identity) as GameObject;

        Destroy(destroyCubeErupt, 1.2f);
    }



}
