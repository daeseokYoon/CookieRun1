using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpBox : MonoBehaviour // ���� PopUp�Ǵ� �����տ� ���� ����.
{
    // ��¥ �˾� �ڽ��� �����͸� �������
    [SerializeField] int id; // ������ �����տ� ����� id(Key) ����
    [SerializeField] Image Ima_treasure; // �����̹���
    [SerializeField] Text treasure_text; // ������ �Բ� ��µ� �̹���
    public Button checkBtn; // ��ũ��Ʈ�� ���� Ȯ�ι�ư // �̺�Ʈ�Ŵ����� ��뿹��

    public void Initialize(TreasureData data)
    {
        id = data.id;
        var atlas = AtlasManager.Instance.GetAtlasByName("Treasure");
        Ima_treasure.sprite = atlas.GetSprite(data.sprite_name);
        Ima_treasure.SetNativeSize();
        treasure_text.text = "������ ȹ���߽��ϴ�";
    }

    public int GetID()
    {
        return id;
    }
}
