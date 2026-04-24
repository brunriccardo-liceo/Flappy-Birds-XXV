using UnityEngine;

public class NotaScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] matite;
    public logicScript logicScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int randomIndex = Random.Range(0, 7);
        spriteRenderer.sprite = matite[randomIndex];
        gameObject.transform.Rotate(0, 0, 90);
        logicScript = GameObject.FindGameObjectWithTag("logic").GetComponent<logicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logicScript.AbbassaCondotta();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
