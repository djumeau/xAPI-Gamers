using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// required for GBLXAPI
using DIG.GBLXAPI;
using TinCan;

public class GBLStart : MonoBehaviour
{

    private void Start()
    {
        //Debug.Log ("GBL_Start.Start()");
        GBLXAPI.Instance.init(GBL_Interface.lrsURL, GBL_Interface.lrsUser, GBL_Interface.lrsPassword, GBL_Interface.standardsConfigDefault, GBL_Interface.standardsConfigUser);
        GBLXAPI.Instance.debugStatement = true;
        GBLXAPI.Instance.ResetDurationSlot((int)GBL_Interface.durationSlots.Game); // using slot 0 to track time

        //GBL_Interface.CreatePlayerUUID();

        GBL_Interface.SendAppLaunched();
    }
}