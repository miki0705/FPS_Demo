using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "New Weapon", menuName = "Scriptable Objects/New Weapon Info")]
public class WeaponInfo : ScriptableObject
{
    [Tooltip("Nazwa broni, np. Turbo Pistolet.")]
    public string idName;
    [Tooltip("Obra¿enia zadawane przez broñ.")]
    public int damage;
    [Tooltip("Szybkostrzelnoœæ broni.")]
    public float fireRate;
    [Tooltip("Zasiêg jaki posiada broñ.")]
    public float range;
    [Tooltip("DamageType definiuje jakiego '¿ywio³u' obra¿enia zadaje, przeciwko jakiemu materia³owi jest skuteczna.")]
    public EnumsDamageTypes.DamageTypes damageType;
}
