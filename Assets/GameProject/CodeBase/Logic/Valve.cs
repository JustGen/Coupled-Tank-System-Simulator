using System;
using GameProject.CodeBase;
using UnityEngine;

namespace CodeBase.Logic
{
    public class Valve : MonoBehaviour
    {
        [SerializeField] private GameObject _closeState;
        [SerializeField] private GameObject _openState;
        
        public event Action<ValveStatus> OnChanged;

        public void Awake() =>
            Close();

        public ValveStatus ValveStatus { get; set; }
        
        public void ChangeValveStatus(bool isOpen)
        {
            ValveStatus = isOpen ? Open() : Close();
            OnChanged?.Invoke(ValveStatus);
        }

        private ValveStatus Close()
        {
            _closeState.SetActive(true);
            _openState.SetActive(false);
            return ValveStatus.Close;
        }

        private ValveStatus Open()
        {
            _closeState.SetActive(false);
            _openState.SetActive(true);
            return ValveStatus.Open;
        }
    }
}
