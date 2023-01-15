using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<ScriptableItem> items = new List<ScriptableItem>();

    public GameObject inventory;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().invetory;
    }

    public void AddItem(ScriptableItem item)
    {
        items.Add(item);
    }

    public void UpdateItems()
    {
        GameObject itemObject = new GameObject();
        itemObject.name = "Item";

        itemObject.AddComponent<Image>();
        itemObject.GetComponent<Image>().sprite = items[items.Count - 1].image;
        itemObject.transform.localScale = new Vector2(1, 1);

        itemObject.transform.parent = inventory.transform;
    }
}
