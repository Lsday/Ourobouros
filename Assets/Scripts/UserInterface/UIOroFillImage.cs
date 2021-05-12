using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIOroFillImage : MonoBehaviour
{
    public IntValue valueToObserve;
    public Image image;
    public float animationSpeed = 100f;

    [Range(0.1f,2f)]
     float CompletionSpeed = 1f;

    private float lastValueToObserve = 0;

    Animator animator;
    public TextMeshProUGUI textValue;
    public IntValue bodyCountValue;
    private int lastBodyCountvalue;

    private void Start()
    {
        image.fillAmount = 0;
        animator = textValue.GetComponent<Animator>();

        lastBodyCountvalue = bodyCountValue.value;
        textValue.text = bodyCountValue.value.ToString();

    }

    private void Update()
    {
        int diff = valueToObserve.value - (int)lastValueToObserve;

        if (diff > 0) // AUgmentation
        {
            if (lastValueToObserve < valueToObserve.value)
            {
                lastValueToObserve += CompletionSpeed;

                if (lastValueToObserve % 10 == 0)
                {
                    image.fillAmount = 0;
                    animator.SetTrigger("GrowthUp");
                    lastBodyCountvalue += 1;
                    textValue.text = lastBodyCountvalue.ToString();
                }
                   
                else
                    image.fillAmount = Mathf.SmoothStep(image.fillAmount, (lastValueToObserve % 10) / 10f, animationSpeed * Time.deltaTime);
            }
        }
        else if (diff < 0)
        {
            if (lastValueToObserve > valueToObserve.value)
            {
                lastValueToObserve -= CompletionSpeed;

                if (lastValueToObserve % 10 == 0)
                {
                    image.fillAmount = 1;
                    animator.SetTrigger("GrowthDown");
                    lastBodyCountvalue -= 1;
                    textValue.text = lastBodyCountvalue.ToString();
                }
                    
                else
                    image.fillAmount = Mathf.SmoothStep(image.fillAmount, (lastValueToObserve % 10) / 10f, animationSpeed * Time.deltaTime);
            }
        }
    }
}
