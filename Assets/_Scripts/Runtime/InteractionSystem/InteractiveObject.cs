using TripleA.Runtime.Entity.Player;
using UnityEngine;
using TripleA.Core.Interfaces;

namespace _Scripts.Runtime.InteractionSystem
{
    public abstract class InteractiveObject : MonoBehaviour, IAnimatable
    {
        [SerializeField] string interactionPromptMessage;

        protected PlayerInteraction player;

        readonly string animationName = "isAnimating";
        public virtual bool CanBeInteracted { get; private set; }
        public Animator Animator { get; set; }

        public enum InteractiveType
        {
            TreasureChest,
            MedicineBox
        }

        [SerializeField] InteractiveType _type;
        public InteractiveType Type => _type;
        void OnTriggerEnter(Collider other)
        {
            player = GetComponent<PlayerInteraction>();
            
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

