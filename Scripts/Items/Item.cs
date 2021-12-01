using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item //: MonoBehaviour
{
    public string Name;
    
    public Sprite Image;
    
    public Item(string name, Sprite image)
    {
        Name = name;
        Image = image;
    }

    public override int GetHashCode()
    {
        if (Name == null) return 0;
        return Name.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        Item other = obj as Item;
        return other != null && other.Name == this.Name;
    }
}
