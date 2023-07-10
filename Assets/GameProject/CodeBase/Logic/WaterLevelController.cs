using System;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services;
using GameProject.CodeBase;
using UnityEngine;

namespace CodeBase.Logic
{
    public class WaterLevelController : MonoBehaviour
    {
        private GameControlSystem _gameControlSystem;
        private Pipe _pipe;
        private ITankParametersBox _tankParameters;
        
        private readonly float _flexiblePoint = 0.01f;
        private readonly float _stepRefill = 0.01f;

        private void Awake()
        {
            _gameControlSystem = Bootstrapper.Instance.GameControlSystem;
            _pipe = Bootstrapper.Instance.Pipe;
            _tankParameters = AllServices.Container.Single<ITankParametersBox>();
        }

        private void FixedUpdate()
        {
            if (CanCalibrate())
                CalibrateWaterLevel();
        }

        private void CalibrateWaterLevel()
        {
            float levelA = 1 - _tankParameters.GetTankFilledValue(TypeTank.A);
            float levelB = 1 - _tankParameters.GetTankFilledValue(TypeTank.B);

            if (levelA > levelB && ValidatePositionPipe(levelA * 100))
                CalibrateLevelAtoB();
            else if (levelB > levelA && ValidatePositionPipe(levelB * 100))
                CalibrateLevelBtoA();
        }

        private bool ValidatePositionPipe(float level) => 
            level > _pipe.PercentPosition;

        private bool CanCalibrate() =>
            !CheckValues() && IsOpenValve() && IsOtherProccessStop();

        private bool IsOtherProccessStop() =>
            !_gameControlSystem.isChangeWaterLevel && !_gameControlSystem.isChangePositionPipe;
        
        private bool IsOpenValve() => 
            _gameControlSystem.Valve.ValveStatus == ValveStatus.Open;

        private bool CheckValues() =>
            Math.Abs(_tankParameters.GetTankFilledValue(TypeTank.A) 
                     - _tankParameters.GetTankFilledValue(TypeTank.B)) <= _flexiblePoint;

        private void CalibrateLevelAtoB()
        {
            _tankParameters.SetTankFilledValue(TypeTank.A, _tankParameters.GetTankFilledValue(TypeTank.A) + _stepRefill);
            _tankParameters.SetTankFilledValue(TypeTank.B, _tankParameters.GetTankFilledValue(TypeTank.B) - _stepRefill);
            UpdateMaterials();
        }

        private void CalibrateLevelBtoA()
        {
            _tankParameters.SetTankFilledValue(TypeTank.A, _tankParameters.GetTankFilledValue(TypeTank.A) - _stepRefill);
            _tankParameters.SetTankFilledValue(TypeTank.B, _tankParameters.GetTankFilledValue(TypeTank.B) + _stepRefill);
            UpdateMaterials();
        }

        private void UpdateMaterials()
        {
            _gameControlSystem.SetCutOffToMaterial(_tankParameters.GetTankMaterial(TypeTank.A),
                _tankParameters.GetTankFilledValue(TypeTank.A));
            _gameControlSystem.SetCutOffToMaterial(_tankParameters.GetTankMaterial(TypeTank.B),
                _tankParameters.GetTankFilledValue(TypeTank.B));
        }
    }
}