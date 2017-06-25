using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point
{
    public Vector2 coord;
    public int index;

    public Point(Vector2 _coord,int _index)
    {
        coord = _coord;
        index = _index;
    }
}
public class CalcUV : MonoBehaviour
{
    
    Mesh mesh;
    
    void Start ()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        Vector2[] uv = mesh.uv;
        
        Vector3[] vert = mesh.vertices;
       

        
        //for (int i = 0; i < vert.Length; i++)
        //{
        //    print(vert[i]);
        //    print(uv[i]);
        //}

        //удалить дублирующиеся вершины
        //vert = DeleteDoubleVert(mesh.vertices);

        //print("после удаления лишних");
        //for (int i = 0; i < vert.Length; i++)
        //{
        //    print(vert[i]);
        //}


        Point A_bot_left = new Point(vert[0], 0);
        Point A_top_left = new Point(vert[0], 0);
        Point A_bot_right = new Point(vert[0], 0);
        Point A_top_right = new Point(vert[0], 0);
        //A_bot_right
        for (int i = 0; i < vert.Length; i++)
        {
            if ((vert[i].x >= A_bot_right.coord.x) && (vert[i].y <= A_bot_right.coord.y))
            {
                A_bot_right.coord.x = vert[i].x;
                A_bot_right.coord.y = vert[i].y;
                A_bot_right.index = i;
            }
        }

        //A_top_right
        A_top_right = new Point(A_bot_right.coord, A_bot_right.index);
        for (int i = 0; i < vert.Length; i++)
        {
            if ((vert[i].x == A_bot_right.coord.x) && (vert[i].y > A_top_right.coord.y))
            {
                A_top_right.coord.x = vert[i].x;
                A_top_right.coord.y = vert[i].y;
                A_top_right.index = i;
            }
        }

        //A_top_left
        A_top_left = new Point(A_top_right.coord, A_top_right.index);
        for (int i = 0; i < vert.Length; i++)
        {
            if ((vert[i].x < A_top_left.coord.x) && (Mathf.Abs(vert[i].y - A_top_right.coord.y)<0.1f))
            {
                A_top_left.coord.x = vert[i].x;
                A_top_left.coord.y = vert[i].y;
                A_top_left.index = i;
            }
        }

        //A_bot_left
        A_bot_left = new Point(A_bot_right.coord, A_bot_right.index);
        for (int i = 0; i < vert.Length; i++)
        {
            if ((vert[i].x < A_bot_left.coord.x) && (Mathf.Abs(vert[i].y - A_bot_right.coord.y) < 0.1f))
            {
                A_bot_left.coord.x = vert[i].x;
                A_bot_left.coord.y = vert[i].y;
                A_bot_left.index = i;
            }
        }

        print(A_bot_right.coord.x + " " + A_bot_right.coord.y+ " , " 
            + A_top_right.coord.x + " " + A_top_right.coord.y + " , "
            + A_top_left.coord.x + " " + A_top_left.coord.y + " , "
             + A_bot_left.coord.x + " " + A_bot_left.coord.y);


       


        Point B_bot_left = new Point(vert[0], 0);
        Point B_top_left = new Point(vert[0], 0);
        //Point B_bot_right = new Point(vert[0], 0);
        Point B_top_right = new Point(vert[0], 0);

        //B_bot_left
        for (int i = 0; i < vert.Length; i++)
        {
            if (vert[i].x < B_bot_left.coord.x)
            {
                B_bot_left.coord.x = vert[i].x;
                B_bot_left.coord.y = vert[i].y;
                B_bot_left.index = i;
            }
        }

        //B_top_left
        for (int i = 0; i < vert.Length; i++)
        {
            if (vert[i].y > B_top_left.coord.y)
            {
                B_top_left.coord.x = vert[i].x;
                B_top_left.coord.y = vert[i].y;
                B_top_left.index = i;
            }
        }

        //B_top_right
        for (int i = 0; i < vert.Length; i++)
        {
            if ((vert[i].y < B_top_left.coord.y)&&((vert[i].y > A_top_left.coord.y)) &&
                ((vert[i].x > A_top_left.coord.x)))
            {
                B_top_right.coord.x = vert[i].x;
                B_top_right.coord.y = vert[i].y;
                B_top_right.index = i;
            }
        }

        //B_bot_right.coord.x + " " + B_bot_right.coord.y + " , "
        print(B_top_right.coord.x + " " + B_top_right.coord.y + " , "
            + B_top_left.coord.x + " " + B_top_left.coord.y + " , "
             + B_bot_left.coord.x + " " + B_bot_left.coord.y);

        //задать uv-координаты
        //float a1 = (B_top_right.coord - A_bot_left.coord).magnitude;
        //float a2 = (A_bot_right.coord - A_bot_left.coord).magnitude;
        //float a = a1 + a2;
        //float bot = a2 / a;

        //float b1 = (B_top_left.coord - B_bot_left.coord).magnitude;
        //float b2 = (A_top_right.coord - B_bot_left.coord).magnitude;
        //float b3 = (A_top_right.coord - A_top_left.coord).magnitude;
        //float b = b1 + b2;
        //float top1 = 1.0f-(b1 / b);
        //float top2 = b3/b;
        float a1 = (B_top_right.coord - A_bot_left.coord).magnitude;
        float a2 = (A_top_right.coord - A_top_left.coord).magnitude;
        float a = a1 + a2;
        float top = a2 / a;

        float b1 = (B_top_left.coord - B_bot_left.coord).magnitude;
        float b2 = (B_bot_left.coord - A_bot_left.coord).magnitude;
        float b3 = (A_bot_right.coord - A_bot_left.coord).magnitude;
        float b = b1 + b2+b3;
        float bot1;
        float bot2;

        Vector2[] new_uv = new Vector2[vert.Length];
        for (int i = 0; i < new_uv.Length; i++)
        {
            new_uv[i] = new Vector2(0.0f, 0.0f);
        }



        //new_uv[A_bot_right.index] = new Vector2(0.0f,0.0f);
        //new_uv[A_top_right.index] = new Vector2(0.0f,1.0f);
        //new_uv[A_bot_left.index] = new Vector2(bot,0.0f);
        //new_uv[A_top_left.index] = new Vector2(top2,1.0f);

        //new_uv[B_top_right.index] = new Vector2(1.0f,0.0f);
        //new_uv[B_top_left.index] = new Vector2(1.0f,1.0f);
        //new_uv[B_bot_left.index] = new Vector2(top1,1.0f);

        new_uv[A_bot_right.index] = new Vector2();
        new_uv[A_top_right.index] = new Vector2();
        new_uv[A_bot_left.index] = new Vector2();
        new_uv[A_top_left.index] = new Vector2();

        new_uv[B_top_right.index] = new Vector2();
        new_uv[B_top_left.index] = new Vector2();
        new_uv[B_bot_left.index] = new Vector2();
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
        mesh.uv = new_uv;



    }
    

    Vector3[] DeleteDoubleVert(Vector3[] vert)
    {
        int k = 0;
        Vector3[] new_vert;
        Vector3[] temp = new Vector3[vert.Length];
        for (int i = 0; i < vert.Length; i++)
        {
            bool doubles = false;
            for (int j = 0; j < i; j++)
            {
                if ((vert[i] - vert[j]).magnitude < 0.1f)
                {
                    doubles = true;
                }
            }
            if (!doubles)
            {
                temp[k] = vert[i];
                k++;
            }
        }

        new_vert = new Vector3[k];
        for (int i = 0; i < k; i++)
        {
            new_vert[i] = temp[i];
        }
        return new_vert;

    }
}
