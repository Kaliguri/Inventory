using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory Game/Inventory/Item")]
public class ItemData : ScriptableObject
{
    [SerializeField] private int _id;
    
    [SerializeField] private ItemType _itemType;
    [SerializeField] private Sprite _icon;


    [Tooltip("The maximum amount of inventory in one slot")]
    [SerializeField] private int _maxStackSize;
    
    [SerializeField] private string _name;

    public int ID => _id;
    public ItemType Type => _itemType;
    public Sprite Icon => _icon;
    public int MaxStackSize => _maxStackSize;
    public string Name => _name;

    public enum ItemType
    {
        Animal,
        Resource,
        Consumable
    }
}