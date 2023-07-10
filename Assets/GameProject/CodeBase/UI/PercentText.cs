using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services;
using CodeBase.Logic;
using TMPro;
using UnityEngine;

namespace CodeBase.UI
{
    public class PercentText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _percentValue;
        [SerializeField] private TypeTank _typeTank;
        private GameControlSystem _gameControlSystem;

        private ITankParametersBox _tankParameters;
        
        private void Awake()
        {
            _gameControlSystem = Bootstrapper.Instance.GameControlSystem;
            _tankParameters = AllServices.Container.Single<ITankParametersBox>();
            _gameControlSystem.OnChangePercent += UpdateValues;
        }

        private void OnDestroy() => 
            _gameControlSystem.OnChangePercent -= UpdateValues;

        private void OnEnable() => 
            UpdateValues();

        private void UpdateValues() => 
            _percentValue.text = GetPercent(_typeTank) + " %";

        private string GetPercent(TypeTank type)
        {
            float percentValue = 0f;
            _tankParameters.GetDictionaryTankFilled().TryGetValue(_typeTank, out float value);
            percentValue = (1 - value) * 100;
            return percentValue.ToString("0.0");
        }
    }
}