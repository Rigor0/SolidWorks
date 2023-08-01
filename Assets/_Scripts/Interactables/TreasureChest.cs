using _Scripts.Runtime.InteractionSystem;
using UnityEngine;
using TripleA.Runtime.Entity.Player;
using TripleA.Runtime.Managers;

namespace TripleA.Interactables
{
    public class TreasureChest : InteractiveObject
    {
        public int rewardAmount;

        private bool _wasOpened;

        public override bool CanBeInteracted
        {
            get { return base.CanBeInteracted && _wasOpened == false; }
        }


        void Start()
        {
            Animator = GetComponent<Animator>();
            AudioSource = GetComponent<AudioSource>();
        }

        public override void Interact(PlayerInteraction player)
        {
            _wasOpened = true;

            AudioManager.Instance.StopInteractableSound(AudioSource);

            Animator.SetTrigger("isInteracted");
        }
    }
}
