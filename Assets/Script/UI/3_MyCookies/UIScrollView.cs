using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScrollView : MonoBehaviour 
{
    [SerializeField] Transform contentTrans;
    [SerializeField] GameObject cookiePrefab;
    [SerializeField] List<UIScrollViewCookiesSelect> CookieComponentList = new List<UIScrollViewCookiesSelect>();
    // 인게임 내에서 사용되는 스크립트의 내용을 사용하기 위해서 사용하는 유형
    public void Initialize()
    {
        //MycookiesData가 들어가있는 List를 전달받아서 Cookie를 생성
        List<MycookiesData> list = UI_DataManager.instance.GetMycookiesDatas();
        // 생각해보니... 같은 형식만 받는다.
        foreach (MycookiesData data in list)
        {
            //create
            AddCookies(data);
        }
    }

    //Cookies 생성
    public void AddCookies(MycookiesData data)
    {
        //프리팹 인스턴스 생성, contentTrans 자식으로 부착
        var go = Instantiate(cookiePrefab, contentTrans);
        UIScrollViewCookiesSelect cookies = go.GetComponent<UIScrollViewCookiesSelect>();

        cookies.Initialize(data);

        // 장금처리 
        if(UserDataManager.Instance.GetHasCookie(data.id) == 0) // 쿠키 안가지고 있음 
        {
            cookies.SetLock(true);
        }
        else
        {
            cookies.SetLock(false);  
        }


        //각 버튼을 누르면 해당 cookies의 id를 EventManager에게 전달
        cookies.selectBtn.onClick.AddListener(() => {
            EventManager.instance.onSelectBtnClick(cookies.GetID());
            // 선택한 프리팹에 저장된 ID정보를 가져와서 전달
        });
        cookies.buyBtn.onClick.AddListener(() => {
            EventManager.instance.onBuyBtnClick(cookies.GetID());
        });

        CookieComponentList.Add(cookies);  
        // 선택한 프리팹의 정보를 새로운 딕셔너리에 저장
    }
    public List<UIScrollViewCookiesSelect> GetCookieComponentList()
    {
        return CookieComponentList;
    }
}
