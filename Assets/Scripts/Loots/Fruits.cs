using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour, ILootable
{

    Vector3 target;
    public float speed = 20;
    public float distanceFromOrigin = 30;

    public int growthBonus;
    public IntValue lootBonus;

    Collider2D myCollider;
    public bool randomColor;

    public void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myCollider.enabled = false;

        float randomX = Random.Range(transform.position.x - distanceFromOrigin, transform.position.x + distanceFromOrigin);
        float randomY = Random.Range(transform.position.y - distanceFromOrigin, transform.position.y + distanceFromOrigin);
        target = new Vector3(randomX, randomY, 0);
        if (randomColor)
        {
            Color randomColor = new Color();
            int randomNumber = Random.Range(0, 3);

            if (randomNumber == 1)
                randomColor = Color.red;

            if (randomNumber == 2)
                randomColor = Color.blue;

            if (randomNumber == 3)
                randomColor = Color.green;


            //GetComponent<SpriteRenderer>().material.color = randomColor;
            GetComponent<SpriteRenderer>().material.SetColor("_EmissionColor", randomColor * 5);
            
        }
       
    }

    private void FixedUpdate()
    {

        if (target != Vector3.zero)
        {
            MoveToPosition();
        }

        //transform.position += -transform.up * Time.deltaTime * speed;

    }

    public void MoveToPosition()
    {
        float distance = Vector2.Distance(transform.position, target);
        if (distance > 1f)
        {
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
        }
        else
        {
            target = Vector3.zero;
            myCollider.enabled = true;
        }
    }

    public void PickUpLoot()
    {
        lootBonus.value += growthBonus;

        Destroy(gameObject);
    }


}
