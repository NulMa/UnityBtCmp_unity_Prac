using UnityEngine;
using UnityEngine.Pool;

public class MonsterSpawn : MonoBehaviour
{
    public GameObject monsterPrefab;
    Player player;
    public float spawnInterval = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindAnyObjectByType<Player>();
    }


    float timer = 0f;
    // Update is called once per frame
    void Update()
    {   
        if(player.isDead)
            return;

        timer -= Time.deltaTime;
        if (timer <= 0f) {
            SpawnMonster();
            timer = spawnInterval;
        }
    }
    void SpawnMonster() {
        float xPosition = Random.Range(-9.1f, 9.1f);
        Vector3 spawnPosition = new Vector3(xPosition, this.transform.position.y, 0f);
        Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
    }
}
