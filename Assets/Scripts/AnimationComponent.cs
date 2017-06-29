using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationComponent : MonoBehaviour
{
    [SerializeField]
    MeshFilter mesh_filter_right;
    [SerializeField]
    MeshFilter mesh_filter_left;
    Line line;
    //public Sprite[] sprites;
    //public Sprite example;
    public MeshData mesh_data;
    float speed = 0.1f;
    int current_mesh = 0;
    // bool play = false;
    
    int start_mesh = 2;
    int end_mesh = 11;

    void Awake()
    {
        line = GetComponent<Line>();
        //print(sprites[0].border);
        //sprites[0].border.w
        //BeginAnimation();
    }
    //public void BeginAnimation(float height,float ball_start, float line_position)
    public void BeginAnimation()
    {
        //print("begin animation");
        StartCoroutine(AnimationCoroutine());
    }

    void OnEnable()
    {
        StopAllCoroutines();
        ResetAnimation();
    }
    // IEnumerator AnimationCoroutine(float new_height, float ball_start, float line_position)
    IEnumerator AnimationCoroutine()
    {
        //print("animation coroutine");
        float ball_start = Ball.ball.collision_point.position.y;
        float height = line.GetHeight();
        current_mesh = start_mesh;
        //print(sprites[0].border);
        float mesh_dist = (float)(end_mesh - start_mesh);
        //print("mesh dist " + mesh_dist);
        float dist = height * 2.0f;
        //print("dist " + dist);
        float cell = (float)dist / mesh_dist;
        //print("cell " + cell);
        //Debug.DrawLine(new Vector3(0.0f, ball_start, 0.0f),
        //    new Vector3(0.0f, ball_start + dist, 0.0f), Color.red, 10.0f);

        // sprite_rend.sprite = sprite_data.sprites[current_sprite];
        SetMesh(mesh_data.meshes[current_mesh]);

        //во время прохождения линии
        //while (current_sprite <= end_sprite)
        while (current_mesh < mesh_data.meshes.Length - start_mesh - 1)
        {
            float position = Ball.ball.collision_point.position.y - ball_start;
            current_mesh = (int)(position / cell);
            //print("position " + position + " currentsprite " + current_mesh);
            //sprite_rend.sprite = sprite_data.sprites[current_sprite+start_sprite];
            SetMesh(mesh_data.meshes[current_mesh + start_mesh]);
            yield return new WaitForEndOfFrame();
        }

        //после того как прошли линию
        while ((current_mesh < mesh_data.meshes.Length - start_mesh) && (current_mesh > end_mesh))
        //while ((current_mesh < mesh_data.meshes.Length - start_mesh))
        {
            SetMesh(mesh_data.meshes[current_mesh + start_mesh]);
            current_mesh++;
            //yield return new WaitForSeconds(speed);
            yield return new WaitForEndOfFrame();
        }
    }

    void SetMesh(Mesh mesh)
    {
        mesh_filter_right.mesh = mesh;
        mesh_filter_left.mesh = mesh;
    }

    public void ResetAnimation()
    {
        current_mesh = start_mesh;

        //SetPicture(mesh_data.meshes[current_mesh]);
    }
}
