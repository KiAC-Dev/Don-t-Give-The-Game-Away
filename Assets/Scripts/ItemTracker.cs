using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemTracker : MonoBehaviour
{
    [SerializeField] GameObject giftPrefab;
    public List<ItemSaveData> items;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void AddItem(GameObject item)
    {
        items.Add(new ItemSaveData(SceneManager.GetActiveScene().name, item.transform.position, item.transform.rotation, item.transform.localScale));
    }

    public void RemoveItem(GameObject item)
    {
        ItemSaveData itemToRemove = new ItemSaveData(SceneManager.GetActiveScene().name, item.transform.position, item.transform.rotation, item.transform.localScale);

        items.Remove(itemToRemove);
    }

    public void LoadItems()
    {
        foreach (ItemSaveData item in items)
        {
            if (item.scene != SceneManager.GetActiveScene().name) continue;

            GameObject gift = Instantiate(giftPrefab);
            gift.transform.position = item.position;
            gift.transform.rotation = item.rotation;
            gift.transform.localScale = item.scale;
        }
    }
}

[Serializable]
public struct ItemSaveData : IEquatable<ItemSaveData>
{
    public string scene;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;

    public ItemSaveData(string scene, Vector3 position, Quaternion rotation, Vector3 scale) : this()
    {
        this.scene = scene;
        this.position = position;
        this.rotation = rotation;
        this.scale = scale;
    }

    public override bool Equals(object obj) => obj is ItemSaveData other && this.Equals(other);

    public bool Equals(ItemSaveData p) => scene == p.scene && position == p.position && rotation == p.rotation && scale == p.scale;

    public override int GetHashCode() => (scene, position, rotation, scale).GetHashCode();

    public static bool operator ==(ItemSaveData lhs, ItemSaveData rhs) => lhs.Equals(rhs);

    public static bool operator !=(ItemSaveData lhs, ItemSaveData rhs) => !(lhs == rhs);
}
