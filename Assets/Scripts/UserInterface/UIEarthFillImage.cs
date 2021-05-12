using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIEarthFillImage : MonoBehaviour
{
    public IntValue earthHealth;
    public IntValue earthHealthMax;
    public Image image;
    public TextMeshProUGUI textValue;
    [Range(0.1f, 2f)]
    int completionSpeed = 1;
     float HealthPercentThreshold;

    public Gradient textGradient;



    // Animator animator;
    public float animationSpeed = 1000f;

    int lastEarthHealth;
    int lastHealthValue;

    public void Init()
    {
        image.fillAmount = 1f;
        //animator = textValue.GetComponent<Animator>();

        lastHealthValue = earthHealthMax.value;
        lastEarthHealth = earthHealthMax.value;

         

        textValue.text = ((earthHealth.value / earthHealthMax.value)*100f).ToString() + " %";

        HealthPercentThreshold =  earthHealthMax.value /100f;

    }

    private void Update()
    {
        int diff = earthHealth.value - lastEarthHealth;

        //if (diff > 0) // AUgmentation
        //{
        //    if (lastEarthHealth < earthHealth.value)
        //    {
        //        lastEarthHealth += completionSpeed;

        //        if (lastEarthHealth % HealthPercentThreshold == 0)
        //        {
        //            image.fillAmount = 0;
        //            //animator.SetTrigger("GrowthUp");
        //            lastHealthValue += 1;
        //            textValue.text = lastHealthValue.ToString() + " %";
        //        }

        //        else
        //            image.fillAmount = Mathf.SmoothStep(image.fillAmount, (lastEarthHealth % HealthPercentThreshold) / (float)HealthPercentThreshold, animationSpeed * Time.deltaTime);



        //    }
        //}
        if (diff < 0)
        {
            if (lastEarthHealth > earthHealth.value)
            {
                lastEarthHealth -= completionSpeed;

                if (lastEarthHealth % HealthPercentThreshold == 0)
                {
                    image.fillAmount = 1;
                    //animator.SetTrigger("GrowthDown");
                    lastHealthValue -= 1;
                    float percent = (lastEarthHealth / (float)earthHealthMax.value)*100;
                    textValue.text = percent.ToString() + " %";
                    
                    textValue.color = textGradient.Evaluate( 1-(percent/100f));
                }

                else
                    image.fillAmount = Mathf.SmoothStep(image.fillAmount, (lastEarthHealth % HealthPercentThreshold) / (float)HealthPercentThreshold, animationSpeed * Time.deltaTime);
            }
        }
    }
}
