using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    public float coolDownTime = 2f;
    public float nextFiretime = 0f;
    public static int numOfClicks = 0;
    public float lastClickTime = 0;
    public float maxComboDelay = 1;
    public int no;
    // Start is called before the first frame update
    private void Update()
    {
        no = numOfClicks;
    }

}
