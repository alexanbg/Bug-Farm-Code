using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField]
    public string[] names;
    [SerializeField]
    public int[] quantities;
    [SerializeField]
    private NameSpritePair pair;


    /*public Dictionary<Item, int> GetRequirements()
    {
        Dictionary<Item, int> requirements = new Dictionary<Item, int>();
        for (int i = 0; i < names.Length; i++)
        {
            Item item = new Item(names[i], pair.pairs[names[i]]);
            requirements.Add(item, quantities[i]);
        }

        return requirements;
    }
    */
}
