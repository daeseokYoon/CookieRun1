using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [SerializeField] Transform contentPos;
    [SerializeField] GameObject treasureSlot;
    [SerializeField] List<TreasureSlot> slots = new List<TreasureSlot>();
    

    //public InventoryItemController[] InventoryItems;

    private void Awake()
    {
        Instance = this;
    }

    public void Initialize(int id) // �̰� �Ⱦ�����?
    {
        TreasureData data = UI_DataManager.instance.GetTreasureData(id);

        switch (data.id)
        {
            case 100:
                AddSlot(data);
                break;
            case 101:
                AddSlot(data); 
                break;
            case 102:
                AddSlot(data); 
                break;
            case 103:
                AddSlot(data); 
                break;
            case 104:
                AddSlot(data); 
                break;
            default: 
                break;
        }
    }

    public void AddSlot(TreasureData data)
    {
        TreasureSlot slot = slots.Find(item => item.GetID() == data.id);

        if (UserDataManager.Instance.GetHasTreasure(data.id) == 0)
        // 1�̸� ���ʿ� ���â���� �̺�Ʈ���� �ѹ��� �Ѿ���� ������ �ٸ� ���� �Ƚ���.
        {
            var go = Instantiate(treasureSlot, contentPos);
            TreasureSlot treasureInfo = go.GetComponent<TreasureSlot>();
            slot.Initialize(UI_DataManager.instance.GetTreasureData(data.id));
            //UserDataManager.Instance.SetHasTreasure(data.id, false);

            slot.equipBtn.onClick.AddListener(() =>
            {
                EventManager.instance.onSelectBtnClick(slot.GetID());
            });
        }
    }

    

    public void RemoveItem()
    {

    }

    //public void ListItems()
    //{
    //    foreach (Transform item in ItemContent)
    //    {
    //        Destroy(item.gameObject);
    //    }

    //    foreach (var item in Items)
    //    {
    //        GameObject obj = Instantiate(InventoryItem, ItemContent);
    //        var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
    //        var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

    //        itemName.text = item.itemName;
    //        itemIcon.sprite = item.icon;
    //    }

    //    SetInventoryItems();
    //}

    //public void SetInventoryItems()
    //{
    //    InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

    //    for (int i = 0; i < Items.Count; i++)
    //    {
    //        InventoryItems[i].AddItem(Items[i]);
    //    }
    //}
}
