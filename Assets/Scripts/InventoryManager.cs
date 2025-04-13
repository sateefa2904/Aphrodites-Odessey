using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int maxStackedItems = 100000;

    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    int selectedSlot = -1;

    public static InventoryManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ChangeSelectedSlot(0); // Start with the first slot selected
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeSelectedSlot(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeSelectedSlot(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeSelectedSlot(2);
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            ChangeSelectedSlot(3);
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            ChangeSelectedSlot(4);
    }

    void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlot >= 0 && selectedSlot < inventorySlots.Length)
        {
            if (inventorySlots[selectedSlot] != null)
                inventorySlots[selectedSlot].Deselect();
        }

        if (newValue >= 0 && newValue < inventorySlots.Length)
        {
            if (inventorySlots[newValue] != null)
                inventorySlots[newValue].Select();
            selectedSlot = newValue;
        }
        else
        {
            Debug.LogWarning("Invalid inventory slot index: " + newValue);
        }
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < maxStackedItems && itemInSlot.item.stackable == true)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;
    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        DraggableItem inventoryItem = newItemGo.GetComponent<DraggableItem>();
        inventoryItem.InitializeItem(item);
    }

    public Item GetSelectedItem(bool use)
    {
        if (selectedSlot < 0 || selectedSlot >= inventorySlots.Length)
            return null;

        InventorySlot slot = inventorySlots[selectedSlot];
        DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
        if (itemInSlot != null)
        {
            Item item = itemInSlot.item;
            if (use)
            {
                itemInSlot.count--;
                if (itemInSlot.count <= 0)
                {
                    Destroy(itemInSlot.gameObject);
                }
                else
                {
                    itemInSlot.RefreshCount();
                }
            }

            return item;
        }

        return null;
    }
}
