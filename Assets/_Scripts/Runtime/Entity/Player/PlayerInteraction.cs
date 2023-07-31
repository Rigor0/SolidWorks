using _Scripts.Runtime.InteractionSystem;
using UnityEngine;
using TripleA.Core;
using TripleA.Interactables;
namespace TripleA.Runtime.Entity.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        private void OnEnable()
        {
            //EventManager.OnPlayerInteracted += OnPlayerInteractedHandler;
        }

        //private void OnPlayerInteractedHandler(InteractiveObject @object)
        //{
            
        //}

        public void GetTreasure()
        {
            Debug.Log("Treasure getted");
        }

        public void AddInteractable(InteractiveObject interactable)
        {
            Debug.Log(interactable.name + "added.");
        }

        public void RemoveInteractable(InteractiveObject interactable)
        {
            Debug.Log(interactable.name + "removed.");
        }

        public void GetReward(int amount)
        {

        }
    }
}
