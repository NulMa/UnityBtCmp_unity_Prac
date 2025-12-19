using UnityEngine;

public class PlayerWithManagers : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Managers mg = Managers.Instance;
        Logger.Log("PlayerWithManagers Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
