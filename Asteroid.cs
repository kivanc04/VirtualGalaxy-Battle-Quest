// we have the libraries here 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour // asteroid class for managing individual asteroids in the scene
{
    [SerializeField] float minScale = 0.8f; // we have min scale
    [SerializeField] float maxScale = 1.2f; // we have max scale 
    [SerializeField] float rotationOffset = 50f; // we have rotation offset 
    Transform myT;
    Vector3 randomRotation;

    
    void Awake() //awake method 
    {
        myT = transform; // we assign the transform component to myT for efficiency
    }

    void Start() // start method
    { // generating random scale for the asteroid within specified range 
        Vector3 scale = Vector3.one; 
        scale.x = Random.Range(minScale, maxScale);
        scale.y = Random.Range(minScale, maxScale);
        scale.z = Random.Range(minScale, maxScale);

        myT.localScale = scale; // set the asteroids scale 

        // generate random rotation values withing the specified offset range
        randomRotation.x = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.y = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.z = Random.Range(-rotationOffset, rotationOffset);

        //Debug.Log(randomRotation);
    }

    // Update is called once per frame
    void Update()
    {
        myT.Rotate(randomRotation * Time.deltaTime); // rotate the asteroid based onrandom rotation values over time
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathArea")
        {
            
            Time.timeScale = 0;
        }
    }
}
