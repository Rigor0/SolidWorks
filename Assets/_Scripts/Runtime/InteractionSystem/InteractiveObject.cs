using TripleA.Runtime.Entity.Player;
using _Scripts.Runtime.Managers.UIManager;
using UnityEngine;
using TripleA.Core.Interfaces;

namespace _Scripts.Runtime.InteractionSystem
{
    public abstract class InteractiveObject : MonoBehaviour, IAnimatable
    {
        [SerializeField] string interactionPromptMessage;

        readonly string animationName = "isAnimating";
        public virtual bool CanBeInteracted { get; private set; }
        public Animator Animator { get; set; }

        void OnTriggerEnter(Collider other)
        {
            PlayerInteraction player = other.GetComponent<PlayerInteraction>();
            
            if (player != null)
            {
                CanBeInteracted = true;

                SetInteractableAnimation();

                player.AddInteractable(this);
            }
        }

        void OnTriggerExit(Collider other)
        {
            PlayerInteraction player = other.GetComponent<PlayerInteraction>();
            
            if (player != null)
            {
                CanBeInteracted = false;

                SetInteractableAnimation();

                player.RemoveInteractable(this);
            }
        }

        protected virtual void SetInteractableAnimation()
        {
            Animator.SetBool(animationName, CanBeInteracted);
        }

        protected virtual void DestroyedAnimation()
        {

        }

        public abstract void Interact(PlayerInteraction player);
    }
}

