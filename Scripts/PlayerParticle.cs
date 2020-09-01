using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticle : MonoBehaviour
{
    public ParticleSystem[] particleSystems;
    static ParticleSystem[] staticParticleSystems;
    static bool ps1 = false;
    static bool ps2 = false;
    static bool ps3 = false;
    static bool ps4 = false;
    static bool ps5 = false;
    static bool ps6 = false;
    static bool ps7 = false;
    static ParticleSystem.MainModule psmm;
    static ParticleSystem.EmissionModule psem1;
    static ParticleSystem.EmissionModule psem2;
    static ParticleSystem.EmissionModule psem3;
    static ParticleSystem.EmissionModule psem4;
    static ParticleSystem.EmissionModule psem5;
    static ParticleSystem.EmissionModule psem6;
    static ParticleSystem.EmissionModule psem7;
    static int index;
    private void Awake()
    {
        staticParticleSystems = particleSystems;
        psem1 = staticParticleSystems[0].emission;
        psem2 = staticParticleSystems[1].emission;
        psem3 = staticParticleSystems[2].emission;
        psem4 = staticParticleSystems[3].emission;
        psem5 = staticParticleSystems[4].emission;
        psem6 = staticParticleSystems[5].emission;
        psem7 = staticParticleSystems[6].emission;
    }
    public static void AddEffect(Color color)
    {
        if (!ps1)
        {
            psmm = staticParticleSystems[0].main;
            index = 0;
            ps1 = true;
            psem1 = staticParticleSystems[0].emission;
            psem1.rateOverTime = 7;
        }
        else if (!ps2)
        {
            psmm = staticParticleSystems[1].main;
            index = 1;
            ps2 = true;
            psem1.rateOverTime = (ParticleSystem.MinMaxCurve)3.5;
            psem2.rateOverTime = (ParticleSystem.MinMaxCurve)3.5;
        }
        else if (!ps3)
        {
            psmm = staticParticleSystems[2].main;
            index = 2;
            ps3 = true;
            psem1.rateOverTime = (ParticleSystem.MinMaxCurve)2.33;
            psem2.rateOverTime = (ParticleSystem.MinMaxCurve)2.33;
            psem3.rateOverTime = (ParticleSystem.MinMaxCurve)2.33;
        }
        else if (!ps4)
        {
            psmm = staticParticleSystems[3].main;
            index = 3;
            ps4 = true;
            psem1.rateOverTime = (ParticleSystem.MinMaxCurve)1.75;
            psem2.rateOverTime = (ParticleSystem.MinMaxCurve)1.75;
            psem3.rateOverTime = (ParticleSystem.MinMaxCurve)1.75;
            psem4.rateOverTime = (ParticleSystem.MinMaxCurve)1.75;
        }
        else if (!ps5)
        {
            psmm = staticParticleSystems[4].main;
            index = 4;
            ps5 = true;
            psem1.rateOverTime = (ParticleSystem.MinMaxCurve)1.4;
            psem2.rateOverTime = (ParticleSystem.MinMaxCurve)1.4;
            psem3.rateOverTime = (ParticleSystem.MinMaxCurve)1.4;
            psem4.rateOverTime = (ParticleSystem.MinMaxCurve)1.4;
            psem5.rateOverTime = (ParticleSystem.MinMaxCurve)1.4;
        }
        else if (!ps6)
        {
            psmm = staticParticleSystems[5].main;
            index = 5;
            ps6 = true;
            psem1.rateOverTime = (ParticleSystem.MinMaxCurve)1.16;
            psem2.rateOverTime = (ParticleSystem.MinMaxCurve)1.16;
            psem3.rateOverTime = (ParticleSystem.MinMaxCurve)1.16;
            psem4.rateOverTime = (ParticleSystem.MinMaxCurve)1.16;
            psem5.rateOverTime = (ParticleSystem.MinMaxCurve)1.16;
            psem6.rateOverTime = (ParticleSystem.MinMaxCurve)1.16;
        }
        else if (!ps7)
        {
            psmm = staticParticleSystems[6].main;
            index = 6;
            ps7 = true;
            psem1.rateOverTime = 1;
            psem2.rateOverTime = 1;
            psem3.rateOverTime = 1;
            psem4.rateOverTime = 1;
            psem5.rateOverTime = 1;
            psem6.rateOverTime = 1;
            psem7.rateOverTime = 1;
        }
        psmm.startColor = color;
        staticParticleSystems[index].Play();
    }
}
