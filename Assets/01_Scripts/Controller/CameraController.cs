using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 _delta;
    public GameObject _player;


    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void LateUpdate()
    {
        transform.position = _player.transform.position + _delta;
        transform.rotation = Quaternion.Euler(60, 0, 0);
        transform.LookAt(_player.transform);
    }
}
