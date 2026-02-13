using UnityEngine;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D myRigidBody; 
    public float flapStrenght = 10;
    public logicScript logic;
    public bool birdIsAlive = true;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.name = "Calogero";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidBody.linearVelocity = new Vector2(0, 1)*flapStrenght;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        logic.GameOver();
    }
}
