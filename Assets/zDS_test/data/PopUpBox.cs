using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpBox : MonoBehaviour // 실제 PopUp되는 프리팹에 붙일 것임.
{
    // 진짜 팝업 박스의 데이터만 들어있음
    [SerializeField] int id; // 생성된 프리팹에 저장될 id(Key) 정보
    [SerializeField] Image Ima_treasure; // 보물이미지
    [SerializeField] Text treasure_text; // 보물과 함께 출력될 이미지
    public Button checkBtn; // 스크립트에 붙은 확인버튼 // 이벤트매니저에 사용예정

    public void Initialize(TreasureData data)
    {
        id = data.id;
        var atlas = AtlasManager.Instance.GetAtlasByName("Treasure");
        Ima_treasure.sprite = atlas.GetSprite(data.sprite_name);
        Ima_treasure.SetNativeSize();
        treasure_text.text = "보물을 획득했습니다";
    }

    public int GetID()
    {
        return id;
    }
}
