using System.Collections;
using System.Collections.Generic;
using TripleA.Core;
using UnityEngine;

namespace TripleA.Runtime.Managers
{
    public class AudioManager : Singleton<AudioManager>
    {
        public void PlayInteractableSound(AudioSource audioSource)
        {
            audioSource.Play();
        }

        public void StopInteractableSound(AudioSource audioSource)
        {
            audioSource.Stop();
        }
    }
}
