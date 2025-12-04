using UnityEngine;

public class Player : MonoBehaviour
{
    public int level = 1;
    public int hp = 10;
    public int damage = 10;

    //public Sprite playerSprite;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject go = gameObject;
        SpriteRenderer sprite = go.AddComponent<SpriteRenderer>();
        transform.tag = "Player";
        //sprite.sprite = playerSprite;
        //sprite.color = new Color(1, 1, 1, 0.25f);

        //Transform transform = GetComponent<Transform>();
        //transform.position = Vector3.zero;
        transform.position = new Vector3(5, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
