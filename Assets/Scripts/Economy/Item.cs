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
        GameObject.FindGameObjectWithTag("Player").GetComponent<Money>().RemoveMoney(value);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().AddItem(this.gameObject.GetComponent<Item>());
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().UpdateItems();
    }
}
