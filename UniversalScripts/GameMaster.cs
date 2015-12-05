using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;

    [SerializeField]
    CameraShake camera;

	// Use this for initialization
	void Awake() 
    {
        DontDestroyOnLoad(this);
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
	}


    public void PlayerDied()
    {

    }

    public void LoadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

}
