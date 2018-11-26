using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public bool canOpen = false;
    public BoxCollider2D sesame;
    public BoxCollider2D blocker;
    public Animator anim;
    public AudioClip openCreak;
    AudioSource audioDoor;
    public bool alreadyPlayed = false;



    void Start()
    {
        audioDoor = GetComponent<AudioSource>();
    }

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
        if(alreadyPlayed == false)
        {
            anim.SetBool("LRDoorOpen", true);
            blocker.isTrigger = true;
            audioDoor.PlayOneShot(openCreak, 0.7f);
            alreadyPlayed = true;
        }
        
        
    }

    public void UnLockMe()
    {
        canOpen = true;
    }
}


