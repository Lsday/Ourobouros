using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Earth : MonoBehaviour
{

    [SerializeField] private float YOffset = 20f;
    Dragon dragon;
    public IntValue EarthHealth;
    public IntValue EarthHealthMax;



    private void Start()
    {
        EarthHealth.value = EarthHealthMax.value;
        FindObjectOfType<UIEarthFillImage>().Init();
        dragon = FindObjectOfType<Dragon>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.OnWorldLimimitCollided();
        }
    }

  

    private void Update()
    {
        transform.position = dragon.transform.position + new Vector3(0, YOffset, 0);
    }


}
