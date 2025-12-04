using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class GamaManager : MonoBehaviour
{
    public GameObject playerObject;

    void Start() {
        CreatePlayer();
        playerObject = GameObject.Find("Player");
    }
        
    void CreatePlayer() {
        GameObject go = new GameObject();
        go.name = "Player";
        Player player = go.AddComponent<Player>();
        player.level = 1;
    }


    public float sumTime = 0;
    void Update()
    {
        if (playerObject == null)
            return;

        sumTime += Time.deltaTime;

        if (sumTime > 3) {
            playerObject.gameObject.SetActive(false);
            Destroy(playerObject, 2);
        }
    }
}
