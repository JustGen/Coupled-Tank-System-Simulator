using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services;
using CodeBase.Logic;
using GameProject.CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

namespace CodeBase
{
    public class Bootstrapper : MonoBehaviour
    {
        private static Bootstrapper _instance;
        public static Bootstrapper Instance => _instance;

        private void Awake()
        {
            _instance = this;
            RegisterServices();
        }

        private void RegisterServices()
        {
            AllServices.Container.RegisterSingle<ITankParametersBox>(new TankParametersBox());
            AllServices.Container.RegisterSingle<IAssetProvider>(new AssetProvider());
        }

        [SerializeField] private GameControlSystem _gameControlSystem;
        [SerializeField] private Pipe _pipe;

        public GameControlSystem GameControlSystem => 
            _gameControlSystem;
        
        public Pipe Pipe => 
            _pipe;
    }
}