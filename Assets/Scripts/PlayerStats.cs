using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public List<float> means = new List<float>();
    public float finalGrade;
    public int currentLevel = 1;

    public static PlayerStats instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddToMean(float mean)
    {
        currentLevel += 1;
        means.Add(mean);
        if (means.Count == 5)
        {
            float sumOfMeans = 0;
            foreach (var m in means)
            {
                sumOfMeans += m;
            }
            finalGrade = sumOfMeans / 5 * 10;
        }
    }





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
