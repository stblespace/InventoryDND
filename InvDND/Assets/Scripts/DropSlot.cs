using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public TMP_Text count_text;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;

        if (droppedObject != null )
        {
            ItemData droppedData = droppedObject.GetComponent<ItemData>();
            ItemData slotData = GetComponentInChildren<ItemData>();

            Transform oldParent = droppedData.transform.parent;
            Transform oldSlot = droppedData.originalParent;

            if (slotData == null)
            {
                droppedObject.transform.SetParent(transform);
                droppedObject.transform.localPosition = Vector3.zero;
                droppedData.UpdateCount(droppedData.ItemCount);
            }
            else if(slotData != null && droppedData.ItemID == slotData.ItemID)
            {
                int newCount = slotData.ItemCount + droppedData.ItemCount;
                slotData.UpdateCount(newCount);
                Destroy(droppedObject);
            }
            else
            {

                droppedData.transform.SetParent(transform);
                droppedData.transform.localPosition = Vector3.zero;

                slotData.transform.SetParent(oldSlot);
                slotData.transform.localPosition = Vector3.zero;    

            }

            
        }
    }


}
