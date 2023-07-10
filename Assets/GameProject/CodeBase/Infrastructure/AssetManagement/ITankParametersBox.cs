using System.Collections.Generic;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagement
{
    public interface ITankParametersBox : IService
    {
        float GetTankFilledValue(TypeTank type);
        Material GetTankMaterial(TypeTank type);
        public Dictionary<TypeTank, float> GetDictionaryTankFilled();
        void SetTankFilledValue(TypeTank type, float value);
        void SetTankMaterial(TypeTank type, Material material);
    }
}