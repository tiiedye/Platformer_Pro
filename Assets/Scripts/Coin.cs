using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Player _player;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player == null) {
            Debug.LogError("Player is null");
        }
    }

    // updates UI and destroy's coin if the player collects it.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            Player player = other.GetComponent<Player>();

            if (player != null) {
                player.addCoins();
            }
            Destroy(this.gameObject);
        }
    }
}
