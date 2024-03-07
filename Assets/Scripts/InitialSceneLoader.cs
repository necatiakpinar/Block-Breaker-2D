using Cysharp.Threading.Tasks;
using NecatiAkpinar.Managers;
using NecatiAkpinar.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NecatiAkpinar
{
    public class InitialSceneLoader : MonoBehaviour
    {
        private async UniTask Start()
        {
            await DataManager.Instance.LoadAddressableData();
            LoadGameplayScene();
        }

        private void LoadGameplayScene()
        {
            SceneManager.LoadScene(Constants.GAMEPLAY_SCENE);
        }
    }
}