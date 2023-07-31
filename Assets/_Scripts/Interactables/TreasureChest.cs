using _Scripts.Runtime.InteractionSystem;
using UnityEngine;
using TripleA.Core;
using TripleA.Runtime.Entity.Player;

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
        }

        public override void Interact(PlayerInteraction playerInteraction)
        {
            _wasOpened = true;

            playerInteraction = player;

            player.GetTreasure();
            //EventManager.OnPlayerInteracted?.Invoke(this);
        }
    }
}
