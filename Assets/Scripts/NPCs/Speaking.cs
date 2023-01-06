using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent (typeof(AudioSource))]

public class Speaking : MonoBehaviour
{
    private AudioSource audioSource;

    private const float speakingSpeed = .05f;

    private NPC npc;
    private Button continueButton;
    private Text text;

    private void Start()
    {
        npc = GetComponent<NPC>();
        audioSource = GetComponent<AudioSource>();

        text = npc.gameManager.message;
        continueButton = npc.gameManager.continueButton;
    }

    public void Speak(string msg)
    {
        npc.gameManager.dialogueBubble.SetActive(true);

        text.text = null;

        StartCoroutine(SpeakCoroutine(msg));
        StartCoroutine(PlaySound());
    }

    private IEnumerator SpeakCoroutine(string msg)
    {
        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(GetComponent<NPC>().ContinueButton);

        for (int i = 0; i < msg.Length; i++)
        {
            text.text += msg[i];

            yield return new WaitForSeconds(speakingSpeed);
        }

        StopAllCoroutines();
    }

    private IEnumerator PlaySound()
    {
        while (true)
        {
            audioSource.Play();

            yield return new WaitForSeconds(.1f);

            audioSource.Stop();
        }
    }
}
