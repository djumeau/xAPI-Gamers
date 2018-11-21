using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private int score = 0;
    private int highScore = 0;

    public Inventory inventory;

    const int itemPointValue = 10;

    public static GameManager instance;

    private HUDManager hmgr;

    #region Singleton

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            inventory = new Inventory();

        } else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject); // Prevents from being destroyed when changing scenes

        hmgr = FindObjectOfType<HUDManager>();

    }

    #endregion

    public void Start()
    {
        inventory.SetItemsRemaining(TotalPickUpItems());
        hmgr.UpdateHUD();
        //Debug.Log("Starting ... finding total objects with tag: " + TotalPickUpItems());
    }

    public int TotalPickUpItems()
    {
        GameObject[] PickUps = GameObject.FindGameObjectsWithTag("Recyclable");

        if (PickUps == null)
        {
            Debug.Log("No Pickups available.");
            return 0;
        }

        return PickUps.Length;
    }

    public void IncreaseScore(int value)
    {
        score += value;
        if (hmgr != null)
            hmgr.UpdateHUD();
    }

    public void ResetScore()
    {
        inventory.Reset();
        
        highScore = score;

        score = 0;

        if (hmgr != null)
            hmgr.UpdateHUD();

    }

    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public Inventory GetInventory()
    {
        return this.inventory;
    }

    public void ShowInventory()
    {
        hmgr.ShowInventory();
    }

    public void HideInventory()
    {
        hmgr.HideInventory();
    }

}
