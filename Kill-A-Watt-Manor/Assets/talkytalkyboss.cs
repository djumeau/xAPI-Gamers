using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkytalkyboss : MonoBehaviour
{
    public BoxCollider2D collider;
    public RPGTalk rpgtalk;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (rpgtalk != null)
            {
                rpgtalk.NewTalk();
            }
        }
              

    }

}