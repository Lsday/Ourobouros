using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour, IDamageable
{

    public float speed = 25f;

    protected bool canMove = true;

    public ScriptableAction[] deathAction;

    public int growthBonus;
    public int growthMalus;
    public IntValue growthBonusRef;
    public IntValue earthHealth;

    void FixedUpdate()
    {
        if (canMove)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
    }

    public virtual void OnDragonBoneCollided()
    {
        growthBonusRef.value -= growthMalus;
        Damage();
    }

    public virtual void OnDragonHeadCollided()
    {
        growthBonusRef.value += growthBonus;
        Damage();
    }

    public virtual void Damage()
    {
        Death();
    }

    public virtual void Death()
    {
        canMove = false;

        for (int i = 0; i < deathAction.Length; i++)
        {
            deathAction[i].PerformAction(gameObject);
        }

        Destroy(gameObject);

    }

    public void OnWorldLimimitCollided()
    {
        earthHealth.value -= growthMalus;
        Destroy(gameObject);
    }
}
