using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class Save : MonoBehaviour
{
    private void Start()
    {
        LoadPlayerPosition();
        LoadInventory();
    }

    private void Update()
    {
        SavePlayerPosition();
        SaveInventory();
    }

    private void SavePlayerPosition()
    {

    }

    private void SaveInventory()
    {
        using (Stream file = File.Open(Application.persistentDataPath + "/invetory.dat", FileMode.OpenOrCreate))
        {
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(file, GameObject.FindWithTag("Player").GetComponent<Inventory>().items);
        }
    }

    private void LoadPlayerPosition()
    {

    }

    private void LoadInventory()
    {
        using (Stream stream = File.Open(Application.persistentDataPath + "/invetory.dat", FileMode.OpenOrCreate))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            List<InventoryItem> items = (List<InventoryItem>)bformatter.Deserialize(stream);

            foreach (var x in items)
            {
                print(x.ID);
            }
        }
    }
}
