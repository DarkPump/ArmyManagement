using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Unit/Create new unit")]
public class UnitBase : ScriptableObject
{
    public string unitName;
    public Sprite unitSprite;
    [Min(1)]
    public int unitSize;
}

