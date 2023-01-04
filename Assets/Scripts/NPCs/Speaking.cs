using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Speaking : MonoBehaviour
{
    [SerializeField] private UnityEvent speakingEvents;

    GameManager gameManager;
    Text text;

    private void Awake()
    {
        gameManager = GameObject.FindWithTag("Game Manager").GetComponent<GameManager>();
        text = gameManager.message.GetComponent<Text>();
    }

    public void InvokeSpeakingEvents()
    {
        speakingEvents.Invoke();
    }

    public void Speak(string msg)
    {
        gameManager.dialogueBubble.SetActive(true);

        text = null;

        StartCoroutine(SpeakCoroutine(msg));
    }

    private IEnumerator SpeakCoroutine(string msg)
    {
        for(int i = 0; i < msg.Length; i++)
        {
            text.text += msg[i];

            yield return new WaitForSeconds(.5f);
        }
    }
}
