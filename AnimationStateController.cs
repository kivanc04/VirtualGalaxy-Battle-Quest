using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash; 
    // Start is called before the first frame update 
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool pressing = Input.GetKey("w"); 
        //if player presses T button
        if(!isWalking && pressing){
            //isWalking true
            animator.SetBool(isWalkingHash, true); 
        }   
        //if player does not press T button
        if(isWalking && !pressing){
            //isWalking false
            animator.SetBool(isWalkingHash, false); 
        }   
    }
}
   