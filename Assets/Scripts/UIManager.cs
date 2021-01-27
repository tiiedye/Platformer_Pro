using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinsText, _livesText;

    // updates coin display
    public void updateCoins(int playerCoins)
    {
        _coinsText.text = "Coins: " + playerCoins.ToString();
    }

    public void updateLives(int lives)
    {
        _livesText.text = "Lives: " + lives.ToString();
    }
}
