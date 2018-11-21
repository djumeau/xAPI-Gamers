using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkytalkyboss : MonoBehaviour
{

    public RPGTalk rpgtalk;


    public void Start()
    {

        if (rpgtalk != null)
        {
            rpgtalk.NewTalk();
        }

    }

}