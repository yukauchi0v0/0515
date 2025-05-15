using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))  // 如果碰到的是有「Target」標籤的物件
        {
            Destroy(other.gameObject);   // 把它刪除
        }
    }
}
