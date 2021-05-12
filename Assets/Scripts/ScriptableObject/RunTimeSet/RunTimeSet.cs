using System.Collections.Generic;
using UnityEngine;

public class RunTimeSet<T> : ScriptableObject
{
    private List<T> items = new List<T>();


    public void Init()
    {
        items.Clear();
    }

    public T GetItem(int index)
    {
        return items[index];
    }

    public void AddItem(T itemToAdd)
    {
        if (!items.Contains(itemToAdd))
        {
            items.Add(itemToAdd);
        }
    }

    public void RemoveItem(T itemToRemove)
    {
        if (items.Contains(itemToRemove))
        {
            items.Remove(itemToRemove);
        }
    }



}

