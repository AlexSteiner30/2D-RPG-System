using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Asking))]

public class Seller : MonoBehaviour
{
    [SerializeField] private GameObject sellingPanel;

    GameManager gameManager;

    Asking asking;
    Speaking speaking;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();

        asking = GetComponent<Asking>();
        speaking = GetComponent<Speaking>();
    }

    public void Sell()
    {
        if (asking.question.options[asking.choosen].ToLower() == "yes")
        {
            gameManager.dialogueBubble.SetActive(false);
            sellingPanel.SetActive(true);
        }
        else
        {
            speaking.Speak("See you next time");
        }
    }
}
