using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<InventoryItem> items = new List<InventoryItem>();

    public GameObject inventory;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().invetory;
    }

    public void AddItem(InventoryItem item)
    {
        items.Add(item);
    }

    public void UpdateItems()
    {
        GameObject itemObject = new GameObject();

        itemObject.AddComponent<Image>();
        itemObject.GetComponent<Image>().sprite = items[0].image.sprite;

        itemObject.transform.parent = inventory.transform;
    }
}
