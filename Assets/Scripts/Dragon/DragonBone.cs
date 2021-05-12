using UnityEngine;

public class DragonBone : MonoBehaviour
{

    [SerializeField] private ScriptableAction[] deathActions; 


    public void Die()
    {
        for (int i = 0; i < deathActions.Length; i++)
        {
            deathActions[i].PerformAction(gameObject);
        }

        Destroy(gameObject);
    }
}