using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowBlock : MonoBehaviour, IPointerDownHandler,IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private float rotations = 0;
    [SerializeField]
    private float maxRayDistance = 100f;
    [SerializeField]
    public bool isBugged = false;
    [SerializeField]
    public bool isHit = false;
    [SerializeField]
    private GameObject laserParticles;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform laserFirePoint;
    private LineRenderer lineRenderer;
    private RaycastHit2D[] hits;
    private RaycastHit2D hit;
    private Vector2 direction;
    private GameObject laserEndPoint;
    public float timer;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        laserFirePoint = GetComponent<Transform>();
        lineRenderer = GetComponent<LineRenderer>();
        laserEndPoint = Instantiate(laserParticles, this.transform);
        

        switch (rotations)
        {
            case 0:
                direction = transform.up;
                break;
            case 1:
                direction = -transform.right;
                break;
            case 2:
                direction = -transform.up;
                break;
            case 3:
                direction = transform.right;
                break;

        }

    }

    //DRAG AND DROP
    //Call this function the first time you drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    //Call this function every frame you are dragging with the mouse
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
        
    }

    //Call this function when you release the mouse after dragging
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    //Call this function when you click on the object
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    //PROPERTIES
    private void Update()
    {
        if (isHit)
        {
            laserEndPoint.SetActive(true);
            hits = Physics2D.RaycastAll(laserFirePoint.position, isBugged?-direction : direction, maxRayDistance);
            if (hits.Length > 1)
            {
                hit = hits[1];
                if (hit.collider.gameObject.CompareTag("Receiver"))
                {
                    hit.collider.gameObject.GetComponent<Receiver>().isHit = true;
                    hit.collider.gameObject.GetComponent<Receiver>().timer = 10f;
                    Draw2dRay(laserFirePoint.position, hits[1].point);
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
            else
            {
                Draw2dRay(laserFirePoint.position, new Vector2(laserFirePoint.position.x,laserFirePoint.position.y) + (isBugged ? -direction : direction) * maxRayDistance);
            }
            timer--;
            if (timer == 0)
            {
                isHit = false;
            }
            
        }
        if (!isHit)
        {
            Draw2dRay(Vector2.zero, Vector2.zero);
            laserEndPoint.SetActive(false);
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
