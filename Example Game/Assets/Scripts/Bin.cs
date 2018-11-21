using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour {

    public string binName;

    //Access to GameManager
    private GameManager gm;
    private bool hasCollided = false;

    private void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && !hasCollided)
        {
            // Debug.Log(binName + " collided with [" + other.gameObject.name + "]");
            hasCollided = true;
            FindObjectOfType<AudioManager>().Play("bin");
            gm.ShowInventory();

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && hasCollided)
        {
            // Debug.Log("player left [" + this.binName + "]");
            hasCollided = false;
            gm.HideInventory();
        }
    }

}
