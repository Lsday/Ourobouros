using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundShader : MonoBehaviour
{
    [SerializeField]
    IntValue dragonHeight;

    private int maxHeight = 300;
    private int previousDragonHeight;


    SpriteRenderer myRenderer;
    Material myMaterial;

    private void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        myMaterial = myRenderer.material;
        previousDragonHeight = dragonHeight.value;
    }

    
    private void Update()
    {
        if (dragonHeight.value != previousDragonHeight)
        {
            IncreaseGradient();
        }
    }

    private void IncreaseGradient()
    {
        SetGradientValue(GetGradientValue() + 0.0001f);
        previousDragonHeight = dragonHeight.value;
    }

    private void SetGradientValue(float value)
    {
        myMaterial.SetFloat("_GradientValue", value);
    }

    private float GetGradientValue()
    {
        return myMaterial.GetFloat("_GradientValue");
    }


}
