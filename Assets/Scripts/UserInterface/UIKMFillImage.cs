using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIKMFillImage : MonoBehaviour
{
    public IntValue valueToObserve;
    public Image image;
    public TextMeshProUGUI textValue;
    [Range(0.1f, 2f)]
     float completionSpeed = 1;
    public int heightThreshold;



   // Animator animator;
    public float animationSpeed = 1000f;

    float lastValueToObserve;
    float lastHeightValue;

    public void Start()
    {
        image.fillAmount = 0;
        //animator = textValue.GetComponent<Animator>();
        
        lastHeightValue = 0;
        lastValueToObserve = 0;
        textValue.text = valueToObserve.value.ToString() + " KM";

    }

    private void Update()
    {
        int diff = valueToObserve.value - (int)lastValueToObserve;

        if (diff > 0) // AUgmentation
        {
            if (lastValueToObserve < valueToObserve.value)
            {
                lastValueToObserve += completionSpeed;

                if (lastValueToObserve % heightThreshold == 0)
                {
                    image.fillAmount = 0;
                    //animator.SetTrigger("GrowthUp");
                    lastHeightValue += 1;
                    textValue.text = lastHeightValue.ToString() + " KM";
                }

                else
                    image.fillAmount = Mathf.SmoothStep(image.fillAmount, (lastValueToObserve % heightThreshold) / (float)heightThreshold, animationSpeed * Time.deltaTime);


                
            }
        }
        else if (diff < 0)
        {
            if (lastValueToObserve > valueToObserve.value)
            {
                lastValueToObserve -= completionSpeed;

                if (lastValueToObserve % heightThreshold == 0)
                {
                    image.fillAmount = 1;
                    //animator.SetTrigger("GrowthDown");
                    lastHeightValue -= 1;
                    textValue.text = lastHeightValue.ToString() + " KM";
                }

                else
                    image.fillAmount = Mathf.SmoothStep(image.fillAmount, (lastValueToObserve % heightThreshold) / (float)heightThreshold, animationSpeed * Time.deltaTime);
            }
        }
    }
}
