using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public string[] itemsName;
    public int[] itemsPrice;
    [HideInInspector] public List<Item> itemsList = new();
    public GameObject buttonPrefab;

    public void SetItems()
    {
        GameObject currentButton;
        
        for (int i = 0; i < itemsName.Length; i++)
        {
            currentButton = Instantiate(buttonPrefab);
            itemsList.Add(new Item(itemsName[i], currentButton.GetComponent<Button>(), itemsPrice[i]));

            currentButton.transform.SetParent(gameObject.transform);
            currentButton.GetComponent<RectTransform>().localScale = new Vector3(0.2f, 0.2f, 1f);
        }

        gameObject.GetComponent<GridLayoutGroup>().SetLayoutHorizontal();
        
    }
}
