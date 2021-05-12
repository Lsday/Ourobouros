using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{

    [SerializeField] private float duration = 1f;
    [SerializeField] private bool endTimerOnDestroy = false;
    [SerializeField] UnityEvent OnTimerEnd = new UnityEvent();

    private void Start()
    {
        StartCoroutine(StartTimer());
    }

    private void OnDestroy()
    {
        if (endTimerOnDestroy)
        {
            OnTimerEnd?.Invoke();
            StopAllCoroutines();
        }
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(duration);
        OnTimerEnd?.Invoke();
    }
}


