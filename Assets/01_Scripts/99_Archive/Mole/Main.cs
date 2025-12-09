using NUnit.Framework;
using UnityEditor.Animations;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Main : MonoBehaviour {
    public static Main Instance;

    public GameObject molePrefab;
    public RectTransform canvasRect;
    public Text scoreText;

    public int score = 0;   

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start() {
        
        SpawnMole();
        
    }

    float spawnTimer = 0f;
    float spawnRate = 10.0f;
    private void Update() {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnRate) {
            SpawnMole();
            spawnTimer = 0f;
        }
    }

    public void SpawnMole() {
        GameObject moleGo = Instantiate(molePrefab, canvasRect);
        moleGo.GetComponent<Button>().onClick.AddListener(SpawnMole);
        RectTransform rect = moleGo.GetComponent<RectTransform>();

        float x = Random.Range(-canvasRect.rect.width / 2, canvasRect.rect.width / 2);
        float y = Random.Range(-canvasRect.rect.height / 2, canvasRect.rect.height / 2);
        rect.anchoredPosition = new Vector2(x, y);
    }
}





//    public GameObject playerPrefab;
//    public GameObject enemyPrefab;

//    private void Start() {
//    //CreatePlayer();
//    playerPrefab = Resources.Load<GameObject>("Prefabs/Player");
//    enemyPrefab = Resources.Load<GameObject>("Prefabs/Enemy");

//}

//void CreatePlayer() {
//    GameObject go = new GameObject();
//    go.name = "Player";

//    SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
//    //spriteRenderer sr = go.GetComponent<spriteRenderer>();
//    sr.sprite = Resources.Load<Sprite>("Enemy_04_Move-Sheet");

//    Player player = go.AddComponent<Player>();
//    player.level = 2;
//}

//void CreateEnemy(float time) {
//    float randTime = Random.Range(0.1f, 1.0f);
//    float randX = Random.Range(-8.0f, 8.0f);
//    float randY = Random.Range(-4.0f, 4.0f);

//    if (randTime > time)
//        return;

//    GameObject enemyGo = Instantiate(enemyPrefab);

//    Color randColor = Color.HSVToRGB(Random.value, Random.value, 1);
//    randColor.a = Random.Range(0.5f, 1.0f);
//    enemyGo.GetComponent<SpriteRenderer>().color = randColor;
//    enemyGo.transform.position = new Vector3(randX, randY, 0);
//    enemyGo.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
//    enemyGo.transform.localScale = Vector3.one * Random.Range(0.25f, 2f);
//    enemyGo.name = enemyPrefab.name;

//    time = 0f;
//}

//float time;
//private void Update() {
//    time += Time.deltaTime;
//    if (playerPrefab != null) {
//        CreateEnemy(time);
//    }
//}
//====================================================================================
//public Sprite playerSprite;
//public Player player;
//public AnimatorController playerAnimCtrl;

//public AnimatorController enemyAnimCtrl;
//public List<Enemy> enemy = new List<Enemy>();


//void Start()
//{
//    CreatePlayer();

//}

//public float timer = 0f;
//// Update is called once per frame
//void Update()
//{
//    timer += Time.deltaTime;

//    if (timer > 0.5) {
//        Debug.Log("Create Enemy");
//        CreateEnemy();
//        timer = 0f;
//    }

//}

//void CreatePlayer()
//{
//    GameObject newPlayer = new GameObject("Player");
//    newPlayer.tag = "Player";

//    SpriteRenderer sprite = newPlayer.AddComponent<SpriteRenderer>();
//    sprite.sprite = playerSprite;

//    Player player = newPlayer.AddComponent<Player>();
//    player.level = 2;
//    this.player = player;

//    Animator animator = newPlayer.AddComponent<Animator>();
//    AnimatorController animatorController = Instantiate(playerAnimCtrl);
//    animator.runtimeAnimatorController = animatorController;
//}

//void CreateEnemy()
//    {
//    float randX = Random.Range(-8.0f, 8.0f);
//    float randY = Random.Range(-4.0f, 4.0f);
//    GameObject newEnemy = new GameObject("Enemy");
//    newEnemy.transform.position = new Vector3(randX, randY, 0);

//    newEnemy.AddComponent<SpriteRenderer>();
//    Enemy enemy = newEnemy.AddComponent<Enemy>();
//    Animator animator = newEnemy.AddComponent<Animator>();
//    AnimatorController animatorController = Instantiate(enemyAnimCtrl);
//    animator.runtimeAnimatorController = animatorController;

//    newEnemy.tag = "Enemy";

//}   
