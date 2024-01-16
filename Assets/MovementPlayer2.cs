using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer2 : MonoBehaviour
{
    [SerializeField]
    float speed = 4;

    Animator animator;

    bool facingRight;

    bool facingUp;

    bool movingHorizontal;

    bool disabled = true;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2)){
            disabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            disabled = true;
        }
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if (disabled == false){
            if (Mathf.Abs(moveX) > 0 && Mathf.Abs(moveY) > 0){
                moveY = 0;
            }
            if (moveX > 0){
                movingHorizontal = true;
                facingRight = true;
                animator.Play("HealerWalkingRight");
            }
            else if (moveX < 0){
                movingHorizontal = true;
                facingRight = false;
                animator.Play("HealerWalkingLeft");
            }
            else if (moveY > 0){
                movingHorizontal = false;
                facingUp = true;
                animator.Play("HealerWalkingUp");
            }
            else if (moveY < 0){
                movingHorizontal = false;
                facingUp = false;
                animator.Play("HealerWalkingDown");
            }
            else{
                if (movingHorizontal == true){
                    if (facingRight == true){
                        animator.Play("HealerIdleRight");
                    }
                    else if (facingRight == false){
                        animator.Play("HealerIdleLeft");
                    }
                }
                else {
                    if (facingUp == true){
                        animator.Play("HealerIdleUp");
                    }
                    else if (facingUp == false){
                        animator.Play("HealerIdleDown");
                    }
                }
            }
            Vector3 movement = new(moveX, moveY, 0);
            transform.Translate(movement * Time.deltaTime * speed);
        }
    }
}
