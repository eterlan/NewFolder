using System;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ECS.Test
{
    public class TestMono : MonoBehaviour
    {
        private PlayerInputConfig m_inputConfig;
        private Camera            m_camera;

        [Button]
        public void Test()
        {
            m_inputConfig                         ??= new PlayerInputConfig();
            m_inputConfig.Enable();
            m_inputConfig.GamePlay.Fire.started   += context => Debug.Log("start");
            m_inputConfig.GamePlay.Fire.performed += context => Debug.Log("perf");
            m_inputConfig.GamePlay.Fire.canceled  += context => Debug.Log("cancelled");
            m_camera                              =  Camera.main;
            EditorApplication.update += () =>
            {

            };
            m_inputConfig.GamePlay.MousePos.performed += _ =>
            {
                var pos  = m_inputConfig.GamePlay.MousePos.ReadValue<Vector2>();
                var pos2 = m_camera.ScreenToWorldPoint(pos);
                Debug.Log(pos2);
            };
        }

        private void Update()
        {
            
        }

        public  AssetReferenceT<GameObject>      prefabRef;
        public  AsyncOperationHandle<GameObject> prefabHandle, instantiateHandle;
        private GameObject                       m_prefab;

        public GameObject                       instance;
        public bool                             defaultInstantiate;
        [Button]
        public async void TestTemp()
        {
            if (!prefabHandle.IsValid())
            {
                prefabHandle = Addressables.LoadAssetAsync<GameObject>(prefabRef);
            }

            m_prefab = await prefabHandle;
            if (defaultInstantiate)
            {
                instance = Instantiate(m_prefab);
            }
            else
            {
                instantiateHandle = prefabRef.InstantiateAsync();
            }
            //prefabHandle.Completed += operationHandle =>
            {
                // var prefab = operationHandle.Result;
                // if (defaultInstantiate)
                // {
                //     instance = Instantiate(prefab);
                // }
                // else
                // {
                //     instantiateHandle = prefabRef.InstantiateAsync();
                // }
            };
        }

        public bool assetOrHandle;
        [Button]
        public void TestUnloadAsset()
        {
            if (assetOrHandle)
            {
                Addressables.Release(m_prefab);
            }
            Addressables.Release(prefabHandle);
        }

        [Button]
        public void TestUnloadInstance()
        {
            if (assetOrHandle)
            {
                Addressables.ReleaseInstance(instance);
            }
            else
            {
                Addressables.ReleaseInstance(instantiateHandle);
            }
            // var type  = handle.GetType();
            // var field = type.GetField("ReferenceCount", BindingFlags.NonPublic | BindingFlags.Instance);
            // var count = field.GetValue(handle);
            // Debug.Log(count);
        }

        [Button]
        public void TestChangeScene()
        {
            Addressables.LoadSceneAsync("NewScene");
        }

        public  int    time = 1000;

        [Button]
        public async void TestTask()
        {
            await NewTask();
            // try
            // {
            //     await NewTask();
            // }
            // catch (Exception e)
            // {
            //     Debug.Log(e);
            //     throw;
            // }
            Debug.Log("end");
        }

        private async UniTask NewTask()
        {
            Debug.Log("1");
            await UniTask.Delay(time);
            Debug.Log("2");
            await UniTask.Delay(time);
        }

        // public async void Start()
        // {
        //     Debug.Log("Test");
        //     await UniTask.Create(() => { throw new NotImplementedException("test"); });
        //     await UniTask.Create(() => { throw new NotImplementedException("test 2"); });
        // }
    }
}