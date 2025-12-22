using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float _speed = 10.0f;
    public bool _moveToDest = false;

    LayerMask mask;
    Vector3 _destpos;


    private void Start()
    {
        mask = LayerMask.GetMask("Monster", "Wall");
        Managers.Input.MouseAction += OnMouseClicked;
    }

    private void FixedUpdate()
    {
        if (_moveToDest)
        {
            Vector3 dir = _destpos - transform.position;
            if(dir.magnitude < 0.1f)
            {
                _moveToDest = false;
            }
            else
            {
                dir.Normalize();
                transform.position += dir * _speed * Time.fixedDeltaTime;
                transform.LookAt(_destpos);
            }
        }
    }

    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (evt == Define.MouseEvent.Click)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, mask))
        {
            _destpos = hit.point;
            _moveToDest = true;
        }
    }
}
