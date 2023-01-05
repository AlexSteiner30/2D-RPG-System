using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Speaking))]

public class Asking : MonoBehaviour
{
    [SerializeField] public Question question;
    [SerializeField] public int choosen;

    GameManager gameManager;

    Button continueButton;
    RectTransform slider;
    Text text;

    int count = 0;

    private void Awake()
    {
        gameManager = GameObject.FindWithTag("Game Manager").GetComponent<GameManager>();

        text = gameManager.message;
        continueButton = gameManager.continueButton;
        slider = gameManager.slider;
    }

    public void Ask(string msg)
    {
        GetComponent<Speaking>().Speak(msg);

        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(AskQuestion);
    }

    private void AskQuestion()
    {
        choosen = 0;
        count = 0;

        slider.anchoredPosition = new Vector2(slider.anchoredPosition.x, 144.66f);
        slider.gameObject.SetActive(true);

        text.text = "";

        GetComponent<Speaking>().StopAllCoroutines();
        StopAllCoroutines();

        StartCoroutine(WriteQuestionsCoroutine());
        StartCoroutine(SliderMove());
    }

    private IEnumerator WriteQuestionsCoroutine()
    {
        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(ReturnAnswer);

        foreach (string q in question.options)
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

    private void ReturnAnswer()
    {
        slider.gameObject.SetActive(false);
        
        choosen = count;

        GetComponent<NPC>().ContinueButton();
    }

    // Slider
    private IEnumerator SliderMove()
    {
        while (true)
        {
            float hor = Input.GetAxisRaw("Vertical");

            if (hor != 0)
            {
                if (hor >= 0 && count > 0) // up
                {
                    slider.anchoredPosition += new Vector2(0, 50);
                    count--;
                }

                else if (hor <= 0 && count < question.options.Count - 1) // down
                {
                    slider.anchoredPosition -= new Vector2(0, 50);
                    count++;
                }
            }

            yield return new WaitForSeconds(.1f);
        }
    }
}

[System.Serializable]
public class Question
{
    public List<string> options;
}
