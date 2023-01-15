using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class Save : MonoBehaviour
{
    [SerializeField] private ScriptableItem[] items;

    public void LoadGame()
    {
        StartCoroutine(IE_LoadGame());
    }

    public void SaveGame()
    {
        SavePlayer();
        SaveInventory();

        Debug.Log("Game saved!");
    }

    private void SavePlayer()
    {
        PlayerPrefs.SetInt("Scene Index", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("Money", (int)GameObject.FindWithTag("Player").GetComponent<Money>().ReturnMoney());
    }

    private void SaveInventory()
    {
        Inventory inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();

        for(int i = 0; i < items.Length; i++)
        {
            for(int j = 0; j < inventory.items.Count; j++)
            {
                if (items[i].objectName == inventory.items[i].objectName) // same name == same item
                {
                    PlayerPrefs.SetString("Item " + i.ToString(), "true");
                }
            }
        }
    }

    private IEnumerator IE_LoadGame()
    {
        LoadPlayer();

        yield return new WaitForSeconds(2);

        LoadInventory();

        Debug.Log("Game loaded!");
    }

    private void LoadPlayer()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Scene Index"));
        PlayerPrefs.GetInt("Money");
    }

    private void LoadInventory()
    {
        Inventory inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();

        for (int i = 0; i < items.Length; i++)
        {
            if(PlayerPrefs.GetString("Item " + i.ToString()) == "true")
            {
                inventory.items.Add(items[i]);
            }
        }
    }
}
