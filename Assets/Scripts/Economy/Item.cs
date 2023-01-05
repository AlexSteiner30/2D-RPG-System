using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private int value;

    private void Awake()
    {
        GetComponentInChildren<Text>().text = "$ " + value.ToString();
    }

    public void Buy()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoney>().RemoveMoney(value);
    }
}
