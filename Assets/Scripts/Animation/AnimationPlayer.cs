using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    public Animator animator;

    // Animação de Idle
    public void IdlePlayer(){
        animator.SetBool("Idle", true);
        animator.SetBool("Run", false);
    }

    public void RunningPlayer(){
        animator.SetBool("Run", true);
        animator.SetBool("Idle", false);
    }
}
