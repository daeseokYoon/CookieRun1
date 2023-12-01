using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UserDataManager : SingletonBehaviour<UserDataManager>
{
    [SerializeField] private int selectCookieID =100;  // 선택한 쿠키의 ID 값 
    [SerializeField] private int selectPetID = 100;
    [SerializeField] private int selectTreasureID = 100;

    private Dictionary<int, int> HasCookieDic = new Dictionary<int, int>();
    private Dictionary<int, int> HasPetDic = new Dictionary<int, int>();
    private Dictionary<int, int> HasTreasure = new Dictionary<int, int>(); 
    // 가방 역할, 내부에 뭐 있는지 판단 // 초회 얻는 여부는 따로 만들어야하나?

    private void Awake()
    {
        base.Awake();
        CookieDicInit();
        PetDicInit();
        TreasureDicInit();
    }

    private void Start()
    {
  
    }
    #region Cookie
    public void CookieDicInit()
    {
        UI_DataManager.instance.LoadCookiesData();
        HasCookieDic.Clear();
        foreach (var data in UI_DataManager.instance.GetMycookiesDatas())
        {
            if (data.id == 100)
            {
                HasCookieDic.Add(data.id, 1); 
            }
            else
            {
                HasCookieDic.Add(data.id, 0);
            }
        }
    }

    public void SetHasCookie(int key, bool hasCookie) 
    {
        if (HasCookieDic.ContainsKey(key))
        {
            HasCookieDic[key] = hasCookie ? 1 : 0;
        }
        return;
    }

    public int GetHasCookie(int key)
    {
        if (HasCookieDic.ContainsKey(key))
        {
            return HasCookieDic[key];
        }
        return 0; //기본 값은 0
    }

    public void SetSelectCookieID(int id)
    {
        selectCookieID = id;  
    }
    public int GetSelectCookieID()
    {
        return selectCookieID;
    }
    #endregion

    #region Pet
    public void PetDicInit()
    {
        UI_DataManager.instance.LoadPetsData();
        HasPetDic.Clear();
        foreach (var data in UI_DataManager.instance.GetMypetsDatas())
        {
            if (data.id == 100)
            {
                HasPetDic.Add(data.id, 1);
            }
            else
            {
                HasPetDic.Add(data.id, 0);

            }
        }
    }

    public void SetHasPet(int key, bool hasPet)
    {
        if (HasPetDic.ContainsKey(key))
        {
            HasPetDic[key] = hasPet ? 1 : 0;
        }
        return;
    }

    public int GetHasPet(int key)
    {
        if (HasPetDic.ContainsKey(key))
        {
            return HasPetDic[key];
        }
        return 0; //기본 값은 0
    }

    public void SetSelectPetID(int id)
    {
        selectPetID = id;
    }
    public int GetSelectPetID()
    {
        return selectPetID;
    }
    #endregion
    public void TreasureDicInit() // 이녀석을 초기화 해주는 걸 생각?
    {
        UI_DataManager.instance.LoadTreasureData();
        HasTreasure.Clear(); // 어차피 로고에서 시작하는 매니저인데 굳이 clear를?// 게다가 삭제도 안됨
        foreach (var data in UI_DataManager.instance.GetTreasureDatas())
        {
            if (data.id == 100)  
            {
                HasTreasure.Add(data.id, 1); // 1이면 팝업
            }
            else
            {
                HasTreasure.Add(data.id, 1); // 아무튼 저장시켜서 번호에 따라서 생성되게 한 다음에
                                             // 한번 생성이 완료되면 0으로 바꿔서 다시 생성 못하게 할거임
            }
        }
    }

    public void SetHasTreasure(int key, bool hasTreasure)
        // 정보를 업데이트하기 위해서 사용
        // value가 0으로 저장되어 있는 key값을 파라메터에 true로 써줌으로서 
        // 0이었던 value를 1로 바꿔준다.
    {
        if (HasTreasure.ContainsKey(key))
        {
            HasTreasure[key] = hasTreasure ? 1 : 0;
        }
        return;
    }

    public int GetHasTreasure(int key)
    {
        if (HasTreasure.ContainsKey(key))
        {
            return HasTreasure[key];
        }
        return 0; //기본 값은 0
    }

    public void SetSelectTreasureID(int id)
    {
        selectTreasureID = id;
        if(!HasTreasure.ContainsKey(id))
        HasTreasure.Add(id, 1);
    }
    public int GetSelectTreasureID()
    {
        return selectTreasureID;
    }
}
