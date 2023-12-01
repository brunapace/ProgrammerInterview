using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerAttributes : MonoBehaviour
{
    private int coins = 1000;
    public TextMeshProUGUI coinsText;

    private void Start()
    {
        coinsText.text = coins.ToString();
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
