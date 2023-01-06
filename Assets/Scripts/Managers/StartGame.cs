using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject player;

    [SerializeField] private Vector3 spawnPosition;

    private void Awake()
    {
        DontDestroyOnLoad(Instantiate(player, spawnPosition, Quaternion.identity));
        DontDestroyOnLoad(Instantiate(gameManager));

        Destroy(this);
    }
}
