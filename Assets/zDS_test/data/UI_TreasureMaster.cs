using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TreasureMaster : MonoBehaviour
{
    [SerializeField] UI_TreasurePopUp uI_TreasurePopUp;

    public void Initialize() //재화, 탭메뉴, 스크롤뷰 등등 초기화
    {
        //UI_DataManager.instance.LoadTreasureData();
        //var C_id = UserDataManager.Instance.GetSelectCookieID();
        //UserDataManager.Instance.SetSelectTreasureID(C_id);
        var id = UserDataManager.Instance.GetSelectTreasureID();
        
        //스크롤뷰 초기화
        uI_TreasurePopUp.Initialize(id); 
    }
    // 상위 게임오브젝트를 하나 더 만들어야하는 것인가?
}
