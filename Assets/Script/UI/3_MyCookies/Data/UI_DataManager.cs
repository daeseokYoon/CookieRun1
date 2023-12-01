using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;

public class UI_DataManager //code by. ����
{
    // readonly�� instance ����θ� ��밡��
    public static readonly UI_DataManager instance = new UI_DataManager();

    //arrMycookiesDatas�� key(id)-value�� �Ǿ��־ Dictionary �÷��� ���
    private Dictionary<int, MycookiesData> dicMycookiesData;// = new Dictionary<int, MycookiesData>(); -> using System.Linq�� ����ؼ� �ʱ�ȭ �ʿ����
    private Dictionary<int, MyPetsData> dicPetsData;
    private Dictionary<int, TreasureData> treasureData;
    // json�� �ִ� ������ ��Ƶ� Dictionary // ���⼭ Ư�� ���� �ҷ����� 
    // ������ ���� ���� ���� ����� Ű���� �̿��ؼ� Ư�� value�� �ҷ��� �� ����

    private UI_DataManager() { }
    
    public MycookiesData GetCookiesData(int id)
    {
        return dicMycookiesData[id];
    }

    public MyPetsData GetPetsData(int id)
    {
        return dicPetsData[id];
    }

    public TreasureData GetTreasureData(int id)
    { // ��ųʸ� Ȱ��
        return treasureData[id];
    }
    public void LoadCookiesData()
    {
        //TextAsset�� �ε�(Resources����-data����-Mycookies_data������ Load)
        TextAsset asset = Resources.Load<TextAsset>("data/MyCookies_data");
        //asset�� ���ڿ� ���
        var json = asset.text;

        //������ȭ
        MycookiesData[] arrMycookiesDatas = JsonConvert.DeserializeObject<MycookiesData[]>(json);

        //key�� id�� �ؼ� ���ο� ���� ��ü�� �����Ǿ� ��ȯ��(for������ dicMycookiesData(data.id, data)���� �Ͱ� ���� ���)
        dicMycookiesData = arrMycookiesDatas.ToDictionary(x => x.id); 
    }

    public void LoadPetsData()
    {
        TextAsset asset = Resources.Load<TextAsset>("data/MyPets_data");
        var json = asset.text;
        MyPetsData[] arrMypetsDatas = JsonConvert.DeserializeObject<MyPetsData[]>(json);
        dicPetsData = arrMypetsDatas.ToDictionary(x => x.id);

        Debug.LogFormat("shop data loaded:{0}", dicPetsData.Count);
    }

    public void LoadTreasureData()
    {
        TextAsset asset = Resources.Load<TextAsset>("data/MyTreasure_data");
        var json = asset.text;
        // TextAsset�� int, string �� �־ var
        TreasureData[] myTreasureDatas = JsonConvert.DeserializeObject<TreasureData[]>(json);
        // ������ȭ JsonConvert.DeserializeObject<����>(�Է�);
        treasureData = myTreasureDatas.ToDictionary(x => x.id); 
        // ���Ǻ��� x�� ToDictionary�� Key�� // Ű���� dictionary�� id ��
    }

    //dicMycookiesData�� Values�� List�� ��ȯ
    public List<MycookiesData> GetMycookiesDatas()
    {
        return dicMycookiesData.Values.ToList();
    }

    //public Dictionary<int, MycookiesData> GetMyCookiesData()
    //{
    //    return dicMycookiesData;
    //}

    //dicPetsData Values�� List�� ��ȯ
    public List<MyPetsData> GetMypetsDatas()
    {
        return dicPetsData.Values.ToList();
    }

    //public Dictionary<int, MyPetsData> GetMypetsData()
    //{
    //    return dicPetsData;
    //}

    public List<TreasureData> GetTreasureDatas()
    {
        return treasureData.Values.ToList(); 
        // Values : dictionary�� ��� ���� �ҷ���. (Key������ ����� ��) 
        // ToList() : ������ ������ List�� �����. 
    }

    //public Dictionary<int, TreasureData> GetMytreasureData() 
    // ��ųʸ��� �� ���� �־����� List�� �ҷ����� �Լ����� �־ �׳� ���� ������ ���
    //{
    //    return treasureData;
    //}
}