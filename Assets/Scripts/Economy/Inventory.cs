using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<InventoryItem> items = new List<InventoryItem>();

    public GameObject inventory;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory");
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
