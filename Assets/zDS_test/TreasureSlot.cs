using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureSlot : MonoBehaviour
{
    // if ��ũ���ͺ������Ʈ�� ����Ѵٸ� �Ʒ�ó�� ���ٷε� ����?
    //public Item item;
    [SerializeField] int id;
    [SerializeField] Image _image;
    [SerializeField] Text _name;
    public Button equipBtn;

    public void Initialize(TreasureData data)
    {
        id = data.id;
        var atlas = AtlasManager.Instance.GetAtlasByName("Treasure");
        _image.sprite = atlas.GetSprite(data.sprite_name);
        _image.SetNativeSize();
        _name.text = data.name;
    }

    public int GetID()
    {
        return id;
    }
}
