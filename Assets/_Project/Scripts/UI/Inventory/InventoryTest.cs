using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTest : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private PlayerInventoryManager playerInventoryManager;

    [Header("Input Fields")]
    [SerializeField] private TMP_InputField slotIndexField;
    [SerializeField] private TMP_InputField itemIDField;
    [SerializeField] private TMP_InputField itemCountField;

    private int slotIndex;
    private int itemID;
    private int itemCount;


    public void AddItem()
    {
        ReadFields();
        playerInventoryManager.AddItem(slotIndex, itemID, itemCount);
    }

    public void DeleteItem()
    {
        ReadFields();
        playerInventoryManager.DeleteItem(slotIndex);
    }

    public void ChangeAnimalState()
    {
        ReadFields();
        playerInventoryManager.ChangeAnimalState(slotIndex);
    }

    public void ReadFields()
    {
        slotIndex = int.Parse(slotIndexField.text);
        itemID = int.Parse(itemIDField.text);
        itemCount = int.Parse(itemCountField.text);
    }



}
