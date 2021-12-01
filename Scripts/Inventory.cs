using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory //: MonoBehaviour
{
    private Dictionary<Item,int> Items;
    private List<Item> ItemTypes;

    private int Size;
    public Inventory(int size)
    {
        Items = new Dictionary<Item, int>();
        ItemTypes = new List<Item>();
        Size = size;
    }

    

    public void AddItem(Item item, int cuantity)
    {
        if (Items.ContainsKey(item))
        {
            Items[item] += cuantity;
            Debug.Log("The number of red bugs was increased");

        }
        else
        {
            if (CheckFreeSpace())
            {
                Items.Add(item, cuantity);
                ItemTypes.Add(item);
                Debug.Log(item.ToString());
                
            }
            
        }
    }

    public bool CheckFreeSpace()
    {
        return Items.Count < Size;
    }

    public bool UseItem(Item item, int cuantity) {
        if (Items.ContainsKey(item))
        {
            if (Items[item] >= cuantity)
            {
                Items[item] = Items[item] - cuantity;
                if (Items[item] == 0)
                {
                    Items.Remove(item);
                    ItemTypes.Remove(item);
                }
                return true;
            }
            else
            {
                return false;
            }
            
        }
        else
        {
            return false;
        }

    }
    public bool CheckItem(Item item, int cuantity)
    {
        if (Items.ContainsKey(item))
        {
            if (Items[item] >= cuantity)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        else
        {
            return false;
        }

    }

    public Item GetItemAtSlot(int index)
    {
        if (index<ItemTypes.Count)
        {
            return ItemTypes[index];
        }
        else
        {
            return new Item("Empty Slot", null);
        }
    }
    public int GetQuantityOfAnItem(Item item)
    {
        if(item.Name!="Empty Slot")
        {
            return Items[item];
        }
        else
        {
            return 0;
        }
        
    }
}
