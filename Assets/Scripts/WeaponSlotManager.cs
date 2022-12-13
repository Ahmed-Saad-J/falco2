using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{
    // Start is called before the first frame update
    DamageCollider rightHandCollider;
    void Start()
    {
        rightHandCollider = GetComponentInChildren<DamageCollider>();
    }

    public void EnableRightHandeCollider()
    {
        rightHandCollider.EnableDamageCollider();
    }
    public void DisableRightHandeCollider()
    {
            rightHandCollider.DisableDamageCollider();
    }
}
