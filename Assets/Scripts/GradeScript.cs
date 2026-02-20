using UnityEngine;

public class GradeScript : MonoBehaviour
{
    public Sprite[] voti;
    public SpriteRenderer spriteRenderer;
    public int gradeNumber;
    public logicScript logicScript;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int randomIndex = Random.Range(0, 8); //l'8 è escluso
        gradeNumber = randomIndex + 3;
        spriteRenderer.sprite = voti[randomIndex];
        logicScript = GameObject.FindGameObjectWithTag("logic").GetComponent<logicScript>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logicScript.AddGradeToMean(gradeNumber);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame.
    void Update()
    {

    }
}
