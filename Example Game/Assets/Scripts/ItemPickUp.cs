using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour {

    public string itemName;
    public int pointValue = 10;

    //Access to GameManager
    private GameManager gm;
    private bool hasCollided = false;

    private void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && !hasCollided && !gm.inventory.AtMaxItems())
        {
            // Debug.Log("Collided " + other.gameObject.name);
            hasCollided = true;
            gm.inventory.AddToInventory(this.itemName, this.gameObject.tag);
            gm.IncreaseScore(pointValue);
            FindObjectOfType<AudioManager>().Play("item_pick_up");
            Destroy(this.gameObject);
            GBL_Interface.SendItemPick();
        }
    }

}
