using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    public Sprite[] heartSprites;
    private float animTimer;
    public float animationSpeed = 10f;

    Player player;

    Image img;
    bool isFull = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindAnyObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < player.maxHealth - player.curHealth; i++) {
            if (i >= transform.childCount)
                break;
            Transform heart = transform.GetChild(i);
            heart.GetComponent<Image>().color = Color.black;

            
        }
    }
}
