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
        InventoryItem item = new InventoryItem();
        item.image = this.GetComponent<Image>();
        item.price = value;

        GameObject.FindGameObjectWithTag("Player").GetComponent<Money>().RemoveMoney(value);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().AddItem(item);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().UpdateItems();
    }
}
