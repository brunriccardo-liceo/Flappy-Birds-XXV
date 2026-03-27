using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class GradeScript : MonoBehaviour
{
    public Sprite[] voti;
    public SpriteRenderer spriteRenderer;
    public int gradeNumber;
    public logicScript logicScript;
    public GameObject sparkles;
    public ParticleSystem circle;

    public GameObject effectOnDestroy;

    private void SetEffects()
    {
        if (gradeNumber >= 8)
        {
            sparkles.SetActive(true);
            var main = circle.main;
            main.startColor = Color.green;
        }
        else if (gradeNumber >= 6 && gradeNumber < 8)
        {
            var main = circle.main;
            main.startColor = Color.yellow;
        }
        else
        {
            var main = circle.main;
            main.startColor = Color.red;
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int randomIndex = Random.Range(0, 8); //l'8 è escluso
        gradeNumber = randomIndex + 3;
        spriteRenderer.sprite = voti[randomIndex];
        logicScript = GameObject.FindGameObjectWithTag("logic").GetComponent<logicScript>();
        SetEffects();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logicScript.AddGradeToMean(gradeNumber);
            PlayGradeSound(gradeNumber);
            Instantiate(effectOnDestroy, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }

    private void PlayGradeSound(int gradeNumber)
    {
        if (gradeNumber < 6)
        {
            AudioManager.instance.PlaySFX("pop");
            AudioManager.instance.PlaySFX("gradeNo");
        }
        else if (gradeNumber >= 6 && gradeNumber < 8)
        {
            AudioManager.instance.PlaySFX("pop");
            AudioManager.instance.PlaySFX("gradeGood");
        }
        else if (gradeNumber >= 8 && gradeNumber < 10)
        {
            AudioManager.instance.PlaySFX("pop");
            AudioManager.instance.PlaySFX("gradeYeah");
        }
        else //è 10
        {
            AudioManager.instance.PlaySFX("pop");
            AudioManager.instance.PlaySFX("gradeNice");
        }
    }

    // Update is called once per frame.
    void Update()
    {

    }
}
