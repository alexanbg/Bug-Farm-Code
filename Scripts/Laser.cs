using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float maxRayDistance = 100f;
    [SerializeField]
    private GameObject laserParticles;

    private Transform laserFirePoint;
    private LineRenderer lineRenderer;
    private RaycastHit2D hit;
    private GameObject laserEndPoint;
    private void Awake()
    {
        laserFirePoint = GetComponent<Transform>();
        lineRenderer = GetComponent<LineRenderer>();
        laserEndPoint = Instantiate(laserParticles, this.transform);
    }

    private void Update()
    {
        //Check for objects in front:
        //There're objects
        if (Physics2D.Raycast(laserFirePoint.position, transform.up))
        {
            hit = Physics2D.Raycast(laserFirePoint.position, transform.up);
            //If the object is receiver, activate it
            if (hit.collider.gameObject.CompareTag("Receiver"))
            {
                hit.collider.gameObject.GetComponent<Receiver>().isHit = true;
                hit.collider.gameObject.GetComponent<Receiver>().timer = 10f;
                Draw2dRay(laserFirePoint.position, hit.point);
            }
            else if (hit.collider.gameObject.CompareTag("ArrowStone"))//If the object is block, activate and time it
            {
                hit.collider.gameObject.GetComponent<ArrowBlock>().isHit = true;
                hit.collider.gameObject.GetComponent<ArrowBlock>().timer = 10f;
                Draw2dRay(laserFirePoint.position, hit.point);
            }
            else
            {
                Draw2dRay(laserFirePoint.position, hit.point);
            }
        }
        else //There're no objects
        {          
            Draw2dRay(laserFirePoint.position, laserFirePoint.position + transform.up * maxRayDistance);
        }
        
    }

    private void Draw2dRay(Vector2 startPos, Vector2 endPos)
    {
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
        laserEndPoint.transform.position = endPos;
        laserEndPoint.transform.LookAt(startPos);
    }
}
