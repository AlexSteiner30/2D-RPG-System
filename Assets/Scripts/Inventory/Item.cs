using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private ScriptableItem item;

    GameObject player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");

        GetComponentInChildren<Text>().text = "$ " + item.value.ToString();
        GetComponentsInChildren<Image>()[1].sprite = item.image;
    }

    public void Buy()
    {        
        player.GetComponent<Money>().RemoveMoney(item.value);
        player.GetComponent<Inventory>().AddItem(item);
        player.GetComponent<Inventory>().UpdateItems();
    }
}
