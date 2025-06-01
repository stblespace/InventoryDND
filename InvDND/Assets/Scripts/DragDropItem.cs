using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDropItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform originalParent;
    private CanvasGroup canvasGroup;
    private LayoutElement layoutElement;
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            canvasGroup = GetComponent<CanvasGroup>() ?? gameObject.AddComponent<CanvasGroup>();
            layoutElement = GetComponent<LayoutElement>() ?? gameObject.AddComponent<LayoutElement>();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(transform.root);
        canvasGroup.blocksRaycasts = false;
        layoutElement.ignoreLayout = true;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        layoutElement.ignoreLayout = false;

        GameObject target = eventData.pointerCurrentRaycast.gameObject;

        if (target != null && target.CompareTag("Slot"))
        {
            transform.SetParent(target.transform);
        }
        else
        {
            GameObject[] slots = GameObject.FindGameObjectsWithTag("Slot");
            float minDistance = float.MaxValue;
            GameObject nearestSlot = null;

            foreach(var slot in slots)
            {
                float distance = Vector2.Distance(transform.position, slot.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestSlot = slot;
                }
            }

            if (nearestSlot != null && minDistance < 100f)
            {
                transform.SetParent(nearestSlot.transform);
            }
            else
            {
                transform.SetParent(originalParent);
            }
        }
        transform.localPosition = Vector3.zero;
    }
}
