using UnityEngine;
using System.Collections;

public class DragonWorldLimiter : MonoBehaviour
{
    [SerializeField]
    private Vector2 bottomBoundPosition = Vector2.zero;

    float headHeight = 1f;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckDragonPosition();
    }

    private void CheckDragonPosition()
    {
        Vector3 dragonPosition = transform.position;

        dragonPosition = ClampDragonPosition(dragonPosition);

        RotateDragonHead(dragonPosition);

    }

    private void RotateDragonHead(Vector3 position)
    {
        if (position.y <= bottomBoundPosition.y + headHeight)
        {
            float dot = Vector3.Dot(Vector3.left, transform.up);
            Vector3 rot = transform.rotation.eulerAngles;
            if (dot > 0)
                rot.z = 90;

            if (dot <= 0)
                rot.z = 270;

            transform.eulerAngles = rot;
        }
    }

    private Vector3 ClampDragonPosition(Vector3 position)
    {
        position.y = Mathf.Clamp(position.y, bottomBoundPosition.y + headHeight, Mathf.Infinity);
        transform.position = position;
        return position;
    }
}
