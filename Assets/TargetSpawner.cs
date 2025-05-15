using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject[] targetPrefabs;
    public float interval = 3f;
    public Vector3 areaSize = new Vector3(10, 0, 10);
    private List<GameObject> activeTargets = new List<GameObject>();

    void Start()
    {
        // 一開始先生成 5 個
        for (int i = 0; i < 5; i++)
        {
            SpawnTarget();
        }

        // 每 interval 秒再產生 1 個
        InvokeRepeating("SpawnTarget", interval, interval);
    }

    void SpawnTarget()
    {
        // 隨機位置（限定在地面）
        Vector3 pos = new Vector3(
            Random.Range(-areaSize.x, areaSize.x),
            0.5f,
            Random.Range(-areaSize.z, areaSize.z)
        );

        // 隨機選一個 prefab
        GameObject prefab = targetPrefabs[Random.Range(0, targetPrefabs.Length)];
        GameObject newTarget = Instantiate(prefab, pos, Quaternion.identity);
        activeTargets.Add(newTarget);

        // 超過 5 個，就刪掉最舊的
        if (activeTargets.Count > 5)
        {
            Destroy(activeTargets[0]);
            activeTargets.RemoveAt(0);
        }
    }
}
