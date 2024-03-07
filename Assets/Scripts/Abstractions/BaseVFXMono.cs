using System.Collections;
using UnityEngine;

namespace NecatiAkpinar.Abstractions
{
    public abstract class BaseVFXMono : MonoBehaviour
    {
        protected string _vfxKey;
        public virtual void Init(string key)
        {
            _vfxKey = key;
            gameObject.SetActive(false);
        }
        
        public virtual IEnumerator Play()
        {
            yield break;
        }
        
    }
}