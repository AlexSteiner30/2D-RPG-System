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

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void ChangeScene()
    {
        player.transform.position = spawnPosition;
        SceneManager.LoadScene(sceneIndex);
    }
}
