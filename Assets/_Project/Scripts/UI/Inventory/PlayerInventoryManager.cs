using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    [SerializeField] private InventoryPanelManager inventoryPanel;

    [ReadOnly] private List<Item> ItemsList;

    private int _playerInventorySize;
    void Start()
    {
        LoadSettings();
        FillItemList();

        inventoryPanel.CreateInventorySlots(_playerInventorySize);
    }

    void LoadSettings()
    {
        _playerInventorySize = DBContainer.Instance.GameSettings.PlayerInventorySize;
    }

    void FillItemList()
    {
        ItemsList = new List<Item>(_playerInventorySize); 
    }

    public void AddItem(int slotIndex, int itemID, int count = 1)
    {
        var item = new Item(itemID, count);
    
        ItemsList[slotIndex] = item;
        
        inventoryPanel.RedrawSlot(slotIndex, item);
    }

    public void DeleteItem(int slotIndex)
    {
        inventoryPanel.RedrawSlot(slotIndex);
    }

    public void ChangeStatusAnimal(int slotIndex, Animal.AnimalState state)
    {
        var item = ItemsList[slotIndex];
        
        if (item is Animal animal)
        {
            animal.State = state;
            inventoryPanel.RedrawSlot(slotIndex, item);
        }

        else
        Debug.LogError("It's not Animal!");

    }

    
    
    
}

    
