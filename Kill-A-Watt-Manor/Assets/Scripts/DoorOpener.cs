using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public bool canOpen = false;
    public BoxCollider2D sesame;
    public BoxCollider2D blocker;
    public Animator anim;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (canOpen == true)
            {
                Open();
            }
        }
    }


    public void Open()
    {
        anim.SetBool("LRDoorOpen", true);
        blocker.isTrigger = true;
    }

    public void UnLockMe()
    {
        canOpen = true;
    }
}


