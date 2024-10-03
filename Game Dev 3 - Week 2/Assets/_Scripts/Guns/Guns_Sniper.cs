using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevWithMarco.Guns
{
    public class Guns_Sniper : Guns_Parent
    {
        public override void GunSound()
        {
            gunAudioSource.pitch = Random.Range(0.6f, 1.4f);

            gunAudioSource.PlayOneShot(gunSound);
        }

        public override void MuzzleFlash()
        {
            base.MuzzleFlash();

            ParticleSystem.MainModule muzzleFlashParticles = muzzleFlash.GetComponent<ParticleSystem>().main;

            muzzleFlashParticles.startColor = Color.white;
        }
    }
}
