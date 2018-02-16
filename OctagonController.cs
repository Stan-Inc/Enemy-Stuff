using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctagonController : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D myRigidbody;

    private bool moving;
    
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;

    public float timeToMove;
    private float timeToMoveCounter;

    private Vector3 moveDirection;

    public float reloadTime;
    private bool reloading;

    private GameObject thePlayer;

	// Use this for initialization
	void Start () {
        // timeBetweenMoveCounter = timeBetweenMove;
        // timeToMoveCounter = timeToMove;
        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.25f, timeBetweenMove * 1.75f);
        timeToMoveCounter = Random.Range(timeToMove * .25f, timeToMove * 1.75f);

        myRigidbody = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {


        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = moveDirection;
            if(timeToMoveCounter < 0f)
            {
                moving = false;
                // timeBetweenMoveCounter = timeBetweenMove;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.25f, timeBetweenMove * 1.75f);

            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            if(timeBetweenMoveCounter < 0)
            {
                moving = true;
                //  timeBetweenMoveCounter = timeToMove;
                timeToMoveCounter = Random.Range(timeToMove * .25f, timeToMove * 1.75f);

                moveDirection = new Vector3(Random.Range(1f, -1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }
        if (reloading)
        {
            reloadTime -= Time.deltaTime;
            if(reloadTime < 0)
            {
                Application.LoadLevel(Application.loadedLevel);
                thePlayer.SetActive(true);
            }

        }

	}
   void OnCollisionEnter2D(Collision2D other)
    {
       /*if(other.gameObject.name == "Player")
        {
            //  Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            reloading = true;
            thePlayer = other.gameObject;
        }*/ 
    }

}
