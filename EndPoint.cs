using UnityEngine;
using System.Collections;

public class EndPoint : MonoBehaviour {

    public GameMaster gameMaster;

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            gameMaster.LoadNextLevel();
        }
    }

}
