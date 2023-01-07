using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(InteractableObject))]

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    [SerializeField] private Vector2 spawnPosition;

    Transform player;
    GameObject gameManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameManager = GameObject.FindGameObjectWithTag("Game Manager");
    }

    public void ChangeScene()
    {
        Scene scene = SceneManager.GetSceneByBuildIndex(sceneIndex);

        player.transform.position = spawnPosition;

        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }
}
