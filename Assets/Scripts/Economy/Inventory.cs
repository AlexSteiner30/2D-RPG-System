using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> items = new List<Item>();

    public GameObject inventory;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory");
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void UpdateItems()
    {
        foreach(Item item in items) 
        {
            GameObject itemInstantiated = Instantiate(item.gameObject);

            itemInstantiated.transform.SetParent(inventory.transform);
        }
    }
}
