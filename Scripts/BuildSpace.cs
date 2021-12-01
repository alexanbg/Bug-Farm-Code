using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSpace : MonoBehaviour
{
    private bool isEmpty;

    public void Build(ShopItem item)
    {
        Instantiate(item.gameObject,transform);
    }
}
