using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Mole : MonoBehaviour
{
    public enum MoleType {
        Normal, Bomb, Bonus
    }
    public MoleType moleType;

    [Header("Animation Sprites")]
    public Sprite[] moleSprites;
    public float animationSpeed = 10f; // Frames per second

    private float animTimer;

    Button btn;
    SpriteRenderer sprite;
    Image img;
    Animator animator;

    void Start() {
        btn = GetComponent<Button>();
        img = GetComponent<Image>();
        btn.onClick.AddListener(OnClickMole);
        animator = GetComponent<Animator>();

        // Randomly assign type for testing
        moleType = (MoleType)Random.Range(0, 3);

        if (animator != null)
        {
            animator.SetInteger("MoleType", (int)moleType);
        }
    }

    float timer = 0f;
    float rainbow;
    // Update is called once per frame
    void Update()
    {
        // Sprite Animation Logic
        if (moleSprites != null && moleSprites.Length > 0)
        {
            animTimer += Time.deltaTime;
            int frameIndex = (int)(animTimer * animationSpeed) % moleSprites.Length;
            if (img != null)
            {
                img.sprite = moleSprites[frameIndex];
            }
        }

        if(rainbow > 1)
            rainbow = 0;


        timer += Time.deltaTime;
        if (timer > 3.0f) {
            SpawnMole();
        }
        switch (moleType) {
            case MoleType.Normal:
                if (img != null) img.color = Color.white;
                break;
            case MoleType.Bomb:
                if (img != null) img.color = Color.black;
                break;
            case MoleType.Bonus:
                rainbow += Time.deltaTime * 0.5f;
                if (img != null) img.color = Color.HSVToRGB(rainbow, 1, 1);
                break;
        }

    }

    public void OnClickMole() {
        btn.interactable = false;

        if (transform.childCount > 0) {
            transform.GetChild(0).gameObject.SetActive(true);
        }

        switch (moleType) {
            case MoleType.Normal:
                Main.Instance.score += 1;
                break;
            case MoleType.Bomb:
                Main.Instance.score -= 3;
                break;
            case MoleType.Bonus:
                Main.Instance.score += 10;
                break;
        }

        if (Main.Instance.scoreText != null)
        {
            Main.Instance.scoreText.text = "Score: " + Main.Instance.score;
        }
        
        Destroy(gameObject, 0.25f);
    }

    public void SpawnMole() {
        btn.interactable = false;
        Main.Instance.SpawnMole();  
        Destroy(gameObject);
    }
}
