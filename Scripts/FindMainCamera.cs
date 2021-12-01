using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMainCamera : MonoBehaviour
{

    private void Awake()
    {
       GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

}
