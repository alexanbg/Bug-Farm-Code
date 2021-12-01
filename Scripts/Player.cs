using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory(4);
    }
}
