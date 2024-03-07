using System.Collections.Generic;
using UnityEngine;

namespace NecatiAkpinar.Data
{
    [System.Serializable]
    public class GameSFX
    {
        [SerializeField] private string key;
        [SerializeField] private AudioClip _clip;
        public string Name => key;
        public AudioClip Clip => _clip;
    }

    [CreateAssetMenu(fileName = "SO_SFXContainer", menuName = "ScriptableObjects/Containers/SFXContainer", order = 3)]
    public class SO_SFXDataContainer : ScriptableObject
    {
        [SerializeField] private List<GameSFX> _gameplaySFXes;

        public List<GameSFX> GameplaySFXes => _gameplaySFXes;
    }
}