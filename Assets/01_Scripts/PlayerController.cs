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
    public float _rayLength;

    public GameObject markerPrefab;

    Vector2 inputVec2;
    Vector3 moveDirection;


    int layerMask = (1 << 6) + (1 << 8); // Layer 6: Ground, Layer 8: Obstacle
    void Start()
    {
        _mainCam = FindObjectOfType<MainCam>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }


    Vector3 destination;
    private void FixedUpdate()
    {

        transform.position += moveDirection * _speed * Time.deltaTime;
        if (moveDirection != Vector3.zero && !isJumping)
        {
            currentState = state.Run.ToString();
        }

        if(destination != transform.position)
        {
            GameObject removeMarker = GameObject.Find("@Marker");
            if (Vector3.Distance(transform.position, destination) < 0.1f)
            {
                destination = transform.position;

                if (removeMarker != null)
                {
                    Destroy(removeMarker);
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, destination, _speed * Time.deltaTime);
        }

        if (Input.GetMouseButton(0))
        {
            RaycastHit hitInfo;
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(r, out hitInfo, _rayLength, layerMask))
            {
                Logger.LogWarning($"Hit : {hitInfo.point}");


                GameObject marker;
                marker = GameObject.Find("@Marker");
                if ((marker == null))
                {
                    marker = Instantiate(markerPrefab);
                    marker.name = "@Marker";
                }
                marker.transform.position = hitInfo.point + Vector3.up*2;

                destination = hitInfo.point;

            }
            else
            {
                Logger.LogWarning($"No Hit");
            }
        }
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
        //player look at mouse position
        Vector3 mousePos = new Vector3(value.Get<Vector2>().x, value.Get<Vector2>().y, 0);
        mousePos.z = Vector3.Distance(_mainCam.transform.position, transform.position);
        Vector3 worldMousePos = _mainCam.GetComponent<Camera>().ScreenToWorldPoint(mousePos);
        Vector3 lookDir = worldMousePos - transform.position;
        lookDir.y = 0;
        Quaternion toRotation = Quaternion.LookRotation(lookDir, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 0.5f);
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
        //bool isFiring = value.isPressed;
        //if (isFiring)
        //{
        //    isJumping = true;
        //    currentState = state.Jump.ToString();
        //    rigid.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }

}
