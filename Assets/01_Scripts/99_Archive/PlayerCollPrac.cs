using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCollPrac : MonoBehaviour
{

    Animator anim;
    SpriteRenderer sprite;

    public float speed = 3;
    public float maxHp;
    public float curHp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        curHp = maxHp;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //PlayerMove();
        MouseClick();

    }

    void PlayerMove() {
        float moveDistance = speed * Time.fixedDeltaTime;
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow) == true) {
            moveDirection += Vector3.left;
            sprite.flipX = true;
        }

        if (Input.GetKey(KeyCode.RightArrow) == true) {
            moveDirection += Vector3.right;
            sprite.flipX = false;
        }

        if (Input.GetKey(KeyCode.UpArrow) == true) {
            moveDirection += Vector3.up;
        }
        if (Input.GetKey(KeyCode.DownArrow) == true) {
            moveDirection += Vector3.down;
        }

        if (moveDirection != Vector3.zero) {
            anim.SetBool("isRun", true);
        }
        else {
            anim.SetBool("isRun", false);
        }

        transform.position += moveDirection.normalized * moveDistance;
    }

    public void MouseClick() {
        if (Input.GetMouseButton(0)) {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.DrawRay(worldPos, Vector3.forward * 100, Color.red, 2f);
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
            if(hit.collider != null) {
                Debug.Log("Clicked on: " + hit.collider.name);
            }
        }
    }


    //private void OnCollisionEnter2D(Collision2D collision) {
    //    if (collision.gameObject.tag == "Enemy") {
    //        curHp -= 1;
    //        Debug.Log("Player HP: " + curHp);
    //    }
    //}
}
