using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIPlay : MonoBehaviour
{
    [SerializeField] private Slider _progressBar;
    [SerializeField] private float _time;
    void Start()
    {
        StartCoroutine(UpdateProgressBar(1, _time));
    } 

    IEnumerator UpdateProgressBar(float targetProgress, float duration)
    {
        float startProgress = _progressBar.value;
        float lastTime = 0;
        while(lastTime< _time)
        {
            _progressBar.value = Mathf.Lerp(startProgress,targetProgress, lastTime/duration);
            lastTime += Time.deltaTime;
            yield return null;
        }
        _progressBar.value = targetProgress;

    }
}
