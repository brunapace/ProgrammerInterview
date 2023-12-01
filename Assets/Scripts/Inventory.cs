using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public string[] itemNames;
    [HideInInspector] public List<Item> itemsList = new();
    public GameObject buttonPrefab;

    public void SetItems()
    {
        GameObject currentButton;
        
        for (int i = 0; i < itemNames.Length; i++)
        {
            currentButton = Instantiate(buttonPrefab);
            itemsList.Add(new Item(itemNames[i], currentButton.GetComponent<Button>()));

            currentButton.transform.SetParent(gameObject.transform);
            currentButton.GetComponent<RectTransform>().localScale = new Vector3(0.2f, 0.2f, 1f);
        }

        gameObject.GetComponent<GridLayoutGroup>().SetLayoutHorizontal();
        
    }
}
