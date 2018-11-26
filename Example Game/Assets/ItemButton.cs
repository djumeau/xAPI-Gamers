using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour {

    private Item Data;

    public Button Button;
    public Image IconImage;

	void Awake() {
        UpdateButton(null);
    }

    public void UpdateButton(Item val)
    {
        if (val != null)
        {
            this.Data = val;
            this.IconImage.color = Color.white;

            Debug.Log("Path [" + "Sprites/Items/" + this.Data.GetItemName().ToLower() + "]");

            this.IconImage.sprite = Resources.Load<Sprite>("Sprites/Items/" + this.Data.GetItemName().ToLower());

        } else
        {
            this.IconImage.color = Color.clear;
            // Debug.LogWarning("Requires Item Object to update...");
        }
        
    }
}
