using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _2DPositionHandler : MonoBehaviour
{
    private SpriteRenderer sprenderer;
    private void Awake()
    {
        sprenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        sprenderer.sortingOrder = -Mathf.FloorToInt(transform.position.y*10);
    }
}
