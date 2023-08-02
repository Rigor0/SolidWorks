using TripleA.Core;
using TMPro;
using UnityEngine;
using System;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using TripleA.Runtime.Entity.Player.Controller;

namespace TripleA.Runtime.Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] TMP_Text m_prompt;

        [SerializeField] CanvasGroup m_retical;

        void OnEnable()
        {
            EventManager.OnPlayerAimed += OnPlayerAimedHandler;
        }
        void OnDisable()
        {
            EventManager.OnPlayerAimed -= OnPlayerAimedHandler;
        }

        private void OnPlayerAimedHandler(bool isAiming)
        {
            ShowRetical(isAiming);
        }

        public void ShowPrompt(string prompt)
        {
            m_prompt.text = prompt;
        }

        public void HidePrompt()
        {
            m_prompt.text = null;
        }

        void ShowRetical(bool isAiming)
        {
            m_retical.alpha = isAiming ? 1 : 0;
        }


    }
}
