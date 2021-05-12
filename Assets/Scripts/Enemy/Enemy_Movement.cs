using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{

    public float speed = 10f;
    void Update()
    {
        transform.position += -transform.up * Time.deltaTime * speed;
    }
}
