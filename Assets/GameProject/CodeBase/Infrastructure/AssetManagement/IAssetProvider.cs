using CodeBase;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace GameProject.CodeBase.Infrastructure.AssetManagement
{
    public interface IAssetProvider : IService
    {
        Material GetMaterial(string pathTankA, string pathTankB, TypeTank typeTank);
    }
}