using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    public Animator animator;

    // Animação de Idle
    public void IdlePlayer()
    {
        animator.SetBool("Idle", true);
        animator.SetBool("Run", false);
        animator.SetBool("Jump", false);
        animator.SetBool("Falling", true);
        animator.SetBool("Wall Jump", false);
    }

    public void RunningPlayer()
    {
        animator.SetBool("Run", true);
        animator.SetBool("Idle", false);
        animator.SetBool("Jump", false);
        animator.SetBool("Falling", true);
        animator.SetBool("Wall Jump", false);
    }

    public void JumpingPlayer()
    {
        animator.SetBool("Jump",true);
        animator.SetBool("Idle",false);
        animator.SetBool("Run",false);
        animator.SetBool("Falling", true);
        animator.SetBool("Wall Jump", false);
    }
    public void FallingPlayer(){
        animator.SetBool("Falling", true);
        animator.SetBool("Idle", false);
        animator.SetBool("Run", false);
        animator.SetBool("Jump", false);
        animator.SetBool("Wall Jump", false);

    }

    public void WallJumpPlayer(){
        animator.SetBool("Wall Jump", true);
        animator.SetBool("Idle", false);
        animator.SetBool("Run", false);
        animator.SetBool("Jump", false);
        animator.SetBool("Falling", false);
    }
}
