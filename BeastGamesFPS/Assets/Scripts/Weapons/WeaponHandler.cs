using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField, Tooltip("Lista broni.")]
    private List<WeaponScr> weapons;
    private int currentWeapon = 0;


    private int totalNormalBullets = 20;
    private int totalFireBullets = 20;
    private int totalAcidBullets = 20;

    [SerializeField]
    private bool unlimitedAmmo = true;

    private void Start()
    {
        SelectWeapon(0);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootIni();
        }


        //Zmiana broni scrollem na myszce
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            SelectWeapon(currentWeapon == (weapons.Count - 1) ? 0 : currentWeapon + 1);
            print(currentWeapon);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            SelectWeapon(currentWeapon == 0 ? (weapons.Count - 1) : (currentWeapon - 1));
            print(currentWeapon);
        }
    }

    /// <summary>
    /// Inicjalizacja strza³u, sprawdza dostêpnoœæ amunicji danego typu, wywo³uje metodê Shoot().
    /// </summary>
    private void ShootIni()
    {
        if (!unlimitedAmmo)
        {
            switch (weapons[currentWeapon].WeaponInfo.damageType)
            {
                case EnumsDamageTypes.DamageTypes.normal:
                    if (totalNormalBullets > 0)
                        totalNormalBullets--;
                    else
                        return;
                    break;
                case EnumsDamageTypes.DamageTypes.fire:
                    if (totalFireBullets > 0)
                        totalFireBullets--;
                    else
                        return;
                    break;
                case EnumsDamageTypes.DamageTypes.acid:
                    if (totalAcidBullets > 0)
                        totalAcidBullets--;
                    else
                        return;
                    break;
                default:
                    break;
            }
            print("Shot, current ammo state: " + totalNormalBullets + "|" + totalFireBullets + "|" + totalAcidBullets);
        }

        
        weapons[currentWeapon].Shoot();
    }

    /// <summary>
    /// Metoda odpowiadaj¹ca za wykonanie operacji zwi¹zanych ze zmian¹ broni.
    /// </summary>
    /// <param name="weaponIndex">Index broni która ma zostaæ wybrana.</param>
    private void SelectWeapon(int weaponIndex)
    {
        if (weaponIndex == currentWeapon || weaponIndex > (weapons.Count - 1) || weaponIndex < 0) return;
        currentWeapon = weaponIndex;
        DisableAll();

        weapons[weaponIndex].gameObject.SetActive(true);
    }


    /// <summary>
    /// Metoda wy³¹czaj¹ca wszystkie bronie.
    /// </summary>
    private void DisableAll()
    {
        foreach (WeaponScr weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }
    }

}
