using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header ("Dialogue Bubble")]
    public GameObject dialogueBubble;
    public Button continueButton;
    public RectTransform slider;
    public Text message;

    [Header("Inventory")]
    public GameObject inventory;

    [Header("Economy")]
    public Text money;
}
