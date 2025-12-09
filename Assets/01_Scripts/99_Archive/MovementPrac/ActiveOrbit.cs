using Unity.VisualScripting;
using UnityEngine;

public class ActiveOrbit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float orbitCooldown = 10f;
    public float orbitMaintainTime = 2f;
    Player player;


    void Start()
    {
        player = GameObject.FindAnyObjectByType<Player>();
    }


    float timer = 0f;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= orbitMaintainTime) {
            player.isShieldActive = false;
            gameObject.SetActive(false);
        }
    }
}
