using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinsText;

    // updates coin display
    public void updateCoins(int playerCoins)
    {
        _coinsText.text = "Coins: " + playerCoins.ToString();
    }
}
