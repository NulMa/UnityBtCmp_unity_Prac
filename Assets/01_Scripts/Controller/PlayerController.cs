using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;

    private LayerMask mask;
    private Vector3 _destPos;

    Animator _anim;

    // 스태이트 패턴 == 상태패턴
    public enum PlayerState
    {
        Die,
        Moving,
        Idle,
    }

    public PlayerState _state = PlayerState.Idle;

    void Start()
    {
        mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall"); // (1 << 8) + (1 << 9)  110rp000000

        Managers.Input.MouseAction += OnMouseClicked;
        _anim = GetComponent<Animator>();
    }

    float wait_run_ratio = 0f;

    private void Update()
    {
        switch (_state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
        }
    }

    void UpdateDie()
    {
        // 일단은 아무것도 못함
    }

    void UpdateMoving()
    {
        _anim.SetFloat("wait_run_ratio", 1f);

        Vector3 dir = _destPos - transform.position; // 목적지로 가는 방향구하기
        if (dir.magnitude < 0.0001f) // 목적지에 거의 근접했는지 확인
        {
            _state = PlayerState.Idle; // 목적지에 거의 근접했다면 정지
        }
        else
        {
            float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude); // 거리가 가까워 질수록 이동거리가 짧아지게
            transform.position += dir.normalized * moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
        }
    }

    void UpdateIdle()
    {
        _anim.SetFloat("wait_run_ratio", 0f);
    }

    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (_state == PlayerState.Die)
            return;

        if (evt == Define.MouseEvent.Click)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100f, Color.red, 1);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, mask))
        {
            _destPos = hit.point;
            _state = PlayerState.Moving;
        }
    }
}