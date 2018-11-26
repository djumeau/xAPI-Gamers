using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

    public Text ScoreText;
    public Text InventoryText;

    public GameObject InventoryPanel; 

    private GameManager gm;

    private void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Use this for initialization
    void Start () {
        UpdateHUD();
	}
	
    public void UpdateHUD()
    {
        ScoreText.text = "score :  " + gm.GetScore();
        InventoryText.text = "items remaining : " + gm.inventory.GetItemsRemaining();
    }

    public void ShowInventory()
    {
        InventoryPanel.SetActive(true);
    }

    public void HideInventory()
    {
        InventoryPanel.SetActive(false);
    }

}
