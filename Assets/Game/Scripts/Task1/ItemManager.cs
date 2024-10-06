using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private float destroyPosX = -100f;
    [SerializeField] private float speed = 10;
    [SerializeField] private int numberOfItems = 5;

    private List<string> _deletedItemList = new List<string>();

    void Start()
    {
        for (int i = 0; i < numberOfItems; i++)
        {
            CreateItem();
        }
    }

    void CreateItem()
    {
        GameObject newItem = Instantiate(itemPrefab, transform);
        Item itemScript = newItem.GetComponent<Item>();
        itemScript.Initialize(this);
    }

    public void DeleteItem(GameObject item)
    {
        RectTransform rt = item.GetComponent<RectTransform>();
        rt.DOAnchorPosX(destroyPosX, 1/speed).SetEase(Ease.InBack).OnComplete(() => {
            _deletedItemList.Add(item.GetComponent<Item>().GetItemName());
            Destroy(item);
            SaveDestroyedItemData();
        });
    }

    void SaveDestroyedItemData()
    {
        PlayerPrefs.SetString("SavedItems", string.Join(",", _deletedItemList));
        PlayerPrefs.Save();
        
        Debug.Log("DestroyedItemData = " + PlayerPrefs.GetString("SavedItems"));
    }
}