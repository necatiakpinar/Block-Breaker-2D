using System.Collections.Generic;
using NecatiAkpinar.Abstractions;
using UnityEngine;

namespace NecatiAkpinar.Data
{
    [System.Serializable]
    public class GameVFX
    {
        [SerializeField] private string key;
        [SerializeField] private BaseVFXMono _vfxObject;
        [SerializeField] private bool _isPoolObject;
        [SerializeField] private int _poolSize;

        public string Key => key;
        public BaseVFXMono VfxObject => _vfxObject;
        public bool IsPoolObject => _isPoolObject;
        public int PoolSize => _poolSize;
    }

    [CreateAssetMenu(menuName = "ScriptableObjects/Containers/VFXContainer", fileName = "SO_VFXContainer", order = 2)]
    public class SO_VFXDataContainer : ScriptableObject
    {
        [SerializeField] private List<GameVFX> _gameplayVFXes;

        public List<GameVFX> GameplayVFXes => _gameplayVFXes;
    }
}