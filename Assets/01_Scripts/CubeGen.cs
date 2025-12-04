using UnityEngine;

public class CubeGen : MonoBehaviour
{
    Color[] colors = {Color.red, Color.yellow, Color.yellowGreen, Color.blue, Color.plum, Color.purple, Color.powderBlue};
    
    public Sprite CubeImage;
    public int initPosX = -3;

    void Start()
    {
        for(int i = 0; i < 7; i++) {
            GameObject go = new GameObject($"Square {i+1}");
            go.AddComponent<SpriteRenderer>().sprite = CubeImage;
            go.GetComponent<SpriteRenderer>().color = colors[i];
            go.transform.position = new Vector3(initPosX + i, 0, 0);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
