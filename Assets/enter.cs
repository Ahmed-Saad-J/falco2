using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enter : StateMachineBehaviour
{
    public string targetBool;
    public bool status;

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(targetBool, status);
    }
}
