using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFire : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0){
            animator.Play("MovementButRightist");
        }
        else if (Input.GetAxisRaw("Horizontal") < 0){
            animator.Play("MovementButLeftist");
        }
        else if (Input.GetAxisRaw("Vertical") > 0){
            animator.Play("MovementButCentrist");
        }
    }
}
