using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameSpritePair : MonoBehaviour
{
    [SerializeField]
    private string[] names;
    [SerializeField]
    private Sprite[] sprites;
    
    public Dictionary<string, Sprite> pairs;

    private void Awake()
    {
        pairs = new Dictionary<string, Sprite>();
        for(int i=0; i < names.Length; i++)
        {
            pairs.Add(names[i], sprites[i]);
        }
    }

}
