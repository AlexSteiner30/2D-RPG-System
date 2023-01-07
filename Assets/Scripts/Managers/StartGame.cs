using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameManager;

    [SerializeField] private Transform spawnPosition;

    private void Awake()
    {
        LoadGame();
    }

    private void LoadGame()
    {
        Instantiate(player, spawnPosition.position, Quaternion.identity);
        Instantiate(gameManager);
    }
}
