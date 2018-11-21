using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    const int maxItems = 10;

    private int ItemsRemaining = 0;

    private List<Item> inventoryList;

    public delegate void OnListChanged();
    public OnListChanged OnListChangedCallback;

	public Inventory()
	{
        inventoryList = new List<Item>();
    }

    public void AddToInventory(string itemName, string itemType)
    {
        if (!AtMaxItems())
        {
            inventoryList.Add(new Item(itemName, itemType, 0));
            ItemsRemaining--;

            Debug.Log("Collected [" + inventoryList.Count + "] Name " + inventoryList[inventoryList.Count - 1].GetItemName());
           
            if (OnListChangedCallback != null)
                OnListChangedCallback.Invoke();
        }
        else
        {
            Debug.Log("At maximum items... cannot add. Go to a recycling bin or trash can.");
        }
    }

    public void AddToInventory(string itemName, string itemType, int pointValue)
    {
        if (!AtMaxItems())
        {
            inventoryList.Add(new Item(itemName, itemType, pointValue));
            ItemsRemaining--;

            Debug.Log("Collected [" + inventoryList.Count + "] Name " + inventoryList[inventoryList.Count - 1].GetItemName());

            if (OnListChangedCallback != null)
                OnListChangedCallback.Invoke();
        }
        else
        {
            Debug.Log("At maximum items... cannot add. Go to a recycling bin or trash can.");
        }
    }

    public Item GetInventoryItem(int val)
    {
        if ((val >= 0) && !AtMaxItems())
        {
            return inventoryList[val];
        }
        else
        {
            return null;
        }
    }

    public Item GetInventoryItem(string itemName)
    {
        return inventoryList.Find(item => item.GetItemName() == itemName);
    }

    public void RemoveItem(int id)
    {
        Item targetItem = GetInventoryItem(id);
        if (targetItem != null)
        {
            inventoryList.Remove(targetItem);
            if (OnListChangedCallback != null)
                OnListChangedCallback.Invoke();
        }
    }

    public void RemoveItem(string itemName)
    {
        Item targetItem = GetInventoryItem(itemName);
        if (targetItem != null)
        {
            inventoryList.Remove(targetItem);
            if (OnListChangedCallback != null)
                OnListChangedCallback.Invoke();
        }
    }

    public int GetTotalItems()
    {
        return inventoryList.Count;
    }

    public bool AtMaxItems()
    {
        return !(inventoryList.Count < maxItems);
    }

    public void Reset()
    {
        inventoryList.Clear();
    }

    public void SetItemsRemaining(int val)
    {
        ItemsRemaining = val;
    }

    public int GetItemsRemaining()
    {
        return ItemsRemaining;
    }

}
