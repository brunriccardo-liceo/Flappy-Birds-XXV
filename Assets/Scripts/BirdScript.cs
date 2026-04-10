using System.Numerics;
using UnityEngine;


public class BirdScript : MonoBehaviour
{

    public Rigidbody2D myRigidBody;
    public float flapStrenght = 10;
    public logicScript logic;
    public bool birdIsAlive = true;
    public Animator animator;
    public GameObject smokeOnJump;



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
            myRigidBody.linearVelocity = new UnityEngine.Vector2(0, 1) * flapStrenght;
            AudioManager.instance.PlaySFX("flap");
            animator.SetTrigger("BirdAnimation");
            UnityEngine.Vector3 smokePosition = new UnityEngine.Vector3(gameObject.transform.position.x - 3, gameObject.transform.position.y, 2);
            Instantiate(smokeOnJump, smokePosition, gameObject.transform.rotation);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.instance.PlaySFX("impact");
        logic.GameOver();
    }
}
