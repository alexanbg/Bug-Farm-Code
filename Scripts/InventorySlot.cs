using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    //[SerializeField]
    
    [SerializeField]
    private Sprite emptySprite;

    private Text quantity;
    private Image image;
    [HideInInspector]
    public Player player;

    private void Awake()
    {
        image = GetComponent<Image>();
        quantity = GetComponentInChildren<Text>();
        player = GameObject.Find("MainCharacter").GetComponent<Player>();
    }

    private void Update()
    {
        Item item = player.inventory.GetItemAtSlot(int.Parse(gameObject.name));
        if (item.Name =="Empty Slot")
        {
            image.sprite = emptySprite;
            quantity.text = "";
            
        }
        else
        {
            image.sprite = item.Image;
            quantity.text = $"{player.inventory.GetQuantityOfAnItem(item)}";
        }
        
    }
}
