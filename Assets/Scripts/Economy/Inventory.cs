using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> items = new List<Item>();

    private void AddItem(Item item)
    {
        items.Add(item);
    }

    private void UpdateItems()
    {

    }
}
