using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHeadAnimation : MonoBehaviour
{

    Sprite dragonBase, dragonOpenJaw;
    SpriteRenderer headRenderer;

    DragonHeadCollision dragonHead;

    void Start( )
    {
        dragonHead = GetComponent<DragonHeadCollision>();

        dragonBase = GameAssets.instance.dragonBase;
        dragonOpenJaw = GameAssets.instance.dragonOpenJaw;

        headRenderer = transform.GetComponent<SpriteRenderer>();

        SubscribeEvent();

    }

    private void SubscribeEvent()
    {
        dragonHead.OnEatableObjectDetected += DragonFoodDetected;
        dragonHead.OnEatableObjectNotDetected += DragonFoodNotDetected;
    }

    private void OnDestroy()
    {
        dragonHead.OnEatableObjectDetected -= DragonFoodDetected;
        dragonHead.OnEatableObjectNotDetected -= DragonFoodNotDetected;
    }

    private void DragonFoodDetected()
    {
        headRenderer.sprite = dragonOpenJaw;
    }

    private void DragonFoodNotDetected()
    {
            headRenderer.sprite = dragonBase;
    }
}
