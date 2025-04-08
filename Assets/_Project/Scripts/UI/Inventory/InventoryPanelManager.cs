using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanelManager : MonoBehaviour
{
    [SerializeField] private Transform slotParentObject;
    [SerializeField] private GameObject itemSlotPrefab;


    private List<GameObject> slotObjectList;
    public void CreateInventorySlots(int slotNumber)
    {
        for (int i = 0; i < slotNumber; i++)
        {
            GameObject slot = Instantiate(itemSlotPrefab, slotParentObject);
            slotObjectList.Add(slot);
        }
    }

    public void RedrawInventory(List<Item> ItemsList)
    {
        for (int i = 0; i < slotObjectList.Count; i++)
        {
            var slot = slotObjectList[i].GetComponent<InventorySlot>();
            slot.ChangeSlot(ItemsList[i]);
        }
    }

    public void RedrawSlot(int slotIndex, Item item = null)
    {
        var slot = slotObjectList[slotIndex].GetComponent<InventorySlot>();
        slot.ChangeSlot(item);
    }
}
