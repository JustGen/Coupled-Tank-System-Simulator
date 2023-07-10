using GameProject.CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        public Material GetMaterial(string pathTankA, string pathTankB, TypeTank typeTank) =>
            Resources.Load<Material>(typeTank == TypeTank.A
                ? pathTankA
                : pathTankB);
    }
}