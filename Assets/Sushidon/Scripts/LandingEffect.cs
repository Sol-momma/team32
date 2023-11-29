using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingEffect : MonoBehaviour
{
    public ParticleSystem landingEffect;

    public void PlayLandingEffect()
    {
        if (landingEffect != null)
        {
            ParticleSystem newEffect = Instantiate(landingEffect, transform.position, Quaternion.identity);
            newEffect.Play();
            Destroy(newEffect.gameObject, newEffect.main.duration);
        }
    }
}
