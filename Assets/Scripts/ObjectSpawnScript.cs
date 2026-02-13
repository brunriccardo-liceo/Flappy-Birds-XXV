using UnityEngine;

public class ObjectSpawnScript : MonoBehaviour
{
    public GameObject obj;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnObj();
    }

    // Update is called once per frame
    void Update()
    {

        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            timer = 0;
            SpawnObj();
        }
    }

    void SpawnObj()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Vector3 objectPosition = new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), transform.position.z);

        Instantiate(obj, objectPosition, transform.rotation);
    }




}
