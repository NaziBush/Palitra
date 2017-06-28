using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class MeshConverter:MonoBehaviour
{
    public SpriteData sprite_data;
    public void CreateMeshFromSprites(Sprite[] sprites)
    {
        for (int i=0;i<sprites.Length;i++)
        {
            Mesh mesh = SpriteToMesh(sprites[i]);
            AssetDatabase.CreateAsset(mesh, "Assets/Meshes/new/mesh_"+i+".asset");
        }
    }
    void Start()
    {
        CreateMeshFromSprites(sprite_data.sprites);
    }
    Mesh SpriteToMesh(Sprite sprite)
    {
        Mesh mesh = new Mesh();
        mesh.vertices = Array.ConvertAll(sprite.vertices, i => (Vector3)i);
        mesh.uv = sprite.uv;
        mesh.triangles = Array.ConvertAll(sprite.triangles, i => (int)i);
        Vector3[] vertices = mesh.vertices;
        //for (int i = 0; i < vertices.Length; i++)
        //{
        //    vertices[i] *= 0.1f;
        //    vertices[i].x *= 0.1f;
        //}
       

        mesh.vertices = vertices;
        return mesh;
    }
}
