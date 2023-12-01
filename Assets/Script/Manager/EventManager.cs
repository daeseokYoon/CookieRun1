using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager //code by. 하은
{
    public static readonly EventManager instance = new EventManager();

    public System.Action<int> onSelectBtnClick;
    public System.Action<int> onBuyBtnClick;

    private EventManager() { }
    // 새로운 인스턴트를 생성할 수 없다. 
    // 오직 한 번만 생성되고 바꿀 수 없다.
}
