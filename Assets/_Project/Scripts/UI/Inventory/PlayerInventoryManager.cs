using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    [SerializeField] private InventoryPanelManager inventoryPanel;

    [ReadOnly] [SerializeField] private List<Item> itemsList;

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
        itemsList = new Item[_playerInventorySize].ToList();
    }

    public void AddItem(int slotIndex, int itemID, int count = 1)
    {
        var item = new Item(itemID, count);
    
        itemsList[slotIndex] = item;
        inventoryPanel.RedrawSlot(slotIndex, item);
    }

    public void DeleteItem(int slotIndex)
    {
        itemsList[slotIndex] = null;
        inventoryPanel.RedrawSlot(slotIndex);
    }

    public void ChangeAnimalState(int slotIndex)
    {
        var item = itemsList[slotIndex];
        
        if (item is Animal animal)
        {
            if (animal.State == Animal.AnimalState.Normal) 
            animal.State = Animal.AnimalState.Wounded;
            
            else 
            animal.State = Animal.AnimalState.Normal;

            inventoryPanel.RedrawSlot(slotIndex, item);
        }

        else
        Debug.LogError("It's not Animal!");

    }

    
    
    
}

    
