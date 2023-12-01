using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_TreasurePopUp : MonoBehaviour // UIResult�� ���� ����
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
        //    AddTreasure(data); // ���õ� key�� (id)�� �� �ν���ƮWindow�� ����
          
        //}
    }

    public void AddTreasure(TreasureData data)
    {
        //if (UserDataManager.Instance.GetHasTreasure(data.id) == 0)
        //    return; // �̹� ������ ������ �ִٰ� ǥ��
        if (UserDataManager.Instance.GetHasTreasure(data.id) == 1)
        {
            // popupPos�� �� ������Ʈ ��ġ���� ���õ� key���� �ִ� �˾�â�� ������
            var go = Instantiate(popupPrefab, popupPos); // �˾�����
        PopUpBox popUpBox = go.GetComponent<PopUpBox>();
        // ������ �������� ������ ����� ��ũ��Ʈ ������ ���� ����
       
        popUpBox.Initialize(UI_DataManager.instance.GetTreasureData(data.id));
            //�ش� ��ũ��Ʈ�� �ִ� �Լ��� ������ �ҷ��´�(������ ���� Ư���ؼ� ������)
            //�˾��ڽ��� ���� �̴ϼȶ����� �Լ����� ���� ���� ����ִ� ���� �������ش�.
        UserDataManager.Instance.SetHasTreasure(data.id, false);
            // ���� data.id�� 0�� �ٲ���
        popUpBox.checkBtn.onClick.AddListener(() =>
        {
            //������ �˾��ڽ��� ���̵� ������
            EventManager.instance.onSelectBtnClick(popUpBox.GetID());
            //Destroy(popupPrefab);
            
            // ������ �˾�â�� �ִ� ��ư�� ������ EventManager�� ���ؼ� 
            // Main_Result�� EventManager�� ���༭ ���� ID�� �˷��� ����.
        });
        }

        //if (UserDataManager.Instance.GetHasTreasure(data.id) == 0) 
            // HasTreasure ��ųʸ��� ����� Ű���� value�� 0�̸� �����̳� 
            // �ٸ� ��ũ��Ʈ������ return�̱⶧���� ������ ���ٴ� ǥ�÷� ���
        //{
            //treasureBoxs.Add(popUpBox); // ��� �� �ڵ嵵 RefreshCheck���� ����Ϸ��� �߾����� ���⼭ ���� ���� �ڵ���.
            // �׷��� value�� 0�϶��� popUpWindow�� �ѹ��� ���ڴٴ� �ǹ̷� �ۼ�
            // ���� list treasureBoxs�� Ư�� �����Ͱ� ��� popupBox�� �����Ѵٸ�
            // ������� ���� ���ϴ� �������� ����ϱ� ����. treasureBox.contains(popupbox) 
            // 
            //UserDataManager.Instance.SetHasTreasure(data.id, true);
            // �ش� �������� ���� 1�� ���� ���� key�� �ٽ� �߰� �ȵǰ� �Ұ���
        //}

    }

    public List<PopUpBox> GetTreasureList()
    {
        return treasureBoxs;
        // treasureBoxs ��ųʸ��� ����ǰ� ���õǾ��� PopUpBox ��ũ��Ʈ�� ������ �ҷ��� 
        // ���⿡ ����� id���� �ҷ����� üũ�������� true���ְ� üũ�������� true�� �� ��������
        // üũ ǥ�ð� �ٸ� ���� �����ϸ� false�� �ǰ� �ϴ� �ڵ忡�� ����
    }

}
