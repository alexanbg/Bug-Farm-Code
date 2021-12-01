using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    
    private Player player;
    private ShopItem shopItem;
    
    private NameSpritePair pair;

    private void Awake()
    {
        player = GameObject.Find("MainCharacter").GetComponent<Player>();
        pair = GameObject.Find("NameSpritePair").GetComponent<NameSpritePair>();
        shopItem = GetComponent<ShopItem>();
    }
    // Start is called before the first frame update
    
    public void DestroyBoulder()
    {
        Debug.Log("Initiate parameters");
        string[] names = shopItem.names;
        int[] quantities = shopItem.quantities;
        bool canBuyItem = true;
        List<Item> listOfItems = new List<Item>();
        Debug.Log("Begin Loop");
        for (int i = 0; i < names.Length; i++)
        {
            listOfItems.Add(new Item(names[i], pair.pairs[names[i]]));
            if (!player.inventory.CheckItem(new Item(names[i], pair.pairs[names[i]]), quantities[i]))
            {
                canBuyItem = false;
                Debug.Log("Doesn't have enough");
            }
        }

        if (canBuyItem)
        {
            Debug.Log("Has enough");
            //Take items
            for (int i = 0; i < listOfItems.Count; i++)
            {
                player.inventory.UseItem(listOfItems[i], quantities[i]);
                Debug.Log("Item Taken");
            }
            //Build Item
            Destroy(gameObject);
        }
        
    }
}
