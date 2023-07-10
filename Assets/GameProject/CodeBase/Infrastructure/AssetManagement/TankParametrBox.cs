using System.Collections.Generic;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagement
{
    public class TankParametersBox : ITankParametersBox
    {
        private Dictionary<TypeTank, float> _tanksFilledValue;

        private Dictionary<TypeTank, Material> _tanksMaterials;

        public TankParametersBox()
        {
            _tanksFilledValue = new Dictionary<TypeTank, float>()
            {
                [TypeTank.A] = 0f,
                [TypeTank.B] = 0f,
            };
            
            _tanksMaterials = new Dictionary<TypeTank, Material>()
            {
                [TypeTank.A] = null,
                [TypeTank.B] = null,
            };
        }

        public float GetTankFilledValue(TypeTank type) => 
            type == TypeTank.A ? _tanksFilledValue[TypeTank.A] : _tanksFilledValue[TypeTank.B];
        
        public Material GetTankMaterial(TypeTank type) => 
            type == TypeTank.A ? _tanksMaterials[TypeTank.A] : _tanksMaterials[TypeTank.B];
        
        public Dictionary<TypeTank, float> GetDictionaryTankFilled() => 
            _tanksFilledValue;

        public void SetTankFilledValue(TypeTank type, float value)
        {
            if (type == TypeTank.A)
                _tanksFilledValue[TypeTank.A] = value;
            else
                _tanksFilledValue[TypeTank.B] = value;
        }
        
        public void SetTankMaterial(TypeTank type, Material material)
        {
            if (type == TypeTank.A)
                _tanksMaterials[TypeTank.A] = material;
            else
                _tanksMaterials[TypeTank.B] = material;
        }
            
    }
}