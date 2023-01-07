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
        GameObject spawnedPlayer = Instantiate(player);
        spawnPosition.transform.position = spawnPosition.position;

        Instantiate(gameManager);
    }
}
