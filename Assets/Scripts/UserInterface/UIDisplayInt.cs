using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplayInt : MonoBehaviour
{

    public IntValue valueToObserve;
    public TextMeshProUGUI textValue;

    void Start()
    {
        textValue.text = valueToObserve.value.ToString();
    }

    private void Update()
    {
        textValue.text = valueToObserve.value.ToString();
       
    }


}
