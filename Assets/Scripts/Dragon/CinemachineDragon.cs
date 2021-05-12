using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineDragon : MonoBehaviour
{
    CinemachineVirtualCamera vCamera;
    Dragon dragon;


    private void Start()
    {
        vCamera = GetComponent<CinemachineVirtualCamera>();
        dragon = FindObjectOfType<Dragon>();
    }


    void Update()
    {
        vCamera.Follow = dragon.transform;
        //body.OnSnakeGrowed += RecalculateOrthographicView;
        //body.OnSnakeReduced += RecalculateOrthographicView;

    }

    private void RecalculateOrthographicView(int bodyCount)
    {
        vCamera.m_Lens.OrthographicSize = Mathf.Log(bodyCount, 50) * 50;
    }
}
