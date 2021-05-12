using UnityEngine;
using System.Collections;

public class LootAtraction : MonoBehaviour
{

    public float magneticRange = 5;
    public float speed = 5;
    public LayerMask mask;
    Rigidbody2D rb;

    // Update is called once per frame
    void FixedUpdate()
    {
        rb = GetComponent<Rigidbody2D>();
        Collider2D[] results = Physics2D.OverlapCircleAll(transform.position, magneticRange, mask);

        if (results != null)
        {
            foreach (Collider2D loot in results)
            {
                if (loot.GetComponent<ILootable>() != null)
                {
                    loot.transform.position = Vector3.Slerp(loot.transform.position, transform.position, speed * Time.deltaTime);
                }
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, magneticRange);
    }
}
