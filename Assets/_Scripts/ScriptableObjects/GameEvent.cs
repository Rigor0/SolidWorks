﻿using System.Collections.Generic;
using TripleA.Core;
using UnityEngine;

namespace TripleA.ScriptableObjects
{
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener> _listeners = new List<GameEventListener>();
        public void Raise()
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised();
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            if(!_listeners.Contains(listener)) _listeners.Add(listener);
        }


        public void UnregisterListener(GameEventListener listener)
        {
            if(_listeners.Contains(listener)) _listeners.Remove(listener);
        }
    }
}
