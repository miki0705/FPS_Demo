using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "New Target", menuName = "Scriptable Objects/New Target Info")]
public class TargetInfo : ScriptableObject
{
    public string idName;
    public int maxHealth;
    public EnumsDamageTypes.DamageTypes vulnerability;
}
