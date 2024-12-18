using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevWithMarco.Guns
{
    public class Guns_Shotgun : Guns_Parent
    {
        public override void GunSound()
        {
            gunAudioSource.pitch = Random.Range(1f, 1.5f);

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
