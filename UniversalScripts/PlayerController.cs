using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    
	float movementSpeed = 1000f;
	Rigidbody player;
	Vector3 move;
	//Vector3 deathPosition;
	//bool isDead = false;
    //bool touchingGround = false;
    
    [SerializeField]
    PlayerHealth playerStatus;

    float horizontalMovement;
    float verticalMovement;

	float maxSpeedForward = 160;
    float maxLeftAndRight = 120;
    
    float distanceToGround;

    RigidbodyConstraints initialConstraints;

    void Awake()
    {
        initialConstraints = GetComponent<Rigidbody>().constraints;
    }

	// Use this for initialization
	void Start () 
	{
		player = GetComponent<Rigidbody>();
        distanceToGround = GetComponent<Collider>().bounds.extents.y;
    }
	
	// Update is called once per frame
	void FixedUpdate () 
	{
        //print(player.velocity);

		//if player is not dead
		if(!playerStatus.GetIsPlayerDead())
		{
            MoveBall();
		}//if not dead

        //Take this out when done
        //this is only temporary during testing
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(Application.loadedLevel - 1);
        }
	}



    void MoveBall()
    {
        //keep the ball grounded
        move.y = 0f;

        if (player.velocity.z < maxSpeedForward && player.velocity.z >= 0f)
            MoveForwardConstantly();
        else
            move.z = 0f;

        //restrict the ball from moving to the sides to a certain speed
        //can't move left or right if you're not grounded
        if (player.velocity.x < maxLeftAndRight && 
            player.velocity.x > -maxLeftAndRight && 
            IsGrounded())

            MoveLeftRight();
        else
            move.x = 0f;

        player.AddForce(move);
    }


    // for z-axis
    void MoveForwardConstantly()
    {
        //Fwd and Back speed used to be user controlled but now it is not
        //I've decided it would be a better experience if the user wouldn't have to
        //hold fwd the whole time. 
        //verticalMovement = Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime;
        move.z = 50f;
    }

    // for x-axis
    void MoveLeftRight()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime * 6f ;
        move.x = horizontalMovement;
    }

    bool IsGrounded()
    {
        //1.1 because if the ball is rolling on slants, you'll still be able to control it 
        //it wont receive it as not on the ground if it is any lower
        //thus not being able to control it
        return Physics.Raycast(transform.position, Vector3.down, distanceToGround + 1.1f);
    }





    //lock the ball from rolling over the seams
    //the problem was that it would bounce to a certain degree when rolling over them
    //this will stop it from bouncing
    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("BallLock"))
        {
            //print("lock");
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }
    }

    //unlock the ball from rolling over the seams
    void OnTriggerExit(Collider obj)
    {
        if (obj.gameObject.CompareTag("BallLock"))
        {
            //print("unlocked");
            GetComponent<Rigidbody>().constraints = initialConstraints;
        }
    }


    public Vector3 GetPlayerPosition()
    {
        return transform.position;
    }


}//PlayerController Class




















