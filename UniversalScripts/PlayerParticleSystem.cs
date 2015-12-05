using UnityEngine;
using System.Collections;

public class PlayerParticleSystem : MonoBehaviour {


    [SerializeField]
    PlayerController thePlayerScript;

    [SerializeField]
    PlayerHealth thePlayerStatus;

    [SerializeField]
    GameObject theParticles;

    GameObject theCloneOfParticles;


	// Use this for initialization
	void Start () 
    {
        theCloneOfParticles = (GameObject)Instantiate(theParticles, thePlayerScript.GetPlayerPosition(), theParticles.transform.rotation);
        theCloneOfParticles.transform.position = thePlayerScript.GetPlayerPosition();
	}
	
	// Update is called once per frame
	void LateUpdate () 
    {
        if (theCloneOfParticles == null && !thePlayerStatus.GetIsPlayerDead())
        {
            theCloneOfParticles = (GameObject)Instantiate(theParticles, thePlayerScript.GetPlayerPosition(), theParticles.transform.rotation);
        }

        //if player is alive, particles will follow the player
        if (!thePlayerStatus.GetIsPlayerDead())
        {
            theCloneOfParticles.transform.position = thePlayerScript.GetPlayerPosition();
        }
        else if (thePlayerStatus.GetIsPlayerDead())
        {
            Destroy(theCloneOfParticles, 0.1f);
        }
	}
}
