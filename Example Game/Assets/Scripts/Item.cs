using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item {

    private string Id;
    private string Name;
    private string Type;
    private Sprite icon;
    private int Points;

    public Item(string name, string type, int points)
    {
        this.Name = name;
        this.Type = type;
        this.Points = points;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + name.ToLower());
    }

    public string GetItemName()
    {
        return Name;
    }

    public string GetItemType()
    {
        return Type;
    }

    public int GetPoints()
    {
        return Points;
    }

    public Sprite GetItemIcon()
    {
        return this.icon;
    }

}
