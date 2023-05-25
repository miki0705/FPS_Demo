using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructInator : MonoBehaviour
{
    [SerializeField]
    private float delay = 1;


    private void OnEnable()
    {
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
