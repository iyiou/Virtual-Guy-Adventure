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
        animator.SetBool("SlideWall", false);
    }

    public void RunningPlayer()
    {
        animator.SetBool("Run", true);
        animator.SetBool("Idle", false);
        animator.SetBool("Jump", false);
        animator.SetBool("Falling", true);
        animator.SetBool("SlideWall", false);
    }

    public void JumpingPlayer()
    {
        animator.SetBool("Jump", true);
        animator.SetBool("Idle", false);
        animator.SetBool("Run", false);
        animator.SetBool("Falling", true);
        animator.SetBool("SlideWall", false);
    }
    public void FallingPlayer()
    {
        animator.SetBool("Falling", true);
        animator.SetBool("Idle", false);
        animator.SetBool("Run", false);
        animator.SetBool("Jump", false);
        animator.SetBool("SlideWall", false);

    }

    public void SlideWallPlayer()
    {
        animator.SetBool("SlideWall", true);
        animator.SetBool("Idle", false);
        animator.SetBool("Run", false);
        animator.SetBool("Jump", false);
        animator.SetBool("Falling", false);
    }

    public void DoubleJumping()
    {
        animator.SetTrigger("DoubleJump");
        animator.SetBool("SlideWall", false);
        animator.SetBool("Idle", false);
        animator.SetBool("Run", false);
        animator.SetBool("Jump", false);
        animator.SetBool("Falling", false);
    }
    public void Damage(){
        animator.SetTrigger("Damage");
    }

    public void DeathPlayer(){
        animator.SetBool("End", true);
        animator.SetTrigger("End");
    }
}
