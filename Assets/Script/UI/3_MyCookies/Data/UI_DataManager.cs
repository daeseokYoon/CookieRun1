using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;

public class UI_DataManager //code by. 하은
{
    // readonly는 instance 멤버로만 사용가능
    public static readonly UI_DataManager instance = new UI_DataManager();

    //arrMycookiesDatas가 key(id)-value로 되어있어서 Dictionary 컬렉션 사용
    private Dictionary<int, MycookiesData> dicMycookiesData;// = new Dictionary<int, MycookiesData>(); -> using System.Linq를 사용해서 초기화 필요없음
    private Dictionary<int, MyPetsData> dicPetsData;
    private Dictionary<int, TreasureData> treasureData;
    // json에 있는 정보를 담아둔 Dictionary // 여기서 특정 정보 불러오기 
    // 참조된 것을 보면 여기 저장된 키값을 이용해서 특정 value를 불러올 수 있음

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
    { // 딕셔너리 활용
        return treasureData[id];
    }
    public void LoadCookiesData()
    {
        //TextAsset을 로드(Resources폴더-data폴더-Mycookies_data파일을 Load)
        TextAsset asset = Resources.Load<TextAsset>("data/MyCookies_data");
        //asset의 문자열 출력
        var json = asset.text;

        //역직렬화
        MycookiesData[] arrMycookiesDatas = JsonConvert.DeserializeObject<MycookiesData[]>(json);

        //key를 id로 해서 새로운 사전 객체가 생성되어 반환됨(for문에서 dicMycookiesData(data.id, data)해준 것과 같은 기능)
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
        // TextAsset에 int, string 등 있어서 var
        TreasureData[] myTreasureDatas = JsonConvert.DeserializeObject<TreasureData[]>(json);
        // 역직렬화 JsonConvert.DeserializeObject<형식>(입력);
        treasureData = myTreasureDatas.ToDictionary(x => x.id); 
        // 임의변수 x는 ToDictionary의 Key값 // 키값은 dictionary의 id 값
    }

    //dicMycookiesData의 Values를 List로 반환
    public List<MycookiesData> GetMycookiesDatas()
    {
        return dicMycookiesData.Values.ToList();
    }

    //public Dictionary<int, MycookiesData> GetMyCookiesData()
    //{
    //    return dicMycookiesData;
    //}

    //dicPetsData Values를 List로 반환
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
        // Values : dictionary의 모든 값을 불러옴. (Key값으로 출력이 됨) 
        // ToList() : 가져온 정보를 List로 만든다. 
    }

    //public Dictionary<int, TreasureData> GetMytreasureData() 
    // 딕셔너리로 쓸 수도 있었지만 List로 불러내는 함수들이 있어서 그냥 위에 것으로 사용
    //{
    //    return treasureData;
    //}
}
