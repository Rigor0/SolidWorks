using TripleA.Core;
using TMPro;
using UnityEngine;

namespace TripleA.Runtime.Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] TMP_Text _prompt;
        public void ShowPrompt(string prompt)
        {
            _prompt.text = prompt;
        }

        public void HidePrompt()
        {
            _prompt.text = null;
        }
    }
}
