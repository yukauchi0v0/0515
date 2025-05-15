using UnityEngine;

public class StackAndSpin : MonoBehaviour
{
    public GameObject blockPrefab;     // 拖入 prefab
    public int count = 30;             // 幾層
    public float spacing = 0.2f;       // 每層間距
    public Transform parent;           // 堆疊物件的容器
    private bool rotating = false;

    void Update()
    {
        // Z 鍵：生成堆疊
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GenerateStack();
        }

        // X 鍵：開始/停止自轉
        if (Input.GetKeyDown(KeyCode.X))
        {
            rotating = !rotating;
        }

        // 自轉（原地）
        if (rotating && parent != null)
        {
            parent.Rotate(Vector3.up * 30f * Time.deltaTime, Space.Self);
        }
    }

    void GenerateStack()
    {
        // 重設 parent 位置與旋轉，確保軸心正確
        parent.position = Vector3.zero;
        parent.rotation = Quaternion.identity;

        // 清空原本堆疊
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }

        // 垂直堆疊生成（相對於 parent）
        for (int i = 0; i < count; i++)
        {
            Vector3 localPos = new Vector3(0, i * spacing, 0);
            GameObject block = Instantiate(blockPrefab, parent);
            block.transform.localPosition = localPos;
        }
    }
}
