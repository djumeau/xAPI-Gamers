using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Player : MonoBehaviour
{
    [System.Serializable]
    public class PlayerStats
    {
        public int Health = 100;        
    }

    public PlayerStats playerStats = new PlayerStats();

    
    public void DamagePlayer(int damage)
    {
        playerStats.Health -= damage;
        if (playerStats.Health <= 0)
        {
            GameMaster.KillPlayer(this);
        }
    }

    public void SetUsUpTheBomb()
    {
        GetComponent<BombEquip>().enabled = true;
    }

    public void MissilePower()
    {
        GetComponent<MissileEquip>().enabled = true;
    }


    public void HighJump()
    {
        GetComponent<PlatformerCharacter2D>().extraJumpsValue += 1;
    }
}
