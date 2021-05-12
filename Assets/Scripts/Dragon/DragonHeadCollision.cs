using System;
using System.Collections.Generic;
using UnityEngine;

public class DragonHeadCollision : DragonBoneCollision
{
    public event Action OnEatableObjectDetected, OnEatableObjectNotDetected;
    public event Action OnLootCollided;

    Dragon dragon;

    private void Start()
    {
        dragon = GetComponent<Dragon>();
    }


    //FOOD DETECTOR
    void OnTriggerEnter2D(Collider2D collision) //FOOD DETECTOR
    {

        IDamageable collisionObject = collision.transform.GetComponent<IDamageable>();
        if (collisionObject != null)
        {
            OnEatableObjectDetected?.Invoke();
            return;
        }

        ILootable lootObject = collision.transform.GetComponent<ILootable>();
        if (lootObject != null)
        {
            OnEatableObjectDetected?.Invoke();
            return;
        }


    }

    //FOOD DETECTOR
    private void OnTriggerExit2D(Collider2D collision) //FOOD DETECTOR
    {
        IDamageable collisionObject = collision.transform.GetComponent<IDamageable>();
        if (collision != null)
        {
            OnEatableObjectNotDetected?.Invoke();
            return;
        }

        ILootable lootObject = collision.transform.GetComponent<ILootable>();
        if (lootObject != null)
        {
            OnEatableObjectNotDetected?.Invoke();
            return;
        }


    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable collisionObject = collision.transform.GetComponent<IDamageable>();

        if (collisionObject != null)
        {
            collisionObject.OnDragonHeadCollided();
            FireOnBoneCollided();
            return;
        }

        ILootable lootObject = collision.transform.GetComponent<ILootable>();

        if (lootObject != null)
        {
            lootObject.PickUpLoot();
            FireOnBoneCollided();
            OnLootCollided?.Invoke();
        }

        DragonBone dragonBone = collision.transform.GetComponent<DragonBone>();

        if (dragonBone != null)
        {
            int index = dragon.bones.IndexOf(dragonBone);

            if (index >= 10)
            {
                dragon.CutTail(index);
            }

        }
    }



}