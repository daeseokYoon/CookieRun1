using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UserDataManager : SingletonBehaviour<UserDataManager>
{
    [SerializeField] private int selectCookieID =100;  // ������ ��Ű�� ID �� 
    [SerializeField] private int selectPetID = 100;
    [SerializeField] private int selectTreasureID = 100;

    private Dictionary<int, int> HasCookieDic = new Dictionary<int, int>();
    private Dictionary<int, int> HasPetDic = new Dictionary<int, int>();
    private Dictionary<int, int> HasTreasure = new Dictionary<int, int>(); 
    // ���� ����, ���ο� �� �ִ��� �Ǵ� // ��ȸ ��� ���δ� ���� �������ϳ�?

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
        return 0; //�⺻ ���� 0
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
        return 0; //�⺻ ���� 0
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
    public void TreasureDicInit() // �̳༮�� �ʱ�ȭ ���ִ� �� ����?
    {
        UI_DataManager.instance.LoadTreasureData();
        HasTreasure.Clear(); // ������ �ΰ��� �����ϴ� �Ŵ����ε� ���� clear��?// �Դٰ� ������ �ȵ�
        foreach (var data in UI_DataManager.instance.GetTreasureDatas())
        {
            if (data.id == 100)  
            {
                HasTreasure.Add(data.id, 1); // 1�̸� �˾�
            }
            else
            {
                HasTreasure.Add(data.id, 1); // �ƹ�ư ������Ѽ� ��ȣ�� ���� �����ǰ� �� ������
                                             // �ѹ� ������ �Ϸ�Ǹ� 0���� �ٲ㼭 �ٽ� ���� ���ϰ� �Ұ���
            }
        }
    }

    public void SetHasTreasure(int key, bool hasTreasure)
        // ������ ������Ʈ�ϱ� ���ؼ� ���
        // value�� 0���� ����Ǿ� �ִ� key���� �Ķ���Ϳ� true�� �������μ� 
        // 0�̾��� value�� 1�� �ٲ��ش�.
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
        return 0; //�⺻ ���� 0
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
