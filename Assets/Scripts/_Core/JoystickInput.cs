using UnityEngine;
using System.Collections;

public class JoystickInput : MonoBehaviour, IMovementInput
{
    public float Horizontal { get;  set; }

    public float Vertical { get;  set; }

    Joystick joystick;

    // Use this for initialization
    private void Awake()
    {
        joystick = FindObjectOfType<DynamicJoystick>();
    }
  

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        Horizontal = joystick.Horizontal;
        Vertical = joystick.Vertical;
    }
}
