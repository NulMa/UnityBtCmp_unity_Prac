using UnityEngine;

public class MainCam : MonoBehaviour
{
    public Vector3 offset;
    public Vector3 _velocity;

    public float _smooth = 0.3f;


    PlayerController _player;
    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
    }

    void LateUpdate()
    {
        //
        if(Input.GetMouseButton(0))
        {
            //Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            //Vector3 dir = mousePos - Camera.main.transform.position;
            //dir = dir.normalized;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red, 1);

            LayerMask mask = LayerMask.GetMask("Monster", "Wall");

            if (Physics.Raycast(ray, out RaycastHit hit, Define.CLICK_LAYER))
            {
                Debug.Log("Hit Point: " + hit.collider.gameObject.name);
            }
        }
        //
        transform.position = _player.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, _player.transform.position + offset, ref _velocity, _smooth);
    }
}
