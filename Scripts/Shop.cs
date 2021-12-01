using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    public Player player;

    [SerializeField]
    private NameSpritePair pair;

    [SerializeField]
    private BuildSpace[] buildSpaces;

    public void Buy(ShopItem shopItem)
    {
        string[] names = shopItem.names;
        int[] quantities = shopItem.quantities;
        bool canBuyItem = true;
        List<Item> listOfItems = new List<Item>();
        for (int i=0; i < names.Length; i++)
        {
            listOfItems.Add(new Item(names[i], pair.pairs[names[i]]));
            if (!player.inventory.CheckItem(new Item(names[i], pair.pairs[names[i]]), quantities[i]))
            {
                canBuyItem = false;
                Debug.Log("Can't buy item");
            }
        }
        
        if (canBuyItem)
        {
            Debug.Log("Item Bought");
            //Take items
            for(int i=0;i<listOfItems.Count;i++)
            {
                player.inventory.UseItem(listOfItems[i], quantities[i]);
            }
            //Build Item
            buildSpaces[0].Build(shopItem);
        }
    }

}
