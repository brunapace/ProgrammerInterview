using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerAttributes : Inventory
{
    private int coins = 1000;
    public TextMeshProUGUI coinsText;
    public GameObject inventory;
    [HideInInspector] public bool isInventoryAvailable = true;

    private void Start()
    {
        coinsText.text = coins.ToString();
        CreateItems();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isInventoryAvailable)
            {
                if (inventory.activeInHierarchy)
                {
                    OpenInventory();
                }
                else
                {
                    inventory.SetActive(false);
                }
            }
        }
    }

    private void OpenInventory()
    {
        inventory.SetActive(true);
        DisplayItems(inventory);
    }


    public int GetCoins()
    {
        return coins;
    }

    public void SetCoins(int value)
    {
        coins = value;
        coinsText.text = coins.ToString();
    }
}
