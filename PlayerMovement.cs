// Here we have the libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour // this is for player movement
{
    [SerializeField] float movementSpeed = 50f; // movement speed
    [SerializeField] float turnSpeed = 60f; // turn speed

    Transform myT; // referenece for the transform component

    void Awake() // awake method for the script instance loading
    {
        myT = transform; // assigning the transform
    }
    void Update()
    { 
        Turn(); // we call the turn method
        Thrust(); // we call the thrust method
    }
    void Turn() // here we calculate the rotation for horizontal, pitch and roll
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch");
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Roll");

        myT.Rotate(-pitch, yaw, -roll); // here we apply them
    }

    
    void Thrust()
    { // we move the players position
        myT.position += myT.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathArea")
        {
            movementSpeed = Time.timeScale = 0;
        }
    }
}
