using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item
{
    public string name;
    public int price;
    public Button button;
    // Start is called before the first frame update

    public Item(string name, Button button, int price)
    {
        this.name = name;
        this.button = button;
        this.price = price;
    }

}
