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
        if(Physics.Raycast(_player.transform.position, _delta, out RaycastHit hit, _delta.magnitude, LayerMask.GetMask("Wall")))
        {
            float dist = (hit.point - _player.transform.position).magnitude * 0.8f;
            transform.position = _player.transform.position + _delta.normalized * dist;
        }
        else
        {
            transform.position = _player.transform.position + _delta;
            transform.LookAt(_player.transform);
        }
    }
}
