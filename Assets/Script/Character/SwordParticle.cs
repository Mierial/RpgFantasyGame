using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordParticle : MonoBehaviour
{
    public ParticleSystem particle;

    public void PlayParticle()
    {
        particle.Play();
    }

}
