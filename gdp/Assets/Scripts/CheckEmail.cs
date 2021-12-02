using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckEmail : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerUpHandler
{
    // this script is to put on the "send/trash" button which you drag to the trash or the send
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    Vector3 initial;
    public Vector3 resetPos;
    public bool droppedOnSlot, // If button dropped on anything
        gotVirus; // for email
    Vector2 width;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        ResetPos();
    }
    private void Start()
    {
        ResetPos();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //rectTransform.sizeDelta = new Vector2(150, width.y);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rectTransform.sizeDelta = width;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        // Button go back to initial spot if not 
        if(droppedOnSlot == false)
        {
            transform.position = initial;
        }
        rectTransform.sizeDelta = width;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        eventData.pointerDrag.GetComponent<CheckEmail>().droppedOnSlot = false;
    }

    public void ResetPos()
    {
        transform.localPosition = resetPos;
        initial = transform.position;
        width = new Vector2(692f, 41f);
        rectTransform.sizeDelta = width;
    }
}
