using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{
    [System.Serializable]
    private class ObjectInfo
    {
        // 오브젝트 이름
        public string objectName;
        // 오브젝트 풀에서 관리할 오브젝트
        public GameObject perfab;
        // 몇개를 미리 생성 해놓을건지
        public int count;
    }


    public static ObjectPoolManager Instance;

    [SerializeField]
    private ObjectInfo[] objectInfos = null;

    // 오브젝트풀들을 관리할 딕셔너리
    private Dictionary<string, IObjectPool<GameObject>> ojbectPoolDic = new Dictionary<string, IObjectPool<GameObject>>();

    // 오브젝트풀에서 오브젝트를 새로 생성할때 사용할 딕셔너리
    private Dictionary<string, GameObject> goDic = new Dictionary<string, GameObject>();

    private string objectName;

    public GameObject GetGO(string goName)
    {
        objectName = goName;
        return ojbectPoolDic[goName].Get();
    }

    public void Release(GameObject go, string goName)
    {
        ojbectPoolDic[goName].Release(go);
    }

    private void Awake() 
    {
        Instance = this;

        for(int i = 0; i < objectInfos.Length; ++i)
        {
            IObjectPool<GameObject> pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool,
                OnDestroyPoolObject, true, objectInfos[i].count, objectInfos[i].count);
            ojbectPoolDic.Add(objectInfos[i].objectName, pool);
            goDic.Add(objectInfos[i].objectName, objectInfos[i].perfab);

            GameObject[] _gos = new GameObject[objectInfos[i].count];
            for(int j = 0; j < objectInfos[i].count; ++j)
            {
                _gos[j] = GetGO(objectInfos[i].objectName);
            }

            for(int j = 0; j < objectInfos[i].count; ++j)
            {
                Release(_gos[j], objectInfos[i].objectName);
            }
        }
    }

    private void OnDestroy() 
    {
        Instance = null;
    }

   // 생성
    private GameObject CreatePooledItem()
    {
        GameObject poolGo = Instantiate(goDic[objectName]);
        return poolGo;
    }

    // 대여
    private void OnTakeFromPool(GameObject poolGo)
    {
        poolGo.SetActive(true);
    }

    // 반환
    private void OnReturnedToPool(GameObject poolGo)
    {
        poolGo.SetActive(false);
    }

    // 삭제
    private void OnDestroyPoolObject(GameObject poolGo)
    {
        Destroy(poolGo);
    }

}
