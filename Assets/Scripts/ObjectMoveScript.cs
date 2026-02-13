using UnityEngine;

public class OjectMoveScript : MonoBehaviour
{
    public float moveSpeed = 10;
    public float deadZone = -45;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime);
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
