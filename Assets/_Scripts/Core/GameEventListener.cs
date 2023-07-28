
using TripleA.Runtime.Entity.Player;
using TripleA.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace TripleA.Core
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent GameEvent;
        public UnityEvent Response;

        private void OnEnable() => GameEvent.RegisterListener(this);

        private void OnDisable() => GameEvent?.UnregisterListener(this);

        public void OnEventRaised()
        {
            Response?.Invoke();
        }
    }
}
