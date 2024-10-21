using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevWithMarco.Guns
{
    public class Guns_Sniper : Guns_Parent
    {
        public float muzzleFlashDelay = 0.1f;  // Delay time in seconds before showing the muzzle flash

        public override void GunSound()
        {
            gunAudioSource.pitch = Random.Range(0.6f, 1.4f);
            gunAudioSource.PlayOneShot(gunSound);
        }

        public override void MuzzleFlash()
        {
            // Start a coroutine to introduce a delay before showing the muzzle flash
            StartCoroutine(DelayedMuzzleFlash());
        }

        // Coroutine to handle the muzzle flash delay
        private IEnumerator DelayedMuzzleFlash()
        {
            // Wait for the specified delay time
            yield return new WaitForSeconds(muzzleFlashDelay);

            // Call the base MuzzleFlash() after the delay
            base.MuzzleFlash();

            // Change the muzzle flash particle color after the base method runs
            ParticleSystem.MainModule muzzleFlashParticles = muzzleFlash.GetComponent<ParticleSystem>().main;
            muzzleFlashParticles.startColor = Color.white;
        }
    }
}
