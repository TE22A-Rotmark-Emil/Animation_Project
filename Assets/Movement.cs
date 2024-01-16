using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float speed;

    bool facingRight;

    bool facingUp;

    bool movingHorizontal;

    bool disabled = false;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            disabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)){
            disabled = true;
        }
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if (disabled == false){
            if (Mathf.Abs(moveX) > 0 && Mathf.Abs(moveY) > 0){
                moveY = 0;
            }
            if (moveX > 0){
                animator.Play("GreenCapWalkingRight");
                facingRight = true;
                movingHorizontal = true;
            }
            else if (moveX < 0){
                animator.Play("GreenCapWalkingLeft");
                facingRight = false;
                movingHorizontal = true;
            }
            else if (moveY > 0){
                animator.Play("GreenCapWalkingUp");
                facingUp = true;
                movingHorizontal = false;
            }
            else if (moveY < 0){
                animator.Play("GreenCapWalkingDown");
                facingUp = false;
                movingHorizontal = false;
            }
            else{
                if (movingHorizontal == true){
                    if (facingRight == true){
                        animator.Play("GreenCapIdleRight");
                    }
                    else{
                        animator.Play("GreenCapIdleLeft");
                    }
                }
                else{
                    if (facingUp == true){
                        animator.Play("GreenCapIdleUp");
                    }
                    else{
                        animator.Play("GreenCapIdleDown");
                    }
                }
            }
            Vector3 movement = new(moveX, moveY, 0);
            transform.Translate(movement * Time.deltaTime * speed);
        }

    }
}
