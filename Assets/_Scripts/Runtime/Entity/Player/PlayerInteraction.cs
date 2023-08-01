using _Scripts.Runtime.InteractionSystem;
using UnityEngine;
using TripleA.Core;
using TripleA.Interactables;
using System.Collections.Generic;
using System.Linq;

namespace TripleA.Runtime.Entity.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        List<InteractiveObject> _interactables = new List<InteractiveObject>();

        public void AddInteractable(InteractiveObject interactable)
        {
            _interactables.Add(interactable);
        }

        public void RemoveInteractable(InteractiveObject interactable)
        {
            _interactables.Remove(interactable);
        }

        public void Interact()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                var interactable = _interactables.FirstOrDefault();

                if (interactable != null)
                {
                    if(interactable.CanBeInteracted)
                        interactable.Interact(this);
                }
            }
        }

        private void Update()
        {
            Interact();
        }
    }
}
