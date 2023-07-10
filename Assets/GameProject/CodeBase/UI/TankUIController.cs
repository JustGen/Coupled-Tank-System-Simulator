using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services;
using CodeBase.Logic;
using GameProject.CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

namespace CodeBase.UI
{
    public class TankUIController : MonoBehaviour
    {
        [SerializeField] private TypeTank _typeTank;

        private Material _materialTank;
        private float _cutOff;
        private readonly float _stepCutOff = 0.001f;

        private GameControlSystem _gameControlSystem;
        private IAssetProvider _assets;
        private ITankParametersBox _tankParameters;
        
        private float CutOff
        {
            get
            {
                _cutOff = _tankParameters.GetTankFilledValue(_typeTank);
                return _cutOff;
            }
            set
            {
                _cutOff = value;
                _tankParameters.SetTankFilledValue(_typeTank, _cutOff);
                _gameControlSystem.InvokeActions();
            }
        }

        private void Awake()
        {
            _gameControlSystem = Bootstrapper.Instance.GameControlSystem;
            _assets = AllServices.Container.Single<IAssetProvider>();
            _tankParameters = AllServices.Container.Single<ITankParametersBox>();
            
            LoadMaterialForTank();
            _gameControlSystem.LoadValueCutoff(_materialTank, out _cutOff);
            CutOff = _cutOff;
        }

        public void OnUp()
        {
            CutOff -= _stepCutOff;

            if (CutOff < 0)
            {
                CutOff = 0f;
                _gameControlSystem.SetCutOffToMaterial(_materialTank, CutOff);
            }
            else
            {
                _gameControlSystem.SetCutOffToMaterial(_materialTank, CutOff);
            }
        }

        public void OnDown()
        {
            CutOff += _stepCutOff;
            
            if (CutOff > 1)
            {
                CutOff = 1f;
                _gameControlSystem.SetCutOffToMaterial(_materialTank, CutOff);
            }
            else
            {
                _gameControlSystem.SetCutOffToMaterial(_materialTank, CutOff);
            }
        }

        private void LoadMaterialForTank()
        {
            _materialTank = _assets.GetMaterial(AssetPath.PathMaterialA, AssetPath.PathMaterialB, _typeTank);

            if (_typeTank == TypeTank.A)
                _tankParameters.SetTankMaterial(_typeTank, _materialTank);
            else
                _tankParameters.SetTankMaterial(_typeTank, _materialTank);
        }
    }
}