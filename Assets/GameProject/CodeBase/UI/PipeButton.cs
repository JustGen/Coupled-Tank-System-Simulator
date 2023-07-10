using CodeBase.Logic;
using GameProject.CodeBase;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.UI
{
    public class PipeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler
    {
        [SerializeField] private bool _isUp;

        private bool _isChangerInWindow;
        private bool _isPressed;
        
        private GameControlSystem _gameControlSystem;
        private Pipe _pipe;

        private void Awake()
        {
            _gameControlSystem = Bootstrapper.Instance.GameControlSystem;
            _pipe = Bootstrapper.Instance.Pipe;
        }

        private void Start()
        {
            _isChangerInWindow = true;
            _isPressed = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isPressed = true;
            _gameControlSystem.isChangePositionPipe = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isPressed = false;
            _gameControlSystem.isChangePositionPipe = false;
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
            if (_isUp)
                _pipe.OnUp();
            else
                _pipe.OnDown();
        }
    }
}