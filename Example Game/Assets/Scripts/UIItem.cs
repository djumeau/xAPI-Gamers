using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour {

    public Item item;
    private Image spriteImage;

    public void Awake()
    {
        spriteImage = GetComponent<Image>();
        updateItem(null);
    }

    public void updateItem(Item newItem)
    {
        this.item = newItem;

        if (this.item != null)
        {
            spriteImage.color = Color.white;
            spriteImage.sprite = this.item.GetItemIcon();
        }

     }

}
