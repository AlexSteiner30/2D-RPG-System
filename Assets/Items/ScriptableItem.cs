using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Inventory/Item", order = 1)]

[System.Serializable]
public class ScriptableItem : ScriptableObject
{
    public string objectName;
    public int value;

    public Sprite image;
}