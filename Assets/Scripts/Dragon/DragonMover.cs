using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMover : MonoBehaviour
{


    IMovementInput input = null;
    Dragon dragon;
    
    Vector3[] lastBodiesPositions;
    float savePositionTick;

    [Range(0f, 0.5f)]
    public float distanceBetweenBodies;

    public float rotationLimit;

    public float speed = 40f;

    public IntValue currentHeight;


    public void Start()
    {
        input = GetComponent<IMovementInput>();
        dragon = GetComponent<Dragon>();
        lastBodiesPositions = new Vector3[dragon.bones.Count];

        SubscribeEvent();

        currentHeight.value = 0;
       
        //FindObjectOfType<UIKMFillImage>().Init();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveHead();
        BodyFollow();
        SavePosTimer();
    }

    private void MoveHead()
    {
        if (input.Vertical != 0 && input.Horizontal != 0)
        {
            float currentRotation = (Mathf.Atan2(input.Vertical, input.Horizontal));
            currentRotation = currentRotation * Mathf.Rad2Deg;

            //if (rotationTotal < 0)
            //    rotationTotal += 360f;

            Quaternion rotation = Quaternion.AngleAxis(currentRotation - 90, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationLimit);
        }

        transform.position += transform.up * Time.deltaTime * speed;

        currentHeight.value = (int)transform.position.y;
    }

    private void BodyFollow()
    {
        if (lastBodiesPositions.Length > 0)
        {
            for (int i = 1; i < dragon.bones.Count; i++)
            {
                dragon.bones[i].transform.up = lastBodiesPositions[i - 1] - lastBodiesPositions[i];
                dragon.bones[i].transform.position += dragon.bones[i].transform.up * Time.deltaTime * speed;
            }
        }
    }

    private void SavePosTimer()
    {
        savePositionTick -= Time.deltaTime;

        if (savePositionTick <= 0)
        {
            savePositionTick = distanceBetweenBodies;
            UpdateLastPositions(0);
        }
    }

    private void UpdateLastPositions(int bodycount)
    {
        if (lastBodiesPositions.Length != dragon.bones.Count)
        {
            lastBodiesPositions = new Vector3[dragon.bones.Count];
        }

        for (int i = 0; i < dragon.bones.Count; i++)
        {
            lastBodiesPositions[i] = dragon.bones[i].transform.position;
        }
    }

    public void SubscribeEvent()
    {
        dragon.OnSnakeGrowed += UpdateLastPositions;
        dragon.OnSnakeGrowed += ReCalculateSpeed;
        dragon.OnSnakeReduced += ReCalculateSpeed;



    }

    private void ReCalculateSpeed(int bodycount)
    {
        speed = Mathf.Log(bodycount,10) * 40;
    }

    private void OnDestroy()
    {
        dragon.OnSnakeGrowed -= UpdateLastPositions;
    }

    private void OnApplicationQuit()
    {
        currentHeight.value = 0;
    }
}








