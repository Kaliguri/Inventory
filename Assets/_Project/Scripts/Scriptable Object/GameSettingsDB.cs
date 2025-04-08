using UnityEngine;

[CreateAssetMenu(fileName = "Game Settings DB", menuName = "InventoryGame/Settings/Game Settings")]
public class GameSettingsDB : ScriptableObject
{
    [Header("Inventory")]
    
    [Tooltip("Maximum size of the player's inventory")]
    [SerializeField] private int _playerInventorySize = 20;

    public int PlayerInventorySize => _playerInventorySize;
}