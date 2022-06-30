using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Array of waypoints to walk from one to the next one
    [SerializeField] private Transform[] waypoints;

    //Walk speed that can be set in Inspector
    [SerializeField] private float moveSpeed = 2f;

    //Rotate speed
    [SerializeField] private float rotateSpeed = 10f;

    //Index of current waypoint from which Enemy walks to the next one
    private int waypointIndex = 0;

    //GamePlayUIController variable
    [SerializeField] GamePlayUIController gamePlayUIController;

    // Start is called before the first frame update
    void Start()
    {
        //Set position of player as position of the first waypoint
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    //Method that actually make Player run
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
        //transform.rotation = Quaternion.LookRotation(waypoints[waypointIndex].transform.position);
        Rotate();
        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
            if (waypointIndex >= waypoints.Length)
            {
                waypointIndex = 0;
            }
        }
    }
    private void Rotate()
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = waypoints[waypointIndex].position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = rotateSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
    //private void OnCollisionEnter(Collision col)
    //{
    //    Debug.Log(col.gameObject.name);
    //    if (col.gameObject.CompareTag("Coin"))
    //    {
    //        Debug.Log("this is Coin111");
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            gamePlayUIController.AddScore();
        }
    }
}
