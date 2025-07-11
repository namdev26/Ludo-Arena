using UnityEngine;

public class AnimatorController
{
    private readonly Animator animator;

    public AnimatorController(Animator animator)
    {
        this.animator = animator;
    }

    public void PlayWalk()
    {
        animator.Play("WalkForward");
    }

    public void PlayIdle() 
    {
        animator.Play("Idle01");
    }
}
