using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;

    public int maxHealth;
    public int curHealth;
    public int score;
    public bool isDead;

    public Text scoreText;
    public Text gameOver;
    public Image[] hearts;
    public Image skillBtn;
    public bool isSkillReady;
    public bool isShieldActive;


    Animator animator;
    SpriteRenderer sprite;

    public float skillMaintainTime = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        curHealth = maxHealth;
        isSkillReady = false;
        skillBtn.GetComponent<Image>().fillAmount = 0;
    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }

        if (skillBtn.GetComponent<Image>().fillAmount < 1)
        {
            skillBtn.GetComponent<Image>().fillAmount += Time.deltaTime / skillMaintainTime;
        }
        else
        {
            isSkillReady = true;
        }

        float moveDistance = speed * Time.fixedDeltaTime;
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.Space) && isSkillReady)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            isShieldActive = true;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 2.5f;
        }
        else
        {
            speed = 5;
        }

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            moveDirection += Vector3.left;
            sprite.flipX = true;
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            moveDirection += Vector3.right;
            sprite.flipX = false;
        }

        if (moveDirection.normalized * moveDistance != Vector3.zero)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
        transform.position += moveDirection.normalized * moveDistance;

        if (curHealth <= 0)
        {
            isDead = true;
            animator.SetTrigger("Dead");
            gameOver.gameObject.SetActive(true);
        }
    }

    public void OnClickSkillBtn()
    {
        skillBtn.GetComponent<Image>().fillAmount = 0f;
        isSkillReady = false;
    }
}
