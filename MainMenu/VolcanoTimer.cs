using UnityEngine;
using System.Collections;

public class VolcanoTimer : MonoBehaviour {

    [SerializeField]
    GameObject[] theVolcanos = new GameObject[4];


	// Use this for initialization
	void Start () 
    {
        InvokeRepeating("VolcanoErupter", 7f, 12f);
	}

    void VolcanoErupter()
    {
        int randomNumber = Random.Range(0, 4);
        theVolcanos[randomNumber].GetComponentInChildren<VolcanoEruptionTrigger>().EruptVolcano();
    }
	
	
}
