using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : Inventory
{
    private GameObject player;
    private int shoppingCartValue;
    public GameObject shoppingCart;
    public TextMeshProUGUI shoppingCartText;
    private List<GameObject> shoppingCartItems = new();
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OpenInventory()
    {
        gameObject.transform.parent.gameObject.SetActive(true);
        SetItems();
        int i = 0;
        foreach (Item btn in itemsList)
        {
            int index = i;
            itemsList[index].button.onClick.AddListener(() => AddToCart(index));
            i++;
        }
    }
    private void AddToCart(int index)
    {
        shoppingCartValue = int.Parse(shoppingCartText.text);
        shoppingCartValue += itemsList[index].price;
        shoppingCartText.text = shoppingCartValue.ToString();
        itemsList[index].button.gameObject.transform.SetParent(shoppingCart.transform);
        shoppingCartItems.Add(itemsList[index].button.gameObject);
        shoppingCart.GetComponent<GridLayoutGroup>().SetLayoutHorizontal();
    }
    public void BuyItems()
    {
        int playerCoins = player.GetComponent<PlayerAttributes>().GetCoins();
        GameObject temp;

        playerCoins -= shoppingCartValue;
        player.GetComponent<PlayerAttributes>().SetCoins(playerCoins);
        for (int i = 0; i < shoppingCart.transform.childCount; i++)
        {
            temp = shoppingCartItems[0];
            shoppingCartItems.Remove(shoppingCartItems[0]);
            Destroy(temp);
        }
        shoppingCartValue = 0;
        shoppingCartText.text = shoppingCartValue.ToString();
    }

}
