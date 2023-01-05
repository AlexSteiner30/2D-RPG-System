using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Speaking))]

[System.Serializable]
public class Asking : MonoBehaviour
{
    [SerializeField] private List<Question> questions = new List<Question> { };

    public void Ask(string msg)
    {
        GetComponent<Speaking>().Speak(msg);
    }
}

[System.Serializable]
public class Question
{
    public List<string> question;
    public List<bool> correct;
}
