using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollViewCookiesSelect : MonoBehaviour //code by. 하은
{
    public Text cookieName;
    public Image cookieImg;
    public Button selectBtn;
    [SerializeField] GameObject SelectPanel;
    [SerializeField] GameObject BuyPanel;
    public Button buyBtn;
    public Text priceTxt;
    [SerializeField] int id;   
    [SerializeField] GameObject lockIcon;
    [SerializeField] GameObject checkIcon;

    public void Initialize(MycookiesData data)
    {
        id = data.id;
        cookieName.text = data.name;
        var atlas = AtlasManager.Instance.GetAtlasByName("Cookies");
        cookieImg.sprite = atlas.GetSprite(data.sprite_name);
        cookieImg.SetNativeSize();
        cookieImg.GetComponent<RectTransform>().sizeDelta = new Vector2(390, 390); //Sprite 사이즈 고정
        priceTxt.text = string.Format("{0}",data.price);

        SetActivePanel();
        RefreshCheck();

    }

    public int GetID()
    {
        return id;
    }
    public void SetActivePanel() // 패널 두개가 같은 위치에 겹쳐있음
    {
        if (id == 100)
        {
            SelectPanel.SetActive(true);
            BuyPanel.SetActive(false);

        }
        else
        {
            if(UserDataManager.Instance.GetHasCookie(id) == 1)
            {
                SelectPanel.SetActive(true);
                BuyPanel.SetActive(false);
            }
            else
            {
                SelectPanel.SetActive(false);
                BuyPanel.SetActive(true);  
            } 
        }
    }
    public void SetLock(bool flag)
    {
        lockIcon.SetActive(flag);
    }
    public void RefreshLock()
    {
        if (UserDataManager.Instance.GetHasCookie(id) == 0) // 쿠키 안가지고 있음 
        {
            SetLock(true);
        }
        else
        {
            SetLock(false);
        }

    }
    public void SetCheck(bool flag)
    {
        checkIcon.SetActive(flag);
    }
    public bool GetCheck()
    {
        return checkIcon.activeSelf;
    }
    public void RefreshCheck()
    {
        if (UserDataManager.Instance.GetHasCookie(id) == 1)
        {
            if (UserDataManager.Instance.GetSelectCookieID() == id)
            {
                SetCheck(true);
            }
            else
            {
                SetCheck(false);
            }
        }
        else // 쿠키 안가지고 있다.
        {
            SetCheck(false);
        }
    }

}
