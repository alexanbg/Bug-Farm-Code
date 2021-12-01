using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Sign : MonoBehaviour
{
    [SerializeField]
    private string text;
    [SerializeField]


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "MainCharacter")
        {
            GameObject.Find("TextBox").GetComponent<TextMeshPro>().text = text;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "MainCharacter")
        {
            GameObject.Find("TextBox").GetComponent<TextMeshPro>().text = "";
        }
    }
}
