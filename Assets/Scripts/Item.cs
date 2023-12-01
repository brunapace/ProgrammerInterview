using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item
{
    public string name;
    public int price;
    public Button button;
    public Sprite sprite;
    private int index;

    public Item(string name, Button button, int price, int index, Sprite sprite)
    {
        this.name = name;
        this.button = button;
        this.price = price;
        this.index = index;
        this.sprite = sprite;
    }

    public int GetIndex()
    {
        return index;
    }

    public void SetIndex(int value)
    {
        index = value;
    }
}
