using System.Collections.Generic;
using NecatiAkpinar.Data;
using UnityEngine;

namespace NecatiAkpinar.Data
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Containers/LevelContainer", fileName = "SO_LevelContainer", order = 1)]
    public class SO_LevelDataContainer : ScriptableObject
    {
        [SerializeField] private List<SO_LevelData> _allLevels;
        public List<SO_LevelData> AllLevels => _allLevels;
        
    }
}