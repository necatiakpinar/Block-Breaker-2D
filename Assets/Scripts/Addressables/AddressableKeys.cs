
namespace NecatiAkpinar.Addressables
{
    public static class AddressableKeys
    {
        public enum AssetKeys
        {
            //Scriptable Objects
            SO_LevelContainer,
            SO_VFXContainer,
            SO_SFXContainer,
            SO_TileMonoData,
            SO_GridData,
            
            //Sprite Atlasses
            SA_Bricks
        }
        public static string GetKey(AssetKeys key)
        {
            return key.ToString();
        }
    }

}