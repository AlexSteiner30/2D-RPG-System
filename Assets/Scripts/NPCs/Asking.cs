using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Speaking))]

public class Asking : MonoBehaviour
{
    [SerializeField] private Question questionNormal;
    [SerializeField] private QuestionQuiz questionQuiz;

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

    // Quiz
    public void AskQuiz(string msg)
    {
        GetComponent<Speaking>().Speak(msg);

        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(AskQuestionQuiz);
    }

    private void AskQuestionQuiz()
    {  
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
        continueButton.onClick.AddListener(RevealAnswer);

        foreach (string q in questionQuiz.question)
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

    private void RevealAnswer()
    {
        slider.gameObject.SetActive(false);

        if (questionQuiz.correct[count])
        {
            GetComponent<Speaking>().Speak("You were correct!");
        }
        else
        {
            GetComponent<Speaking>().Speak("You were wrong!");
        }
    }

    // Slider
    private IEnumerator SliderMove()
    {
        while (true)
        {
            float hor = Input.GetAxisRaw("Vertical");

            if (hor != 0)
            {
                if (hor >= 0 && count != 0) // up
                {
                    slider.anchoredPosition += new Vector2(0, 50);
                    count--;
                }

                else if (hor <= 0 && count != questionQuiz.question.Count) // down
                {
                    slider.anchoredPosition -= new Vector2(0, 50);
                    count++;
                }
            }

            yield return new WaitForSeconds(.1f);
        }
    }

    // Normal 
}

[System.Serializable]
public class Question
{
    public List<string> question;
}

[System.Serializable]
public class QuestionQuiz
{
    public List<string> question;
    public List<bool> correct;
}
