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
    public bool isAttack = false;

    PlayerDir currentDir;
    PlayerState currentState;

    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (currentState == PlayerState.Attack) {
            return;
        }

        PlayerMove();

        //player attack
        if (Input.GetKey(KeyCode.Q) && !isAttack)
        {
            anim.Play("Player" + currentState + "Attack");
            currentState = PlayerState.Attack;

            Invoke("AttackOff", 0.5f);
        }

        UpdateAnimation();
    }

    public void UpdateAnimation() {
        anim.Play("Player" + currentDir + currentState);
    }

    public void PlayerMove() {
        //2dplayer move
        if (Input.GetAxis("Horizontal") != 0) {
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * 0.1f);
            currentDir = PlayerDir.Side;
        }
        if (Input.GetAxis("Vertical") != 0) {
            transform.Translate(Vector3.up * Input.GetAxis("Vertical") * speed * 0.1f);

            if (Input.GetAxis("Vertical") > 0) {
                currentDir = PlayerDir.Up;
            }
            else if (Input.GetAxis("Vertical") < 0) {
                currentDir = PlayerDir.Down;
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
            //currentState = PlayerState.Side.ToString();
            if (Input.GetAxis("Horizontal") == 0) {
                currentState = PlayerState.Idle;
            }
        }
        else {
            currentState = PlayerState.Walk;
        }
    }
    public void AttackOff()
    {
        currentState = PlayerState.Idle;
    }


}
