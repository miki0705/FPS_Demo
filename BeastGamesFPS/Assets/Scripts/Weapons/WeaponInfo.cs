using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "New Weapon", menuName = "Scriptable Objects/New Weapon Info")]
public class WeaponInfo : ScriptableObject
{
    [Tooltip("Nazwa broni, np. Turbo Pistolet.")]
    public string idName;
    [Tooltip("Obra�enia zadawane przez bro�.")]
    public int damage;
    [Tooltip("Szybkostrzelno�� broni.")]
    public float fireRate;
    [Tooltip("Zasi�g jaki posiada bro�.")]
    public float range;
    [Tooltip("DamageType definiuje jakiego '�ywio�u' obra�enia zadaje, przeciwko jakiemu materia�owi jest skuteczna.")]
    public EnumsDamageTypes.DamageTypes damageType;
}
