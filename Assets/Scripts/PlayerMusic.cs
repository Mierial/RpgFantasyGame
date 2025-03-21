using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMusic : MonoBehaviour
{
   [SerializeField] private AudioSource M_Sourse;


    private void FixedUpdate()
    {
        WalkMusic();
    }

    private void WalkMusic()
    {
        if (Input.GetButton("Vertical"))
        {
            M_Sourse.Play();
        }
    }
}
