using TripleA.Runtime.Entity.Player;
using UnityEngine;
using TripleA.Core.Interfaces;
using TripleA.Runtime.Managers;
using TripleA.Core;

namespace _Scripts.Runtime.InteractionSystem
{
    [RequireComponent(typeof(Animator),typeof(AudioSource))]
    public abstract class InteractiveObject : MonoBehaviour, IAnimatable, ISoundable
    {
        [SerializeField] string _prompt;

        readonly string animationName = "isAnimating";
        public virtual bool CanBeInteracted { get; private set; }
        public Animator Animator { get; set; }
        public AudioSource AudioSource { get; set; }

        void OnTriggerEnter(Collider other)
        {
            PlayerInteraction player = other.GetComponent<PlayerInteraction>();
            
            if (player != null)
            {
                CanBeInteracted = true;

                SetInteractableAnimation();

                if (CanBeInteracted)
                {
                    AudioManager.Instance.PlayInteractableSound(AudioSource);

                    UIManager.Instance.ShowPrompt(_prompt);
                }
                
                player.AddInteractable(this);
            }
        }

        void OnTriggerExit(Collider other)
        {
            PlayerInteraction player = other.GetComponent<PlayerInteraction>();
            
            
            if (player != null)
            {
                CanBeInteracted = false;

                AudioManager.Instance.StopInteractableSound(AudioSource);

                SetInteractableAnimation();

                UIManager.Instance.HidePrompt();

                player.RemoveInteractable(this);
            }
        }

        protected virtual void SetInteractableAnimation()
        {
            Animator.SetBool(animationName, CanBeInteracted);
        }

        public abstract void Interact(PlayerInteraction player);
    }
}

