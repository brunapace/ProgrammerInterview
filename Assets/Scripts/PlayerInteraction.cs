using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private bool storeAvailable = false;
    public GameObject store;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleInteraction(gameObject.name);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        HandleInteraction("out-" + gameObject.name);
    }

    void HandleInteraction(string objectName)
    {
        switch (objectName)
        {
            case "counter-interaction-trigger":
                if(gameObject.GetComponent<TooltipSpawner>() != null)
                {
                    gameObject.GetComponent<TooltipSpawner>().SpawnTooltip();
                }
                storeAvailable = true;
                break;
            case "out-counter-interaction-trigger":
                if (gameObject.GetComponent<TooltipSpawner>() != null)
                {
                    gameObject.GetComponent<TooltipSpawner>().UnspawnTooltip();
                }
                storeAvailable = false;
                store.GetComponent<Store>().CloseInventory();
                break;
            default:
                break;
        }
    }
    
    void Update()
    {
        if(storeAvailable && Input.GetKeyDown(KeyCode.E))
        {
            store.GetComponent<Store>().OpenInventory();
        }
    }
}
