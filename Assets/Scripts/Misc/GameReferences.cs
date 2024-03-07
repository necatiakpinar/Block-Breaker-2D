using Cysharp.Threading.Tasks;
using NecatiAkpinar.Addressables;
using NecatiAkpinar.Controllers;
using NecatiAkpinar.Data;
using NecatiAkpinar.Managers;
using UnityEngine;

namespace NecatiAkpinar.Miscs
{
    public class GameReferences : MonoBehaviour
    {
        private GridController _gridController;
        public GridController GridController => _gridController;

        private bool _isLoaded;

        public static GameReferences Instance;

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this);
            else
                Instance = this;
        }

        public void Start()
        {
            var levels = DataManager.Instance.LevelContainer;
            var tileMonoData = DataManager.Instance.TileMonoData;
            var gridData = DataManager.Instance.GridData;
            _gridController = new GridController(levels, tileMonoData, gridData);
            
        }
    }
}