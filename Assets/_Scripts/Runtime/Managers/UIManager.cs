using TripleA.Core;
using TMPro;
using UnityEngine;

namespace _Scripts.Runtime.Managers.UIManager
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] TMP_Text _prompt;
        public void ShowPromt(string prompt)
        {
            _prompt.text = prompt;
        }

        public void HidePromt()
        {
            _prompt.text = null;
        }
    }
}
