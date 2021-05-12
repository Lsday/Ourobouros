
using UnityEngine;

public interface IDamageable
{
    void Damage();
    void OnDragonBoneCollided();
    void OnDragonHeadCollided();
    void OnWorldLimimitCollided();
    void Death();
}