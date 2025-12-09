using UnityEngine;
enum PlayerDir {
    Up,
    Down,
    Side
}
enum PlayerState {
    Idle,
    Walk,
    Attack
}
public class PlayerAnimationPrac : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sprite;

    public float speed = 3;

    PlayerDir _currentDir;
    PlayerState _currentState;
    public string Dir;
    public string State;

    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Dir = _currentDir.ToString();
        State = _currentState.ToString();

        if (_currentState == PlayerState.Attack) {
            return;
        }

        PlayerMove();
        PlayerAttack();

        UpdateAnimation();
    }

    public void UpdateAnimation() {
        anim.Play("Player" + _currentDir + _currentState);
    }

    public void PlayerAttack() {
        if (Input.GetKey(KeyCode.Q)) {
            Debug.Log("Attack");
            _currentState = PlayerState.Attack;
            Debug.Log("Attack22222222222222222");
        }
    }

    public void PlayerMove() {
        //2dplayer move
        if (Input.GetAxis("Horizontal") != 0) {
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * 0.1f);
            _currentState = PlayerState.Walk;
            _currentDir = PlayerDir.Side;
        }
        if (Input.GetAxis("Vertical") != 0) {
            transform.Translate(Vector3.up * Input.GetAxis("Vertical") * speed * 0.1f);
            _currentState = PlayerState.Walk;

            if (Input.GetAxis("Vertical") > 0) {
                _currentDir = PlayerDir.Up;
            }
            else if (Input.GetAxis("Vertical") < 0) {
                _currentDir = PlayerDir.Down;
            }
        }

        //flip
        if (Input.GetAxis("Horizontal") < 0) {
            sprite.flipX = true;
        }
        if (Input.GetAxis("Horizontal") > 0) {
            sprite.flipX = false;
        }

        //player idle
        if (Input.GetAxis("Vertical") == 0) {
            if (Input.GetAxis("Horizontal") == 0) {
                _currentState = PlayerState.Idle;
            }
        }
    }
    public void AttackOff()
    {
        _currentState = PlayerState.Idle;
    }
}
