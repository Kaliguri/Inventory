using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [Header("Gameobject's Reference")]
    [SerializeField] private Image Icon;
    [SerializeField] private TextMeshProUGUI StackText;
    [SerializeField] private Image AnimalStateImage;

    [Header("Settings")]
    [SerializeField] private Color AnimalNormalStateColor;
    [SerializeField] private Color AnimalWoundedStateColor;

    public void ChangeSlot(Item item = null)
    {
        if (item == null) 
        ClearSlot();

        else
        FillSlot(item);
    
    }

    void ClearSlot()
    {
        Icon.gameObject.SetActive(false);
        StackText.gameObject.SetActive(false);

        AnimalStateImage.gameObject.SetActive(false);
    }


    void FillSlot(Item item)
    {
        var itemDB = DBContainer.Instance.ItemDB;
        var itemData = itemDB.GetItemByID(item.ID);

        Icon.gameObject.SetActive(false);
        Icon.sprite = itemData.Icon;

        StackText.gameObject.SetActive(false);
        StackText.text = itemData.MaxStackSize.ToString();

        if (item is Animal animal) 
        {
            AnimalStateImage.gameObject.SetActive(true);
            SwapAnimalStateColor(animal);
        }

    }

    void SwapAnimalStateColor(Animal animal)
    {        ;
        if (animal.State == Animal.AnimalState.Normal)
        AnimalStateImage.color = AnimalNormalStateColor;

        else if (animal.State == Animal.AnimalState.Wounded)
        AnimalStateImage.color = AnimalWoundedStateColor;
    }


}
