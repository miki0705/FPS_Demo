using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScr : MonoBehaviour
{
    [SerializeField, Tooltip("Scriptable object zawieraj¹cy informacje o broni.")]
    private WeaponInfo weaponInfo;
    private Camera cam;
    private Animator anim;
    [SerializeField]
    private GameObject particles;


    public WeaponInfo WeaponInfo { get => weaponInfo;}


    private void Awake()
    {
        cam = Camera.main;
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Metoda wykonuj¹ce operacje zwi¹zane z wydaniem strza³u, m.in. Raycast, sprawdzanie collider'a.
    /// </summary>
    public void Shoot()
    {
        //smoke, muzzle particles, camera shake
        PlayAnim();
        //animation

        RaycastHit hit;
        Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weaponInfo.range);

        if(hit.collider != null)
        {
            Transform thing = hit.collider.transform;
            Instantiate(particles, hit.point, Quaternion.identity);
            Health health = thing.GetComponent<Health>();
            print("Hit " + hit.collider.name);
            if (health != null && health.TargetInfo.vulnerability == weaponInfo.damageType)
            {
                health.TakeHit(weaponInfo.damage);
            }
        }
    }

    private void OnEnable()
    {
        PlayAnim();
    }

    public void PlayAnim()
    {
        anim.SetTrigger("shoot");
    }
}
