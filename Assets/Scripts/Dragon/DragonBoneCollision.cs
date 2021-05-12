using System;
using UnityEngine;

public class DragonBoneCollision : MonoBehaviour 
{

    public event Action OnBoneCollided;
   
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable collisionObject = collision.transform.GetComponent<IDamageable>();

        if (collisionObject != null)
        {
            collisionObject.OnDragonBoneCollided();
            FireOnBoneCollided();
            return;
        }
    }

    protected void FireOnBoneCollided()
    {
        OnBoneCollided?.Invoke();
    }

   
}