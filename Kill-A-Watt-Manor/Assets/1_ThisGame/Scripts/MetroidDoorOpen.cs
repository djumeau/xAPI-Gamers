using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetroidDoorOpen : MonoBehaviour {


    public CapsuleCollider2D blocker;
    public Animator anim;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Missile")
        {
            Open();
        }
    }


    public void Open()
    {
        anim.SetBool("wasMissiled", true);
        blocker.isTrigger = true;
    }
}
