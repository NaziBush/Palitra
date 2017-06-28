using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class printuv : MonoBehaviour
{
    MeshFilter m;
    Mesh mesh;
    // Use this for initialization
    void Start ()
    {
        m = GetComponent<MeshFilter>();
        mesh = m.mesh;
        Vector2[] uv = m.mesh.uv;
        Vector2[] new_uv = new Vector2[uv.Length];
        Vector3[] vert = m.mesh.vertices;
        Vector2 bot_left=vert[0];
        Vector2 top_left = vert[0];
        Vector2 bot_right = vert[0];
        Vector2 top_right = vert[0];
        //new_uv[0] = new Vector2(0.0f, 0.0f);
        //new_uv[1] = new Vector2(0.0f, 0.3f);
        int bot_left_ind = 0;
        int bot_right_ind = 0;
        int top_left_ind = 0;

       // print(vert[271] + " " + vert[272] + " " + vert[273]);
        for (int i=0;i<vert.Length;i++)
        {
            if( (vert[i].x < bot_left.x)|| (vert[i].y < bot_left.y))
            {
                bot_left.x = vert[i].x;
                bot_left.y = vert[i].y;
                bot_left_ind = i;
            }
                
        }
        int[] triangle = FindTriangle(bot_left_ind);
        print(triangle[0]+" "+ triangle[1] + " " + triangle[2]);
        Vector3[] triang_points = new Vector3[3];
        for (int i = 0; i < 3; i++)
        {
            triang_points[i] = vert[triangle[i]];
        }
        for (int i=0;i<vert.Length;i++)
        {
            for (int j=0;j<3;j++)
            {
               // if (i==)
            }
        }
        //for (int i = 0; i < 3; i++)
        //{
        //    //print(triang_points[i] + " ");
        //    if (triang_points[i].x>bot_left.x)
        //    {
        //        bot_right = triang_points[i];
        //        bot_right_ind = triangle[i];
        //    }
        //    if (triang_points[i].y > vert[bot_left_ind].y)
        //    {
        //        top_left = triang_points[i];
        //        top_left_ind = triangle[i];
        //    }
        //}
        ////костыль
        //for (int i = 0; i < vert.Length; i++)
        //{
        //    if ((vert[i].x > bot_right.x) && (vert[i].y == bot_left.y))
        //    {
        //        bot_right.x = vert[i].x;
        //        bot_right.y = vert[i].y;
        //        bot_right_ind = i;
        //    }

        //}

        //int new_vert;
        //triangle = FindTriangle(top_left_ind, bot_right_ind,bot_left_ind ,out new_vert);
        //print(triangle[0] + " " + triangle[1] + " " + triangle[2]);
        //top_right = vert[new_vert];
        //for (int i = 0; i < new_uv.Length; i++)
        //{
        //   // if (vert[i].)
        //    new_uv[i] = new Vector2(0.0f, 0.0f);
        //}
        //print(bot_left + " " + top_left + " " + top_right + " " + bot_right);


        ////рассчитываем правую часть
        ////Vector2[] right_part = Calculate_right_part(top_left, bot_right, vert);

        ////print(right_part[0] + " " + right_part[1] + " " + right_part[2] + " " + right_part[3]);
        //for (int i = 0; i < new_uv.Length; i++)
        //{
        //    if ((vert[i].x == bot_left.x) && (vert[i].y == bot_left.y))
        //        new_uv[i] = new Vector2(0.0f, 0.0f);
        //    if ((vert[i].x == top_left.x) && (vert[i].y == top_left.y))
        //        new_uv[i] = new Vector2(0.0f, 1.0f);
        //    if ((vert[i].x == bot_right.x) && (vert[i].y == bot_right.y))
        //        new_uv[i] = new Vector2(1.0f, 0.0f);
        //    if ((vert[i].x == top_right.x) && (vert[i].y == top_right.y))
        //        new_uv[i] = new Vector2(1.0f, 1.0f);

        //    //if ((vert[i].x == right_part[0].x) && (vert[i].y == right_part[0].y))
        //    //    new_uv[i] = new Vector2(1.0f, 0.0f);
        //    //if ((vert[i].x == right_part[1].x) && (vert[i].y == right_part[1].y))
        //    //    new_uv[i] = new Vector2(1.0f, 1.0f);
        //    //if ((vert[i].x == right_part[2].x) && (vert[i].y == right_part[2].y))
        //    //    new_uv[i] = new Vector2(0.0f, 1.0f);
        //    //if ((vert[i].x == right_part[3].x) && (vert[i].y == right_part[3].y))
        //    //    new_uv[i] = new Vector2(0.0f, 0.0f);
        //}


        m.mesh.uv = new_uv;
        for (int i=0;i<uv.Length;i++)
        {
            //if (uv[i].x<0.5)

           // print(uv[i].x + " " + uv[i].y);
        }
        for (int i = 0; i < vert.Length; i++)
        {
           // print("i="+i+"::"+vert[i].x + " " + vert[i].y + " " + vert[i].z);
        }
        for (int i = 0; i < vert.Length; i+=3)
        {
            // print(mesh.triangles[i]+" "+ mesh.triangles[i+1] + " "+ mesh.triangles[i+2]);
        }
    }


    Vector2[] Calculate_right_part(Vector2 top_left, Vector2 bot_right,Vector3[] vert)
    {
        Vector2[] right_part = new Vector2[4];
        
        Vector2 new_right = vert[0];
        Vector2 new_bot = bot_right;
        Vector2 new_left = vert[0];
        Vector2 new_top = vert[0];

        for (int i = 0; i < vert.Length; i++)
        {
            if (vert[i].x>new_right.x)
            {
                new_right = vert[i];
            }
        }

        for (int i = 0; i < vert.Length; i++)
        {
            if (vert[i].y > new_top.y)
            {
                new_top = vert[i];
            }
        }

        for (int i = 0; i < vert.Length; i++)
        {
            if ((vert[i].x < new_left.x)&&(vert[i].y>top_left.y))
            {
                new_left = vert[i];
            }
        }

        right_part[0] = new_bot;
        right_part[1] = new_right;
        right_part[2] = new_top;
        right_part[3] = new_left;

        return right_part;
    }
    int[] FindTriangle(int ind1, int ind2,out int new_vert)
    {
        int[] triangle = new int[3];
        new_vert = 0;
        //print(mesh.triangles.Length);
        for (int i = 0; i < mesh.triangles.Length; i+=3)
        {
            int k = 0;
            triangle = new int[]{ mesh.triangles[i], mesh.triangles[i+1], mesh.triangles[i+2] };
            for (int j=0;j<3;j++)
            {
                if ((triangle[j]==ind1) || (triangle[j] == ind2))
                {
                    k++;
                }
                else
                {
                    new_vert = triangle[j];
                }
            }
            if (k==2)
            {
                return triangle;
            }
        }
        print("no triangles found");
        return triangle;
    }
    int[] FindTriangle(int ind1, int ind2, int ignore,out int new_vert)
    {
        int[] triangle = new int[3];
        new_vert = 0;
        //print(mesh.triangles.Length);
        for (int i = 0; i < mesh.triangles.Length; i += 3)
        {
            int k = 0;
            triangle = new int[] { mesh.triangles[i], mesh.triangles[i + 1], mesh.triangles[i + 2] };
            for (int j = 0; j < 3; j++)
            {
                if ((triangle[j] == ind1) || (triangle[j] == ind2))
                {
                    k++;
                }
                else
                {
                    new_vert = triangle[j];
                }
            }
            if( (k == 2)&&(new_vert!=ignore))
            {
                return triangle;
            }
        }
        print("no triangles found");
        return triangle;
    }

    int[] FindTriangle(int index)
    {
        int[] triangle = new int[3];
        //print(mesh.triangles.Length);
        for (int i = 0; i < mesh.triangles.Length; i+=3)
        {
            triangle = new int[] { mesh.triangles[i], mesh.triangles[i + 1], mesh.triangles[i + 2] };
            for (int j = 0; j < 3; j++)
            {
                if (triangle[j] == index) 
                {
                    //print(triangle[0] + " " + triangle[1] + " " + triangle[2]);
                    return triangle;
                }
            }
        }
        print("no triangles found");
        return triangle;
    }

}


