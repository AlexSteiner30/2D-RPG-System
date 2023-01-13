using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private uint moneyCount;

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();

        moneyCount = (uint)PlayerPrefs.GetInt("Money");
        UpdateMoney();
    }

    public void RemoveMoney(int amount)
    {
        if (moneyCount - amount > 0)
        {
            moneyCount -= (uint)amount;

            UpdateMoney();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void ReceiveMoney(int amount)
    {
        moneyCount += (uint)amount;

        UpdateMoney();
    }

    public uint ReturnMoney()
    {
        return moneyCount;
    }

    private void UpdateMoney()
    {
        gameManager.money.text = "$ " + moneyCount.ToString();
    }
}