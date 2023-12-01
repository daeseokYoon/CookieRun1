using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
   [SerializeField] Transform contentPos;
   [SerializeField] GameObject treasureSlot;
   //[SerializeField] List<TreasureSlot> slots = new List<TreasureSlot>();
   // public Button equipBtn;

    private void Start()
    {
        UI_DataManager.instance.LoadTreasureData();
        EventManager.instance.onSelectBtnClick = (id) =>
        {
            var data = UI_DataManager.instance.GetTreasureData(id);
            if (UserDataManager.Instance.GetHasTreasure(id) == 1)
                return;
            InventoryManager.Instance.AddSlot(data);
        };
        //InventoryManager.Instance.AddSlot(data);
    }

    public void EquipItem()
    {
        UI_DataManager.instance.LoadTreasureData();

        EventManager.instance.onSelectBtnClick = (id) =>
        {

        };
    }

}
