using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Speaking))]

public class Asking : MonoBehaviour
{
    [SerializeField] private Question question;

    GameManager gameManager;
    Button continueButton;
    Text text;


    bool running = false;

    private void Awake()
    {
        gameManager = GameObject.FindWithTag("Game Manager").GetComponent<GameManager>();
        text = gameManager.message;
        continueButton = gameManager.continueButton;
    }

    public void Ask(string msg)
    {
        GetComponent<Speaking>().Speak(msg);
        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(AskQuestion);
    }

    private void AskQuestion()
    {
        text.text = "";
        StartCoroutine(WriteQuestionsCoroutine());
    }

    private IEnumerator WriteQuestionsCoroutine()
    {
        foreach (string q in question.question)
        {
            text.text += "- ";

            for (int i = 0; i < q.Length; i++)
            {
                text.text += q[i];

                yield return new WaitForSeconds(.05f);
            }
            text.text += "\n";
        }
    }
}

[System.Serializable]
public class Question
{
    public List<string> question;
    public List<bool> correct;
}
