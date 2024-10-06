using TMPro;
using UnityEngine;


public class Item : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    private ItemManager _itemManager;

    public void Initialize(ItemManager itemManager)
    {
        _itemManager = itemManager;
        nameText.text = GenerateRandomName();
    }

    public void OnClickCrossButton()
    {
        _itemManager.DeleteItem(this.gameObject);
    }

    private string GenerateRandomName()
    {
        string[] names = new string[]
        {
            "Jack", "Baki", "Jotoro",
            "Dio", "Guts", "Johny", "Gon",
            "Killua", "Hisoka", "Kurapika", "Johan",
            "Ken", "Saitama", "Genos", "Mob", "Reigen", "Ritsu", "Teru", "Shigeo", "Fubuki", "King",
            "Bang", "Atomic", "Child", "Metal"
        };
        
        return names[Random.Range(0, names.Length)];
    }

    public string GetItemName()
    {
        return nameText.text;
    }
}