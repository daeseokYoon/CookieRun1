using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_TreasurePopUp : MonoBehaviour // UIResult에 붙일 예정
{
    [SerializeField] Transform popupPos;
    [SerializeField] GameObject popupPrefab;
    [SerializeField] List<PopUpBox> treasureBoxs = new List<PopUpBox>();

    public void Initialize(int id)
    {
        TreasureData data = UI_DataManager.instance.GetTreasureData(id);

        switch (data.id)
        {
            case 100:
            AddTreasure(data);
            break;
            case 101:
            AddTreasure(data);
            break;
            case 102:
            AddTreasure(data);
            break;
            case 103:
            AddTreasure(data);
            break;
            case 104:
            AddTreasure(data);
            break;
            default:
            break;
        }
        //foreach (TreasureData data in list)
        //{
        //    AddTreasure(data); // 선택된 key값 (id)가 들어간 인스턴트Window를 생성
          
        //}
    }

    public void AddTreasure(TreasureData data)
    {
        //if (UserDataManager.Instance.GetHasTreasure(data.id) == 0)
        //    return; // 이미 보물을 가지고 있다고 표시
        if (UserDataManager.Instance.GetHasTreasure(data.id) == 1)
        {
            // popupPos에 들어간 오브젝트 위치에서 선택된 key값이 있는 팝업창이 생성됨
            var go = Instantiate(popupPrefab, popupPos); // 팝업생성
        PopUpBox popUpBox = go.GetComponent<PopUpBox>();
        // 생성된 프리팹의 정보에 저장된 스크립트 형식을 담은 변수
       
        popUpBox.Initialize(UI_DataManager.instance.GetTreasureData(data.id));
            //해당 스크립트에 있는 함수의 정보를 불러온다(선택한 것을 특정해서 가져옴)
            //팝업박스에 위에 이니셜라이즈 함수에서 받은 값이 들어있는 것을 연결해준다.
        UserDataManager.Instance.SetHasTreasure(data.id, false);
            // 얻은 data.id를 0로 바꿔줌
        popUpBox.checkBtn.onClick.AddListener(() =>
        {
            //생성된 팝업박스의 아이디를 가져옴
            EventManager.instance.onSelectBtnClick(popUpBox.GetID());
            //Destroy(popupPrefab);
            
            // 생성된 팝업창에 있는 버튼을 누르면 EventManager를 통해서 
            // Main_Result에 EventManager를 써줘서 얻은 ID를 알려줄 것임.
        });
        }

        //if (UserDataManager.Instance.GetHasTreasure(data.id) == 0) 
            // HasTreasure 딕셔너리에 저장된 키값의 value가 0이면 메인이나 
            // 다른 스크립트에서는 return이기때문에 보물이 없다는 표시로 사용
        //{
            //treasureBoxs.Add(popUpBox); // 사실 이 코드도 RefreshCheck에서 사용하려고 했었으니 여기서 쓸일 없는 코드임.
            // 그러니 value가 0일때만 popUpWindow를 한번만 띄우겠다는 의미로 작성
            // 만약 list treasureBoxs에 특정 데이터가 담긴 popupBox가 존재한다면
            // 재생성을 하지 못하는 조건으로 사용하기 위함. treasureBox.contains(popupbox) 
            // 
            //UserDataManager.Instance.SetHasTreasure(data.id, true);
            // 해당 데이터의 값을 1로 만들어서 같은 key가 다시 추가 안되게 할거임
        //}

    }

    public List<PopUpBox> GetTreasureList()
    {
        return treasureBoxs;
        // treasureBoxs 딕셔너리에 저장되고 선택되었던 PopUpBox 스크립트의 정보를 불러옴 
        // 여기에 저장된 id값을 불러내서 체크아이콘을 true해주고 체크아이콘이 true가 된 프리팹의
        // 체크 표시가 다른 것을 선택하면 false가 되게 하는 코드에서 사용됨
    }

}
