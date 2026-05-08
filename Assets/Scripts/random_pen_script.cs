using UnityEngine;
using System.Collections.Generic;

public class random_pen_script : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[7];
    public GameObject top, low;
    public Vector3 target_size = new Vector3(0.6f, 6.6f, 0);

    void Start()
    {
        SpriteRenderer top_sprite = top.GetComponent<SpriteRenderer>();
        SpriteRenderer low_sprite = low.GetComponent<SpriteRenderer>();
        Vector3 scale = top.transform.localScale;
        PolygonCollider2D top_collider = top.GetComponent<PolygonCollider2D>();
        PolygonCollider2D low_collider = low.GetComponent<PolygonCollider2D>();

        int idx = Random.Range(0, 7);

        top_sprite.sprite = sprites[idx];

        Vector3 top_sprite_size = top_sprite.bounds.size;

        scale.x = target_size.x / top_sprite_size.x;
        scale.y = target_size.y / top_sprite_size.y;

        if (idx == 2 || idx == 4 || idx == 6)
        {
            scale.y *= -1;
        }

        top.transform.localScale = scale;

        idx = Random.Range(0, 7);

        low_sprite.sprite = sprites[idx];

        Vector3 low_sprite_size = low_sprite.bounds.size;

        scale = low.transform.localScale;
        scale.x = target_size.x / low_sprite_size.x;
        scale.y = target_size.y / low_sprite_size.y;

        if (idx == 0 || idx == 1 || idx == 5)
        {
            scale.y *= -1;
        }

        low.transform.localScale = scale;

        Sprite sprite_t = top_sprite.sprite;
        Sprite sprite_b = low_sprite.sprite;
        List<Vector2> points_t = new List<Vector2>();
        List<Vector2> points_b = new List<Vector2>();

        sprite_t.GetPhysicsShape(0, points_t);
        sprite_b.GetPhysicsShape(0, points_b);

        top_collider.SetPath(0, points_t.ToArray());
        low_collider.SetPath(0, points_b.ToArray());
    }
}