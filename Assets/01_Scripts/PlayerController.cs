using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    enum state
    {
        Idle,
        Run,
        Jump
    }

    Animator anim;
    Rigidbody rigid;

    MainCam _mainCam;

    public float _speed = 5f;
    public float _jumpForce = 5f;
    public bool isJumping = false;
    public string currentState;

    Vector2 inputVec2;
    Vector3 moveDirection;

    void Start()
    {
        _mainCam = FindObjectOfType<MainCam>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        Managers.Input.KeyAction += OnKeyboard;
    }

    void Update()
    {
        anim.Play("Player_" + currentState);
    }

    private void FixedUpdate()
    {
        //if(Input.anyKey == false && !isJumping)
        //{
        //    //currentState = state.Idle.ToString();
        //}

        transform.position += moveDirection * _speed * Time.deltaTime;
        if (moveDirection != Vector3.zero && !isJumping)
        {
            currentState = state.Run.ToString();
        }

        playerRotation();

    }

    public void playerRotation()
    {
        //player look at mouse position
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Vector3.Distance(_mainCam.transform.position, transform.position);
        Vector3 worldMousePos = _mainCam.GetComponent<Camera>().ScreenToWorldPoint(mousePos);
        Vector3 lookDir = worldMousePos - transform.position;
        lookDir.y = 0;
        Quaternion toRotation = Quaternion.LookRotation(lookDir, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 0.5f);
    }

    public void OnLook(InputValue value)
    {
        Vector2 lookVec2 = value.Get<Vector2>();
        //Debug.Log("Look: " + lookVec2);
    }

    public void OnMove(InputValue value)
    {
        inputVec2 = value.Get<Vector2>();
        if (inputVec2 != null)
        {
            moveDirection = new Vector3(inputVec2.x, 0, inputVec2.y).normalized;
        }
    }

    public void OnFire(InputValue value)
    {
        bool isFiring = value.isPressed;
        if (isFiring)
        {
            Debug.Log("Fire!");
        }
    }

    void OnKeyboard()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, 0, v).normalized;
        transform.position += dir * _speed * Time.deltaTime;


        //rotate with slerp
        if (dir != Vector3.zero)
        {
            //Quaternion toRotation = Quaternion.LookRotation(dir, Vector3.up);
            //transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 0.25f);


            if (!isJumping) currentState = state.Run.ToString();
        }

        //jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            currentState = state.Jump.ToString();
            rigid.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }

}
