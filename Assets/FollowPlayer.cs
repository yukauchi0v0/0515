using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;               // 拖進 Player
    public Vector3 offset = new Vector3(0, 2, -5); // 攝影機與玩家的相對位置

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
            transform.LookAt(player); // 若你想讓攝影機看著 Player，可以保留這行
        }
    }
}
