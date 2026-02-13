using UnityEngine;

public class GradeScript : MonoBehaviour
{
    public Sprite[] voti;
    public SpriteRenderer spriteRenderer;
    public int gradeNumber;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int randomIndex = Random.Range(0, 8); //l'8 è escluso
        gradeNumber = randomIndex + 3;
        spriteRenderer.sprite = voti[randomIndex];

    }

    // Update is called once per frame.
    void Update()
    {

    }
}
