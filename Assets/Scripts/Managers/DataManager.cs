using Cysharp.Threading.Tasks;
using NecatiAkpinar.Addressables;
using NecatiAkpinar.Data;
using NecatiAkpinar.Misc;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

namespace NecatiAkpinar.Managers
{
    public class DataManager : Singleton<DataManager>
    {
        private SO_LevelDataContainer _levelContainer;
        private SO_SFXDataContainer _sfxContainer;
        private SO_VFXDataContainer _vfxContainer;
        private SO_TileMonoData _tileMonoData;
        private SO_GridData _gridData;

        private SpriteAtlas _brickSpriteAtlas;
        public SO_LevelDataContainer LevelContainer => _levelContainer;
        public SO_SFXDataContainer SFXContainer => _sfxContainer;
        public SO_VFXDataContainer VFXContainer => _vfxContainer;
        public SO_TileMonoData TileMonoData => _tileMonoData;
        public SO_GridData GridData => _gridData;

        public SpriteAtlas BrickSpriteAtlas => _brickSpriteAtlas;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            
        }

        public async UniTask LoadAddressableData()
        {
            //Scriptable Objects
            _levelContainer = await AddressableLoader.LoadAssetAsync<SO_LevelDataContainer>(AddressableKeys.GetKey(AddressableKeys.AssetKeys.SO_LevelContainer));
            _sfxContainer = await AddressableLoader.LoadAssetAsync<SO_SFXDataContainer>(AddressableKeys.GetKey(AddressableKeys.AssetKeys.SO_SFXContainer));
            _vfxContainer = await AddressableLoader.LoadAssetAsync<SO_VFXDataContainer>(AddressableKeys.GetKey(AddressableKeys.AssetKeys.SO_VFXContainer));
            _tileMonoData = await AddressableLoader.LoadAssetAsync<SO_TileMonoData>(AddressableKeys.GetKey(AddressableKeys.AssetKeys.SO_TileMonoData));
            _gridData = await AddressableLoader.LoadAssetAsync<SO_GridData>(AddressableKeys.GetKey(AddressableKeys.AssetKeys.SO_GridData));
             
            //Sprite Atlasses
            _brickSpriteAtlas = await AddressableLoader.LoadAssetAsync<SpriteAtlas>(AddressableKeys.GetKey(AddressableKeys.AssetKeys.SA_Bricks));

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}