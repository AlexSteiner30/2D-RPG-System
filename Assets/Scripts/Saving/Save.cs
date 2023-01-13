using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    public void LoadGame()
    {
        LoadPlayer();
        LoadInventory();
    }

    public void SaveGame()
    {
        SavePlayer();
        SaveInventory();
    }

    private void SavePlayer()
    {
        PlayerPrefs.SetInt("Scene Index", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("Money", (int)GameObject.FindWithTag("Player").GetComponent<Money>().ReturnMoney());
    }

    private void SaveInventory()
    {
        using (Stream file = File.Open(Application.persistentDataPath + "/invetory.dat", FileMode.OpenOrCreate))
        {
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(file, GameObject.FindWithTag("Player").GetComponent<Inventory>().items);
        }
    }

    private void LoadPlayer()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Scene Index"));
        PlayerPrefs.GetInt("Money");
    }

    private void LoadInventory()
    {
        using (Stream stream = File.Open(Application.persistentDataPath + "/invetory.dat", FileMode.OpenOrCreate))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            List<ScriptableItem> items = (List<ScriptableItem>)bformatter.Deserialize(stream);

            foreach (var x in items)
            {
                print(x.name);
            }
        }
    }
}
