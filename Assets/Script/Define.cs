using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define : MonoBehaviour
{
    //code by.��ȣ
    public enum UIEvent
    {
        Click,
        PointerDown,
        PointerUp,
    }
    public enum SceneType
    {
        Bonus,
        InGame,
        None,
    }
    public enum Sound //code by. ����
    {
        Bgm,
        Effect,
        IngameEffect,
        GiganticEffect,
        MaxCount, //Sound enum�� ����
    }

    public enum Transition
    {
        Fade,
    }

    public enum PopupType
    {
        Cookie,
        Pet,
        Treasure,

    }
}