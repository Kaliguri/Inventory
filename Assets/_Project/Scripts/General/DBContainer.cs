using UnityEngine;

public class DBContainer : MonoBehaviour
{
    [SerializeField] private GameSettingsDB _gameSettings;
    [SerializeField] private ItemDB _itemDB;

    
    public GameSettingsDB GameSettings => _gameSettings;
    public ItemDB ItemDB => _itemDB;


    private static DBContainer _instance;
    public static DBContainer Instance => _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }

        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}