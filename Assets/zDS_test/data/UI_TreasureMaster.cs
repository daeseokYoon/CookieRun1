using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TreasureMaster : MonoBehaviour
{
    [SerializeField] UI_TreasurePopUp uI_TreasurePopUp;

    public void Initialize() //��ȭ, �Ǹ޴�, ��ũ�Ѻ� ��� �ʱ�ȭ
    {
        //UI_DataManager.instance.LoadTreasureData();
        //var C_id = UserDataManager.Instance.GetSelectCookieID();
        //UserDataManager.Instance.SetSelectTreasureID(C_id);
        var id = UserDataManager.Instance.GetSelectTreasureID();
        
        //��ũ�Ѻ� �ʱ�ȭ
        uI_TreasurePopUp.Initialize(id); 
    }
    // ���� ���ӿ�����Ʈ�� �ϳ� �� �������ϴ� ���ΰ�?
}
