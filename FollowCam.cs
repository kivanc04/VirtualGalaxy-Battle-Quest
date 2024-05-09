// we have the libraries here
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour // creating camera that smoothly follows a target
{
    [SerializeField] Transform target; // reference to the target the camera will follow 
    [SerializeField] Vector3 defaultDistance = new Vector3(0f, 2f, -10f); // default distance from target 
    [SerializeField] float distanceDamp = 10f; // damping factor for smoothing the camera factor
    // [SerializeField] float rotationalDamp = 2f;

    Transform myT; // reference to cameras transform
    public Vector3 velocity = Vector3.one; 
    // Start is called before the first frame update
    void Awake() // awake method
    {
        myT = transform; // we assign the transform component to myT for efficiency
    }

    
    void LateUpdate() // we use it after other update functions
    {
        SmoothFollow(); // here we call the smoothfollow method

        /*
        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        Vector3 curPos = Vector3.Lerp(myT.position, toPos, distanceDamp * Time.deltaTime);
        myT.position = curPos;

        Quaternion toRot = Quaternion.LookRotation(target.position - myT.position, target.up);
        Quaternion curRot = Quaternion.Slerp(myT.rotation, toRot, rotationalDamp * Time.deltaTime);
        myT.rotation = curRot;
        */
    }

    void SmoothFollow() // smoothly following the target
    {// calculate target position adding rotated default distance to target's posiiton
        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        Vector3 curPos = Vector3.SmoothDamp(myT.position, toPos, ref velocity, distanceDamp);
        // smoothly damp cameras current position towards target posiiton
        myT.position = curPos; // updating cameras position

        myT.LookAt(target, target.up); // we make the camera to look at the target while keeping its up direction aligned
                                      // with the target's up direction
    }
}
