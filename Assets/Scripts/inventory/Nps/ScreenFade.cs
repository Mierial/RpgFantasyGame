using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 1f;
    
    public DeathRevial revial;

    private bool isFading = false;
    void Start()
    {
        Color color = fadeImage.color;
        color.a = 0f; 
        fadeImage.color = color;
    }

    void Update()
    {
        if (isFading == true)
        {
            fadeImage.gameObject.SetActive(true);
            Color color = fadeImage.color;
            color.a += fadeSpeed * Time.deltaTime;
            fadeImage.color = color;

            if (color.a >= 1f)
            {
                color.a = 1f;
                fadeImage.color = color;
                isFading = false;
                fadeImage.gameObject.SetActive(false);
            }
        }
    }

    public void StartFade()
    {
        isFading = true;
    }
}
