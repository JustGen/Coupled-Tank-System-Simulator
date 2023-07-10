using System;
using UnityEngine;

namespace CodeBase.Logic
{
    public class GameControlSystem : MonoBehaviour
    {
        private const string CutoffParametr = "_Cutoff";
        
        [SerializeField] private Valve _valve;
        public Valve Valve => _valve;
        public bool isChangeWaterLevel { get; set; }
        public bool isChangePositionPipe { get; set; }

        public event Action OnChangePercent;

        private void Awake()
        {
            isChangeWaterLevel = false;
            Subscribers();
        }

        private void OnDestroy() =>
            UnSubscribers();

        public void SetCutOffToMaterial(Material materialTank, float cutOff)
        {
            materialTank.SetFloat(CutoffParametr, cutOff);
            InvokeActions();
        }

        public void LoadValueCutoff(Material materialTank, out float cutOff)
            => cutOff = materialTank.GetFloat(CutoffParametr);

        public void InvokeActions() => 
            OnChangePercent?.Invoke();
        
        private void Subscribers()
        {
            Valve.OnChanged += ValveChanged;
        }

        private void UnSubscribers()
        {
            Valve.OnChanged -= ValveChanged;
        }

        private static void ValveChanged(ValveStatus type) => 
            Debug.Log(type.ToString());
    }
}