using _Scripts.Runtime.InteractionSystem;
using System;
using UnityEngine;

namespace TripleA.Runtime.Entity.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        public void AddInteractable(InteractiveObject interactable)
        {
            Debug.Log(interactable.name + "added.");
        }

        public void RemoveInteractable(InteractiveObject interactable)
        {
            Debug.Log(interactable.name + "removed.");
        }

        public void 
    }
}
