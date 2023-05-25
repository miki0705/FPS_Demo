using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboardization : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        transform.forward = transform.position - cam.transform.position;
    }
}
