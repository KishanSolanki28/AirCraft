using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    public GameObject[] players;
    [SerializeField]
    GameObject currentPlayer;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < players.Length; i++)
        {
            players[i].GetComponent<AirCraftController>().enabled = false;
        }
        currentPlayer = players[0];
    }

    public void SelectPlayer(GameObject player) {
        currentPlayer.GetComponent<AirCraftController>().enabled = false;
        currentPlayer = player;
    }
}
