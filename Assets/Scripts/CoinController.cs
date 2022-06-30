using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private float forceValue = 10.0f;
    [SerializeField] private float rotateSpeed = 200f;
    private Rigidbody rigidbody;
    [SerializeField] private float timeStayOnGround = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y > 30)
        {
            rigidbody.AddForce(-Vector3.up * forceValue);
        }
        else
        {
            Rotate();
            rigidbody.isKinematic = true;
        }
    }
    void Rotate()
    {
        transform.Rotate(rotateSpeed*Time.deltaTime, 0, 0);
        timeStayOnGround -= Time.deltaTime;
        if (timeStayOnGround <= 0)
        {
            Destroy(gameObject);
        }
    }
}
