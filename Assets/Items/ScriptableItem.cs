using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "RPG/Item", order = 1)]
[System.Serializable]
public class ScriptableItem : ScriptableObject
{
    public string objectName;
    public int value;

    public Sprite image;
}