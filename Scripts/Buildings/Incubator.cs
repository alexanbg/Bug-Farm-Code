using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Incubator : MonoBehaviour
{
    [SerializeField]
    private string bugType;
    [SerializeField]
    private string productType;
    
    
    [SerializeField]
    private float productionSpeed;
    [SerializeField]
    private GameObject _UI;
    [SerializeField]
    private Text percentage;
    [SerializeField]
    private Text producedItems;
    [SerializeField]
    private Text bugsInTheIncubator;

    public Player player;
    private NameSpritePair pairer;
    private int numberOfBugs;
    private float productProduced = 1;
    
    

    public void Awake()
    {
        numberOfBugs = 0;
        productProduced = 25;
        player = GameObject.Find("MainCharacter").GetComponent<Player>();
        pairer = GameObject.Find("NameSpritePair").GetComponent<NameSpritePair>();
    }

    public void Update()
    {
        //1 product per minute = 1 bugs * 1 productionSpeed / 60*60
        productProduced += numberOfBugs * productionSpeed / 3600;

        percentage.text = $"{Mathf.FloorToInt((productProduced % 1) * 100)}%";
        producedItems.text = $"Produced items: {Mathf.FloorToInt(productProduced)}";
        bugsInTheIncubator.text = $"Bugs: {numberOfBugs}";
    }

    public void AddBug()
    {
        if(player.inventory.CheckItem(new Item(bugType, pairer.pairs[bugType]), 1))
        {
            numberOfBugs++;
            player.inventory.UseItem(new Item(bugType, pairer.pairs[bugType]), 1);
        }

    }
    public void Collect()
    {
        if (player.inventory.CheckFreeSpace())
        {
            player.inventory.AddItem(new Item(productType, pairer.pairs[productType]), Mathf.FloorToInt(productProduced));
            productProduced -= Mathf.FloorToInt(productProduced);
        }
    }
    public void EnterIncubator()
    {
        _UI.SetActive(true);
        player.GetComponent<Movement>().canMove = false;
    }
    public void ExitIncubator()
    {
        _UI.SetActive(false);
        player.GetComponent<Movement>().canMove = true;
    }
}
