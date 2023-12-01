using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : Inventory
{
    public GameObject player;
    private int shoppingCartValue;
    public GameObject shoppingCart;
    public TextMeshProUGUI shoppingCartText;
    private List<Item> shoppingCartItems = new();

    private void Awake()
    {
        CreateItems();
    }
    public void OpenInventory()
    {
        gameObject.transform.parent.gameObject.SetActive(true);
        DisplayItems(gameObject);
        player.GetComponent<PlayerAttributes>().isInventoryAvailable = false;
        AssignOnClick();
    }
    private void AssignOnClick()
    {
        int i = 0;
        foreach (Item btn in itemsList)
        {
            int index = i;
            itemsList[index].button.onClick.RemoveAllListeners();
            itemsList[index].button.onClick.AddListener(() => AddToCart(itemsList[index].GetIndex()));
            i++;
        }
    }
    private void AddToCart(int index)
    {
        shoppingCartValue = int.Parse(shoppingCartText.text);
        shoppingCartValue += itemsList[index].price;
        shoppingCartText.text = shoppingCartValue.ToString();

        itemsList[index].button.gameObject.transform.SetParent(shoppingCart.transform);
        MoveItem(itemsList, shoppingCartItems, index);
        AssignOnClick();
        shoppingCart.GetComponent<GridLayoutGroup>().SetLayoutHorizontal();
    }

    public void BuyItems()
    {
        int playerCoins = player.GetComponent<PlayerAttributes>().GetCoins();

        playerCoins -= shoppingCartValue;
        player.GetComponent<PlayerAttributes>().SetCoins(playerCoins);
        foreach (Transform child in shoppingCart.transform)
        {
            Destroy(child.gameObject);
        }
        shoppingCartItems.Clear();
        shoppingCartValue = 0;
        shoppingCartText.text = shoppingCartValue.ToString();
    }

    public void CloseInventory()
    {
        player.GetComponent<PlayerAttributes>().isInventoryAvailable = true;
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
