using UnityEngine;
using UnityEngine.EventSystems;

public class DebugStation : MonoBehaviour, IDropHandler
{
    public bool hasBuggedBlock = false;
    public GameObject bug;
    public GameObject explosion;

    private GameObject attachedBlock = null;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            hasBuggedBlock = eventData.pointerDrag.GetComponent<ArrowBlock>().isBugged;
            attachedBlock = eventData.pointerDrag;
        }
    }

    public void BegginDebugging()
    {
        if (attachedBlock != null)
        {
            if (hasBuggedBlock)
            {
                bug.SetActive(true);
                Instantiate(explosion, transform);
            }

            Destroy(attachedBlock);

        }

    }
}
