using UnityEngine;

public class Wisp_Orbit : MonoBehaviour
{
    SpriteRenderer sprite;
    GameObject orbit;
    
    [Header("Orbit Settings")]
    public float orbitRadius = 1.5f;
    public float orbitSpeed = 180f;

    public 

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        orbit = transform.GetChild(0).gameObject;   
        orbit.SetActive(false);
    }


    float timer = 0f;
    private void Awake() {
        timer = 0;
    }

    void Update()
    {

        if (transform.parent == null) return;

        int childCount = transform.parent.childCount;
        int siblingIndex = transform.GetSiblingIndex();
        float angleOffset = 360f / childCount * siblingIndex;
        float currentAngle = (Time.time * orbitSpeed) + angleOffset;

        float rad = currentAngle * Mathf.Deg2Rad;
        float x = Mathf.Cos(rad) * orbitRadius;

        transform.localPosition = new Vector3(x, 0, 0);

        float normalizedAngle = Mathf.Repeat(currentAngle, 360f);

        if (normalizedAngle < 180f)
        {
            sprite.sortingOrder = -3;
        }
        else
        {
            sprite.sortingOrder = 3;
        }
    }
}
