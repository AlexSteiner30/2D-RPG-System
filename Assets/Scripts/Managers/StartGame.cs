using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private Transform spawnPosition;

    private void Start()
    {
        LoadGame();
    }

    private void LoadGame()
    {
        GameObject.FindWithTag("Player").transform.position = spawnPosition.position;
    }
}
