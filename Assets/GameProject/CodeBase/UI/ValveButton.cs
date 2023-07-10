using CodeBase.Logic;
using GameProject.CodeBase;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    [RequireComponent(typeof(Button))]
    public class ValveButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private bool isOpen;

        private GameControlSystem _gameControlSystem;
        
        private void Start()
        {
            _gameControlSystem = Bootstrapper.Instance.GameControlSystem;
            _button.onClick.AddListener(OnTap);
        }

        private void OnTap()
        {
            if (isOpen)
                ValveOn();
            else
                ValveOff();
        }

        private void ValveOn() => 
            _gameControlSystem.Valve.ChangeValveStatus(true);

        private void ValveOff() => 
            _gameControlSystem.Valve.ChangeValveStatus(false);
    }
}