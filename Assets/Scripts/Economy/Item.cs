using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private int value;
    GameObject player;

    private void Awake()
    {
        GetComponentInChildren<Text>().text = "$ " + value.ToString();
    }


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void Buy()
    {
        InventoryItem item = new InventoryItem();
        //item.image = this.GetComponent<Image>().sprite;
        //item.price = value;

        
        player.GetComponent<Money>().RemoveMoney(value);
        player.GetComponent<Inventory>().AddItem(item);
        player.GetComponent<Inventory>().UpdateItems();
    }
}
