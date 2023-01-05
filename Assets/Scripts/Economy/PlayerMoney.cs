using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private int moneyAmount;

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
    }

    public void RemoveMoney(int amount)
    {
        if (moneyAmount - amount > 0)
        {
            moneyAmount -= amount;

            UpdateMoney();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void ReceiveMoney(int amount)
    {
        moneyAmount += amount;

        UpdateMoney();
    }

    private void UpdateMoney()
    {
        gameManager.money.text = "$ " + moneyAmount.ToString();
    }
}