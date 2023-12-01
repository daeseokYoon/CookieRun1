using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure_Window_main : MonoBehaviour
{
    [SerializeField] UI_TreasureMaster uI_TreasureMaster;
    [SerializeField] UI_TreasurePopUp uI_TreasurePopup;
    [SerializeField] GameObject ul_TreasurePopUpPos; // 팝업이 나타날 부모오브젝트
    [Space]

    [Header("PopUp Box")]
    [SerializeField] GameObject PopupBox;

    void Start()
    {
        UI_DataManager.instance.LoadTreasureData();

        // 이벤트매니저로 불러온 int 값이 다른 데이터에 저장된 key값이랑 동일하기 때문에
        // 여러 스크립트에서 함께 쓰여서 아래와 같이 같은 값을 공유
        EventManager.instance.onSelectBtnClick = (id) => // id = popUpBox.GetID()
        {
            // 이벤트 매니저로 불러온 같은 id로 맞춘 key값으로 딕셔너리에 저장한 value를 data 변수로 불러낸다.
            var data = UI_DataManager.instance.GetTreasureData(id);
            // 같은 변수값과 연계된 하나의 정수로 다른 메소드를 통제
            //----------------------------------------------------------
            // 결과에서 로비로 이동하면서 인벤토리에 보물이 생성예정
            // 일단 1회성 보물창만 띄우는 것부터 확인할 것.
            if (UserDataManager.Instance.GetHasTreasure(id) == 1)
                return; // 이벤트매니저로 가져온 id값은 hastreasure 값이 1인 상태로 옴
            //InventoryManager.Instance.AddSlot(data); // 로비 인벤토리에 보물추가?
            
            // UserDataManager.Instance.SetSelectTreasureID(id); // 여기에 안쓰고 애초에 쿠키번호를 받아올 수 있는 쿠키함과 로고 사이의 코드에 썻어야했음
            // Set하기 전에 위에 Get에서 id가 0인 값을 리턴해서 세팅안하고 0이 아니면 세팅
            // 확인 버튼을 누르고 이벤트매니저를 통해서 로비로 id값이 넘어가면 그 id값을 가진
            // 보물 아이템 프리팹에 인벤토리에 추가 될 것임.
            // GetHasTreasure가 
            //----------------------------------------------------------

            PopUpBox checkID = uI_TreasurePopup.GetTreasureList()?.Find(item => item.GetID() == data.id);
            // 팝업 박스의 아이디(Key)를 가져온다.
            // 내 쿠키함과 펫상자에서 체크가 켜졌다 꺼졌다 하는 코드를 작성하는데 쓰인 코드다.
            // 지금 여기서는 쓰이지 않는 코드임. // 자세한 사항은 쿠키메인이나 펫메인 스크립트의 주석을 확인

           
        };
        uI_TreasureMaster.Initialize(); // 팝업 생성

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
