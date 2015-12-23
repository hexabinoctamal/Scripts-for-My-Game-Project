using UnityEngine;
using System.Collections;

public class RandomPathForBushes : MonoBehaviour {

    [SerializeField]
    private GameObject[] thePaths = new GameObject[5];

    [SerializeField]
    PlayerHealth playerStatus;

    bool setPathOnceAfterDeath = false;

	// Use this for initialization
	void Start () 
    {
        SetAllChildrenToInactive();
        SpawnRandomPath();
        StartCoroutine(CheckPlayer());
	}


    IEnumerator CheckPlayer()
    {
        /* This works by know that initially my player is not dead 
         * so the status of player is false. In order for the random path to generate once
         * after death once, I made setPathOnceAfterDeath. If player dies, I want to make sure
         * that I will set the path once and only once. So inside SpawnRandomPath(), I set it to false.
         * It then only becomes true AFTER I come back to life. When I am back to life, I can execute
         * the first if statement as needed. 
         * 
         * I think there would be an easier way to do this but I wanted to make this script independent from
         * the other ones. Meaning, I don't want other variables on other scripts that could make this easier
         * to execute. Even if it would just be a simple bool, I want to be sure this will handle itself.
         * For example, I could've made a variable bool makePathRestart in PlayerHeath.cs, so when I respawn, I just
         * have that variable do its thing. I am planning this script only to be part of one of my levels and not
         * to be reused throughout. Hopefully, when I reread this in the future, I know take note of that.
         * 
         */

        /* I initially had this in the update method but realized I can save CPU cycles by using coroutines.
         * In this case, it will only do the checks every 1 second so now it is more efficient in a way.
         * Note that this is an infinite loop, so I'll need to do some more testing on this later one.
         * Some cases might be when changing between levels.
         */
        

        while(true)
        {
            Debug.Log("checking player");
            if (!playerStatus.GetIsPlayerDead() && setPathOnceAfterDeath)
            {
                SetAllChildrenToInactive();
                SpawnRandomPath();
            }
            else if (playerStatus.GetIsPlayerDead())
            {
                setPathOnceAfterDeath = true;
            }

            yield return new WaitForSeconds(1f);
        }
    }

    //Just in case I miss setting one of them to inactive
    //this will take care of it on start up
    //should be called first
    void SetAllChildrenToInactive()
    {
        for (int i = 0; i < thePaths.Length; i++)
        {
            thePaths[i].SetActive(false);
        }

    }

    //This will be used to pick a randompath in the maze level
    void SpawnRandomPath()
    {
        int randomNumber = Random.Range(0, 5); //picks a number from 0 to 4.

        Debug.Log("Thenumber is: " + randomNumber);

        for (int i = 0; i < thePaths.Length; i++)
        {
            if (i == randomNumber)
            {
                thePaths[i].SetActive(true);
                Debug.Log("Path " + (i + 1) + " is set active");
            }
        }
        setPathOnceAfterDeath = false;
    }



	

}
