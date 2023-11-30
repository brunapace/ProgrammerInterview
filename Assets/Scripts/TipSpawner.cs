using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TipSpawner : MonoBehaviour
{
    public GameObject tooltipText;
    public string displayedText;
    private GameObject canvas;
    public Vector3 position;

    private void Start()
    {
        canvas = GameObject.Find("Canvas");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject createdText;
        if(collision.CompareTag("Player"))
        {
            createdText = Instantiate(tooltipText);
            createdText.transform.SetParent(canvas.transform);
            createdText.GetComponent<TextMeshProUGUI>().text = displayedText;
            createdText.GetComponent<RectTransform>().localPosition = position;
            createdText.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
