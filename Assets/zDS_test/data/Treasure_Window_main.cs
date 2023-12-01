using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure_Window_main : MonoBehaviour
{
    [SerializeField] UI_TreasureMaster uI_TreasureMaster;
    [SerializeField] UI_TreasurePopUp uI_TreasurePopup;
    [SerializeField] GameObject ul_TreasurePopUpPos; // �˾��� ��Ÿ�� �θ������Ʈ
    [Space]

    [Header("PopUp Box")]
    [SerializeField] GameObject PopupBox;

    void Start()
    {
        UI_DataManager.instance.LoadTreasureData();

        // �̺�Ʈ�Ŵ����� �ҷ��� int ���� �ٸ� �����Ϳ� ����� key���̶� �����ϱ� ������
        // ���� ��ũ��Ʈ���� �Բ� ������ �Ʒ��� ���� ���� ���� ����
        EventManager.instance.onSelectBtnClick = (id) => // id = popUpBox.GetID()
        {
            // �̺�Ʈ �Ŵ����� �ҷ��� ���� id�� ���� key������ ��ųʸ��� ������ value�� data ������ �ҷ�����.
            var data = UI_DataManager.instance.GetTreasureData(id);
            // ���� �������� ����� �ϳ��� ������ �ٸ� �޼ҵ带 ����
            //----------------------------------------------------------
            // ������� �κ�� �̵��ϸ鼭 �κ��丮�� ������ ��������
            // �ϴ� 1ȸ�� ����â�� ���� �ͺ��� Ȯ���� ��.
            if (UserDataManager.Instance.GetHasTreasure(id) == 1)
                return; // �̺�Ʈ�Ŵ����� ������ id���� hastreasure ���� 1�� ���·� ��
            //InventoryManager.Instance.AddSlot(data); // �κ� �κ��丮�� �����߰�?
            
            // UserDataManager.Instance.SetSelectTreasureID(id); // ���⿡ �Ⱦ��� ���ʿ� ��Ű��ȣ�� �޾ƿ� �� �ִ� ��Ű�԰� �ΰ� ������ �ڵ忡 ���������
            // Set�ϱ� ���� ���� Get���� id�� 0�� ���� �����ؼ� ���þ��ϰ� 0�� �ƴϸ� ����
            // Ȯ�� ��ư�� ������ �̺�Ʈ�Ŵ����� ���ؼ� �κ�� id���� �Ѿ�� �� id���� ����
            // ���� ������ �����տ� �κ��丮�� �߰� �� ����.
            // GetHasTreasure�� 
            //----------------------------------------------------------

            PopUpBox checkID = uI_TreasurePopup.GetTreasureList()?.Find(item => item.GetID() == data.id);
            // �˾� �ڽ��� ���̵�(Key)�� �����´�.
            // �� ��Ű�԰� ����ڿ��� üũ�� ������ ������ �ϴ� �ڵ带 �ۼ��ϴµ� ���� �ڵ��.
            // ���� ���⼭�� ������ �ʴ� �ڵ���. // �ڼ��� ������ ��Ű�����̳� ����� ��ũ��Ʈ�� �ּ��� Ȯ��

           
        };
        uI_TreasureMaster.Initialize(); // �˾� ����

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
