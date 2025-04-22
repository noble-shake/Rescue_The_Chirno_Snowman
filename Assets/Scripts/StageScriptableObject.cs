using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogStructure
{
    public string Name;
    [TextArea] public string Description;
    [Range(0, 4)] public int WhoIsTalker;
    public Sprite BackGround;

    [Space]
    [Header("Space 1")]
    public bool isAppear1;
    public bool flip1;
    public Sprite Standing1;

    [Space]
    [Header("Space 2")]
    public bool isAppear2;
    public bool flip2;
    public Sprite Standing2;

    [Space]
    [Header("Space 3")]
    public bool isAppear3;
    public bool flip3;
    public Sprite Standing3;

    [Space]
    [Header("Space 4")]
    public bool isAppear4;
    public bool flip4;
    public Sprite Standing4;

    [Space]
    [Header("Space 5")]
    public bool isAppear5;
    public bool flip5;
    public Sprite Standing5;

}

[CreateAssetMenu(fileName = "Stage 01", menuName = "Touhou/Stage")]
public class StageScriptableObject : ScriptableObject
{
    public int LEVEL;
    public int PushCondition;
    public float SizeCondition;
    public bool isHigh;
    public GameObject MapPrefab;
    public DialogStructure[] Dialogs;
}