using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int moneyCount;

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
    }

    public void RemoveMoney(int amount)
    {
        if (moneyCount - amount > 0)
        {
            moneyCount -= amount;

            UpdateMoney();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void ReceiveMoney(int amount)
    {
        moneyCount += amount;

        UpdateMoney();
    }

    private void UpdateMoney()
    {
        gameManager.money.text = "$ " + moneyCount.ToString();
    }
}