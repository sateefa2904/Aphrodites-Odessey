using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color selectedColor;
    public Color notSelectedColor;

    private void Awake()
    {
        Deselect(); // Prevent console errors by applying default color
    }

    public void Select()
    {
        if (image != null)
        {
            image.color = selectedColor;
        }
        else
        {
            Debug.LogWarning($"{gameObject.name} is missing an Image reference in InventorySlot.");
        }
    }

    public void Deselect()
    {
        if (image != null)
        {
            image.color = notSelectedColor;
        }
        else
        {
            Debug.LogWarning($"{gameObject.name} is missing an Image reference in InventorySlot.");
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0 && eventData.pointerDrag != null)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            if (draggableItem != null)
            {
                draggableItem.parentAfterDrag = transform;
            }
        }
    }
}
