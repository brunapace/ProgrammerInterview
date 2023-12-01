using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : Inventory
{

    // Start is called before the first frame update
    void Start()
    {
        //SetItems(itemNames);
    }

    public void OpenInventory()
    {
        gameObject.SetActive(true);
        SetItems();
        int i = 0;
        foreach (Item btn in itemsList)
        {
            int index = i;
            itemsList[index].button.onClick.AddListener(() => BuyItem(index));
            i++;
        }
    }
    
    private void BuyItem(int index)
    {
        Debug.Log(itemsList[index].name);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
