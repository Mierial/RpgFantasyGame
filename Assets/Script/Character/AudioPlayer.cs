using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource stepAudioSource;
    [SerializeField] private AudioSource swordAudioSource;
    [SerializeField] private AudioClip stepSound;
    [SerializeField] private AudioClip swordSound;
    [SerializeField] private float stepDelay = 1f; 
    private float stepTimer = 1f;
    public MooveMeh mooveMeh;

    private void Update()
    {
        stepTimer -= Time.deltaTime;
    }

    public void PlayStepSound()
    {
        if (stepTimer <= 0)
        {
            stepAudioSource.PlayOneShot(stepSound);
            stepTimer = stepDelay;
        }
    }
    public void swordPlaySource()
    {
        if(mooveMeh.isSwordInHand())
        {
            swordAudioSource.PlayOneShot(swordSound);
        }
    }
}


