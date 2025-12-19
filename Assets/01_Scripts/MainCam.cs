using UnityEngine;

public class MainCam : MonoBehaviour
{
    public Vector3 offset;

    PlayerController _player;
    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
    }

    void LateUpdate()
    {
        transform.position = _player.transform.position + offset;

    }
}
