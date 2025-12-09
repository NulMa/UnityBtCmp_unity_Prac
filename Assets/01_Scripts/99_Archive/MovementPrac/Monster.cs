using UnityEngine;

public class Monster : MonoBehaviour
{
    private Player player;
    public float speed;
    public float distance;

    public bool isDead;

    GameObject child;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindAnyObjectByType<Player>();
        child = transform.GetChild(0).gameObject;
        speed = Random.Range(speed, speed+2);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;
        float moveDistance = speed * Time.deltaTime;
        Vector3 direction = player.transform.position - transform.position;

        transform.position += Vector3.down * moveDistance;

        if (direction.magnitude < 0.3f) {
            if (player.isShieldActive) {
                Destroy(gameObject);
                return;
            }

            isDead = true;
            player.curHealth -= 1;
            Destroy(gameObject, 0.5f);
            child.SetActive(true);
        }
        if (transform.position.y < -5) {
            Destroy(gameObject);
            isDead = true;
            player.score += 1;
            player.scoreText.text = "Score: " + player.score;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            if (player.isShieldActive) {
                Destroy(gameObject);
                return;
            }
            isDead = true;
            player.curHealth -= 1;
            Destroy(gameObject, 0.5f);
            child.SetActive(true);
        }

        if(collision.gameObject.tag == "Ground") {
            Destroy(gameObject);
        }
    }
}
