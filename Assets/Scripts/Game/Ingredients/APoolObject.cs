using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace CubeDefense
{
    /***
     * Base class for objects that need a pool reference to release'em (Don't use Destroy on this gameobjects)
     * */
    public abstract class APoolObject<T> : MonoBehaviour where T : Component
    {
        private IObjectPool<T> pool;
        public IObjectPool<T> Pool 
        { 
            get => pool; 
            set => pool = value; 
        }

        public void Release()
        {
            pool.Release(this as T);
        }
    }
}
