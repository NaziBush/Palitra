using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationComponent : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sprite_rend;
    public Sprite[] sprites;
    public Sprite example;
    float speed = 0.01f;
    int current_sprite = 0;
    // bool play = false;
    int end_sprite = 5;
    int start_sprite = 2;

    void Awake()
    {
        print(sprites[0].border);
        //sprites[0].border.w
        //BeginAnimation();
    }
	public void BeginAnimation(float height,float ball_start, float line_position)
    {
        StopAllCoroutines();
        StartCoroutine(AnimationCoroutine(height,ball_start,line_position));
    }

    IEnumerator AnimationCoroutine(float new_height, float ball_start, float line_position)
    {

        float height = example.bounds.extents.y/2.0f * transform.localScale.y; 
        current_sprite = start_sprite;
        print(sprites[0].border);
        float sprite_dist = (float)(end_sprite - start_sprite);
        print("sprite dist " + sprite_dist);
        float dist = height*2.0f;
        print("dist " + dist);
        float cell = (float)dist / sprite_dist;
        //float k = dist / sprite_dist;
        print("cell " + cell);
        Debug.DrawLine(new Vector3(0.0f, ball_start, 0.0f), 
            new Vector3(0.0f, ball_start + dist, 0.0f),Color.red,10.0f);
        sprite_rend.sprite = sprites[current_sprite];

        //во время прохождения линии
        //while (current_sprite <= end_sprite)
        while (current_sprite < sprites.Length - 1)
        {
            float position = Ball.ball.collision_point.position.y - ball_start;
            //float position = Ball.ball.collision_point.position.y;
            current_sprite = (int) (position / cell);
            print("position " + position+" currentsprite "+current_sprite);
            sprite_rend.sprite = sprites[current_sprite+start_sprite];
            yield return new WaitForEndOfFrame();
        }

        //после того как прошли линию
        //while ((current_sprite<sprites.Length-1)&& (current_sprite > end_sprite))
        //{
        //    sprite_rend.sprite = sprites[current_sprite+start_sprite];
        //    current_sprite++;
        //    yield return new WaitForSeconds(speed);
        //}
    }

    public void ResetAnimation()
    {
        current_sprite = 0;
        sprite_rend.sprite = sprites[current_sprite];
    }
}
