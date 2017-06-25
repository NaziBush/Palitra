using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CalcUV2 : MonoBehaviour {

    Mesh mesh_A;
    Mesh mesh_B;
    MeshFilter A;
    MeshFilter B;
    Vector2[] uv_A;
    Vector2[] uv_B;

    void Start()
    {
        A = transform.GetChild(1).GetComponent<MeshFilter>();
        B = transform.GetChild(0).GetComponent<MeshFilter>();
        mesh_A = A.mesh;
        uv_A = mesh_A.uv;

        Vector3[] vert_A = mesh_A.vertices;

        Point A_bot_left = new Point(vert_A[0], 0);
        Point A_top_left = new Point(vert_A[0], 0);
        Point A_bot_right = new Point(vert_A[0], 0);
        Point A_top_right = new Point(vert_A[0], 0);

        //A_bot_right
        for (int i = 0; i < vert_A.Length; i++)
        {
            if ((vert_A[i].x >= A_bot_right.coord.x) && (vert_A[i].y <= A_bot_right.coord.y))
            {
                A_bot_right.coord.x = vert_A[i].x;
                A_bot_right.coord.y = vert_A[i].y;
                A_bot_right.index = i;
            }
        }
       
        //A_top_right
        A_top_right = new Point(A_bot_right.coord, A_bot_right.index);
        for (int i = 0; i < vert_A.Length; i++)
        {
            // if ((vert_A[i].x >= A_top_right.coord.x) && (vert_A[i].y >= A_top_right.coord.y))
            if ((Mathf.Abs(vert_A[i].x - A_top_right.coord.x)<0.1f) && (vert_A[i].y > A_top_right.coord.y))
            {
                A_top_right.coord.x = vert_A[i].x;
                A_top_right.coord.y = vert_A[i].y;
                A_top_right.index = i;
            }
        }

        //A_top_left
        A_top_left = new Point(A_top_right.coord, A_top_right.index);
        for (int i = 0; i < vert_A.Length; i++)
        {
            if ((vert_A[i].x <= A_top_left.coord.x) && (vert_A[i].y >= A_top_left.coord.y))
            {
                A_top_left.coord.x = vert_A[i].x;
                A_top_left.coord.y = vert_A[i].y;
                A_top_left.index = i;
            }
        }

        //A_bot_left
        A_bot_left = new Point(A_top_right.coord, A_top_right.index);
        //for (int i = 0; i < vert_A.Length; i++)
        //{
        //    if ((vert_A[i].x <= A_bot_left.coord.x) && (vert_A[i].y <= A_bot_left.coord.y)&&(i!=A_bot_right.index))
        //    {
        //        A_bot_left.coord.x = vert_A[i].x;
        //        A_bot_left.coord.y = vert_A[i].y;
        //        A_bot_left.index = i;
        //    }
        //}
        for (int i = 0; i < vert_A.Length; i++)
        {
            if ((i!=A_bot_right.index) && (i != A_top_right.index)&& (i != A_top_left.index))
            {
                A_bot_left.coord.x = vert_A[i].x;
                A_bot_left.coord.y = vert_A[i].y;
                A_bot_left.index = i;
            }
        }

        //for (int i=0;i<vert_A.Length;i++)
        //{
        //    print(vert_A[i]);
        //}

        print(A_bot_right.coord.x + " " + A_bot_right.coord.y + " , "
            + A_top_right.coord.x + " " + A_top_right.coord.y + " , "
            + A_top_left.coord.x + " " + A_top_left.coord.y + " , "
             + A_bot_left.coord.x + " " + A_bot_left.coord.y);


        mesh_B = B.mesh;
        uv_B= mesh_B.uv;

        Vector3[] vert_B = mesh_B.vertices;
        Point B_bot_left = new Point(vert_B[0], 0);
        Point B_top_left = new Point(vert_B[0], 0);
        Point B_bot_right = new Point(vert_B[0], 0);
        Point B_top_right = new Point(vert_B[0], 0);
        Point B_mid = new Point(vert_B[0], 0);

        bool mid;
        if (vert_B.Length == 5)
            mid = true;
        else
            mid = false;
        for (int i = 0; i < vert_B.Length; i++)
        {
            print(vert_B[i]);
        }
        //B_bot_right
        for (int i = 0; i < vert_B.Length; i++)
        {
            if (vert_B[i].y < B_bot_right.coord.y)
            {
                B_bot_right.coord.x = vert_B[i].x;
                B_bot_right.coord.y = vert_B[i].y;
                B_bot_right.index = i;
            }
        }

        //B_bot_left
        for (int i = 0; i < vert_B.Length; i++)
        {
            if ((vert_B[i].x < B_bot_left.coord.x)&&(vert_B[i].y>A_bot_left.coord.y))
            {
                B_bot_left.coord.x = vert_B[i].x;
                B_bot_left.coord.y = vert_B[i].y;
                B_bot_left.index = i;
            }
        }

        //B_top_left
        for (int i = 0; i < vert_B.Length; i++)
        {
            if (vert_B[i].y > B_top_left.coord.y)
            {
                B_top_left.coord.x = vert_B[i].x;
                B_top_left.coord.y = vert_B[i].y;
                B_top_left.index = i;
            }
        }

        //B_top_right
        // int[] triangle = FindTriangle(B_top_left.index,mesh_B);
        //int[] triangle = FindTriangle(B_top_left.index, B_bot_left.index, mesh_B);
        //B_top_right.coord = vert_B[triangle[0]];
        //B_top_right.index = triangle[0];
        //for (int i = 0; i < triangle.Length; i++)
        //{
        //    if (vert_B[triangle[i]].x > B_top_right.coord.x)
        //    {
        //        B_top_right.coord.x = vert_B[triangle[i]].x;
        //        B_top_right.coord.y = vert_B[i].y;
        //        B_top_right.index = i;
        //    }
        //}

        for (int i = 0; i < vert_B.Length; i++)
        {
            if ((vert_B[i].x > B_top_right.coord.x) && (vert_B[i].y > A_bot_left.coord.y))
            {
                B_top_right.coord.x = vert_B[i].x;
                B_top_right.coord.y = vert_B[i].y;
                B_top_right.index = i;
            }
        }


        //B_mid
        for (int i = 0; i < vert_B.Length; i++)
        {
            if ((i!=B_bot_left.index) &&(i != B_bot_right.index)&&
                (i != B_top_left.index)&&(i != B_top_right.index))
            {
                B_mid.coord.x = vert_B[i].x;
                B_mid.coord.y = vert_B[i].y;
                B_mid.index = i;
            }
        }

        /////////////////
        B_top_right.index = 2;B_top_right.coord = vert_B[2];
        B_top_left.index = 1; B_top_left.coord = vert_B[1];
        B_bot_right.index = 3; B_bot_right.coord = vert_B[3];
        B_bot_left.index = 0; B_bot_left.coord = vert_B[0];
        B_mid.index = 4; B_mid.coord = vert_B[4];
        /////////////////


        //B_bot_right.coord.x + " " + B_bot_right.coord.y + " , "
        print(B_top_right.coord.x + " " + B_top_right.coord.y + " , "
            + B_top_left.coord.x + " " + B_top_left.coord.y + " , "
             + B_bot_left.coord.x + " " + B_bot_left.coord.y + " , "
             + B_bot_right.coord.x + " " + B_bot_right.coord.y + " , "
             + B_mid.coord.x + " " + B_mid.coord.y);

        print(uv_A[A_bot_left.index] + "," + uv_A[A_top_left.index]);

       // print(vert_A.Length);
        //задать uv-координаты
        float a1 = (B_top_right.coord - A_bot_left.coord).magnitude;
        float a2 = (A_bot_right.coord - A_bot_left.coord).magnitude;
        float a3 = (A_top_right.coord - A_top_left.coord).magnitude;
        float a = a1 + a2;
        float a_bot = a2 / a;
        float a_top = a3 / a;

        float b1 = (B_top_left.coord - B_bot_left.coord).magnitude;
        float b2 = (B_top_right.coord - B_bot_right.coord).magnitude;
        float b3= (B_mid.coord - B_bot_left.coord).magnitude;
        //float b = b1 + b2 + b3;
        float b_bot=a_bot;
        
        float b_left = (b3+a3)/a;

        float bb1= (B_mid.coord - B_bot_right.coord).magnitude;
        float b_mid= b_bot+ bb1/a;

        Vector2[] new_uv_A = new Vector2[vert_A.Length];
        Vector2[] new_uv_B = new Vector2[vert_B.Length];
        for (int i = 0; i < new_uv_A.Length; i++)
        {
            new_uv_A[i] = new Vector2(0.0f, 0.0f);
        }
        for (int i = 0; i < new_uv_B.Length; i++)
        {
            new_uv_B[i] = new Vector2(0.0f, 0.0f);
        }

        new_uv_A[A_bot_right.index] = new Vector2(0.0f,0.0f);
        new_uv_A[A_top_right.index] = new Vector2(0.0f,1.0f);
        new_uv_A[A_bot_left.index] = new Vector2(a_bot,0.0f);
        new_uv_A[A_top_left.index] = new Vector2(a_top,1.0f);

        new_uv_B[B_top_right.index] = new Vector2(1.0f,0.0f);
        new_uv_B[B_top_left.index] = new Vector2(1.0f,1.0f);
        new_uv_B[B_bot_left.index] = new Vector2(b_left, 1.0f);
        new_uv_B[B_bot_right.index] = new Vector2(b_bot,0.0f);
        if (mid)
            new_uv_B[B_mid.index] = new Vector2(b_mid, 0.0f);

        ///////////////////////////////////////////
        //обновить вершины и треугольники
        //mesh.Clear();
        //mesh.vertices = vert;

        //int[] triangles = new int[]
        //{ A_bot_right.index,A_top_right.index,A_bot_left.index,
        //A_top_right.index,A_bot_left.index,A_top_left.index,
        //A_bot_left.index,A_top_left.index,B_bot_left.index,
        //B_bot_left.index,A_top_left.index,B_top_left.index,
        //A_top_left.index,B_top_left.index,B_top_right.index };

        //mesh.triangles = triangles;
        //mesh.uv = new_uv;
        ///////////////////////////////////////////
        mesh_A.uv = new_uv_A;
        mesh_B.uv = new_uv_B;

        
        //mesh.Optimize();
        //List<Vector2> _new_uv_a = new List<Vector2>(new_uv_A);
        //mesh_A.SetUVs(0, _new_uv_a);
        //List<Vector2> _new_uv_b = new List<Vector2>(new_uv_B);
        //mesh_B.SetUVs(0, _new_uv_b);

    }
    int[] FindTriangle(int index,Mesh mesh)
    {
        int[] triangle = new int[3];
        //print(mesh.triangles.Length);
        for (int i = 0; i < mesh.triangles.Length; i += 3)
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
    int[] FindTriangle(int ind1, int ignore, Mesh mesh)
    {
        int[] triangle = new int[3];
        //print(mesh.triangles.Length);
        for (int i = 0; i < mesh.triangles.Length; i += 3)
        {
            bool k1 = false;
            bool k2 = true;
            triangle = new int[] { mesh.triangles[i], mesh.triangles[i + 1], mesh.triangles[i + 2] };
            for (int j = 0; j < 3; j++)
            {
                if ((triangle[j] == ind1) )
                {
                    k1 = true;
                }
            }

            for (int j = 0; j < 3; j++)
            {
                if ((triangle[j] == ignore))
                {
                    k2=false;
                }
            }

            if (k1&&k2)
            {
                return triangle;
            }
               
            
        }
        print("no triangles found");
        return triangle;
    }
    int[] FindTriangle(int ind1, int ind2, out int new_vert,Mesh mesh)
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
            if (k == 2)
            {
                return triangle;
            }
        }
        print("no triangles found");
        return triangle;
    }
}
