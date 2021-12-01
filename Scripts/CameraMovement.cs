using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float offset;

    private Vector3 playerPosition;
    private Transform cameraTransform;

    private void Awake()
    {
        cameraTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        playerPosition = Camera.main.WorldToViewportPoint(player.position);

        if (playerPosition.x > 1 - offset)
        {
            //move right
            cameraTransform.position += new Vector3(17.5f + 3 * offset,0,0);
        }
        if (playerPosition.x < 0 + offset)
        {
            //move left
            cameraTransform.position -= new Vector3(17.5f - 3 * offset, 0, 0);
        }
        if (playerPosition.y > 1 - offset)
        {
            //move up
            cameraTransform.position += new Vector3(0, 9.5f + 3 * offset, 0);
        }
        if (playerPosition.y < 0 + offset)
        {
            //move down
            cameraTransform.position -= new Vector3(0, 9.5f - 3 * offset, 0);
        }
    }

    


}
