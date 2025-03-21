using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgresBar : MonoBehaviour
{
    [SerializeField] private Slider progressBar;
    [SerializeField] private float time;

    private void Start()
    {
        StartCoroutine(UpdateProgresBar(1, time));
    }

    private IEnumerator UpdateProgresBar(float targetProgress, float duration)
    {
        float startProgress = progressBar.value;
        float lastTime = 0;

        while (lastTime < time)
        {
            progressBar.value = Mathf.Lerp(startProgress, targetProgress, lastTime/duration);
            lastTime += Time.deltaTime;
            yield return null;
        }
    }
}
