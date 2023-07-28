using TripleA.Runtime.Entity.Player;
using _Scripts.Runtime.InteractionSystem;
using UnityEngine;

namespace TripleA.Interactables
{
    public class TreasureChest : InteractiveObject
    {
        private bool _wasOpened;

        public override bool CanBeInteracted
        {
            get { return base.CanBeInteracted && _wasOpened == false; }
        }
        void Start()
        {
            Animator = GetComponent<Animator>();       
        }
        public override void Interact(PlayerInteraction player)
        {
            _wasOpened = true;

            Debug.Log("Interacted");
        }

        protected override void DestroyedAnimation()
        {
            base.DestroyedAnimation();

            
        }
    }
}
