using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.T)) move += Vector3.forward;
        if (Input.GetKey(KeyCode.G)) move += Vector3.back;
        if (Input.GetKey(KeyCode.F)) move += Vector3.left;
        if (Input.GetKey(KeyCode.H)) move += Vector3.right;

        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            Destroy(other.gameObject);
        }
    }
    
}
