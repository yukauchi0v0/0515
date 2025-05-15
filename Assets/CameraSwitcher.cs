using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera cameraFollow;
    public Camera cameraTopDown;

    void Start()
    {
        ActivateFollowView(); // 初始啟用第三人稱
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            bool isFollow = cameraFollow.enabled;
            cameraFollow.enabled = !isFollow;
            cameraTopDown.enabled = isFollow;
        }
    }

    void ActivateFollowView()
    {
        cameraFollow.enabled = true;
        cameraTopDown.enabled = false;
    }
}
