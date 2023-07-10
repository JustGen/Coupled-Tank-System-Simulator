using CodeBase.Logic;
using GameProject.CodeBase;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.UI
{
    public class TankElementButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler
    {
        [SerializeField] private TankUIController _tankUIController;
        [SerializeField] private bool _isPlus;

        private bool _isChangerInWindow;
        private bool _isPressed;

        private GameControlSystem _gameControlSystem;

        private void Awake() => 
            _gameControlSystem = Bootstrapper.Instance.GameControlSystem;

        private void Start()
        {
            _isChangerInWindow = true;
            _isPressed = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isPressed = true;
            _gameControlSystem.isChangeWaterLevel = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isPressed = false;
            _gameControlSystem.isChangeWaterLevel = false;
        }

        public void OnPointerEnter(PointerEventData eventData) => 
            _isChangerInWindow = true;

        public void OnPointerExit(PointerEventData eventData) => 
            _isChangerInWindow = false;

        private void FixedUpdate()
        {
            if (!_isChangerInWindow || !_isPressed)
                return;
            
            Pressing();
        }

        private void Pressing()
        {
            if (_isPlus)
                _tankUIController.OnUp();
            else
                _tankUIController.OnDown();
        }
    }
}