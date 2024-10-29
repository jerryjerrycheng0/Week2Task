using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevWithMarco.Guns
{
    public class Guns_BigGun : Guns_Parent
    {
        public override void GunSound()
        {
            gunAudioSource.pitch = Random.Range(0.2f, 0.5f); //Big guns has deep sounds

            gunAudioSource.PlayOneShot(gunSound);
        }

        public override void MuzzleFlash()
        {
            base.MuzzleFlash(); //Overrides the original MuzzleFlash method

            ParticleSystem.MainModule muzzleFlashParticles = muzzleFlash.GetComponent<ParticleSystem>().main;

            muzzleFlashParticles.startColor = Color.white;
        }
    }
}
