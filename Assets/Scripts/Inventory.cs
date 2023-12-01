using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public string[] itemsName;
    public int[] itemsPrice;
    [HideInInspector] public List<Item> itemsList = new();
    public GameObject buttonPrefab;

    public void CreateItems()
    {
        GameObject currentButton;

        for (int i = 0; i < itemsName.Length; i++)
        {
            currentButton = Instantiate(buttonPrefab);
            itemsList.Add(new Item(itemsName[i], currentButton.GetComponent<Button>(), itemsPrice[i], i));
        }
    }

    public void DisplayItems(GameObject gridContainer)
    {
        GameObject currentButton;

        for (int i = 0; i < itemsList.Count; i++)
        {
            currentButton = itemsList[i].button.gameObject;
            currentButton.transform.SetParent(gridContainer.transform);
            currentButton.GetComponent<RectTransform>().localScale = new Vector3(0.2f, 0.2f, 1f);
        }
        gridContainer.GetComponent<GridLayoutGroup>().SetLayoutHorizontal();
    }
    public void AddItem(GameObject gridContainer, Item item)
    {
        itemsList.Add(item);
        item.button.gameObject.transform.SetParent(gridContainer.transform);
    }

    public void MoveItem(List<Item> originalList, List<Item> targetList, int index)
    {
        targetList.Add(originalList[index]);
        targetList[^1].SetIndex(targetList.Count - 1);
        originalList.RemoveAt(index);
        UpdateIndexes();
    }
    public void RemoveItem(GameObject gridContainer, Item item)
    {
        itemsList.Remove(item);
        UpdateIndexes();
        Destroy(item.button.gameObject);
    }
    
    private void UpdateIndexes()
    {
        int i = 0;
        foreach (Item item in itemsList)
        {
            int index = i;
            item.SetIndex(index);
            i++;
        }
    }
}
