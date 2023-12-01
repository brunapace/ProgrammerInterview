using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TooltipSpawner : MonoBehaviour
{
    public GameObject tooltipTextPrefab;
    public string displayedText;
    private GameObject canvas;
    public Vector3 position;
    private GameObject createdText;

    private void Start()
    {
        canvas = GameObject.Find("Canvas");
    }

    
    public void SpawnTooltip()
    {
        createdText = Instantiate(tooltipTextPrefab);
        createdText.transform.SetParent(canvas.transform);
        createdText.GetComponent<TextMeshProUGUI>().text = displayedText;
        createdText.GetComponent<RectTransform>().localPosition = position;
        createdText.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
    public void UnspawnTooltip()
    {
        Destroy(createdText);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
