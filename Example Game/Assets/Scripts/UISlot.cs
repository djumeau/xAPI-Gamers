using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour {

    private Item item;
    public Image icon;

    public void AddItem(Item newItem)
    {
        this.item = newItem;
        icon.sprite = item.GetItemIcon();
        icon.enabled = true;

    }
    
    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

}
