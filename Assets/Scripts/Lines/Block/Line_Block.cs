using UnityEngine;
using System.Collections.Generic;
using System;

public class Line_Block : Line
{
    int block_count = 5;
    float scrollSpeed = 0.5f;
    private Vector2 savedOffset;
    Renderer rend;
    bool left_dir = true;
    float x;

    public override void InitLine()
    {
        left_dir = UnityEngine.Random.value > 0.5f ? true : false;
        scrollSpeed = GameController.game_controller.GetLvlData().block_prop.speed;
        block_count = GameController.game_controller.GetLvlData().block_prop.block_count;
        base.InitLine();
    }

    protected override void CheckIfPassed()
    {
        if ((active) && (tran.position.y - height <= Ball.ball.collision_point.position.y))
        {
            Texture2D texture = (Texture2D)GetComponent<Renderer>().material.mainTexture;
            //float xx = x;
            //if ((x > 0.5f) && (x <= 1.0f))
            //    xx = x - 0.5f;
           
            int coord_x = (int)(texture.width / 2.0f + texture.width * x);
            //print(texture.GetPixel(coord_x, (int)(texture.height / 2.0f)));
            List <Color> colors = new List<Color>();
            for (int i=-1;i<=1;i++)
            {
                colors.Add(texture.GetPixel(coord_x+i, (int)(texture.height / 2.0f)));
            }
            Ball.ball.LinePassed(colors,false);
        }
    }

    protected override void Awake()
    {
        //base.Awake();
        tran = GetComponent<Transform>();
        rend = GetComponent<Renderer>();
        savedOffset = rend.sharedMaterial.GetTextureOffset("_MainTex");
    }
    public override void ChangeColor()
    {
        Texture2D texture = new Texture2D(125, 80);
        
        height = texture.height*Edges.pix_size*transform.localScale.y/2.0f;
        float block_size = texture.width / (float)block_count;//в пикселях на текстуре
        GetComponent<Renderer>().material.mainTexture = texture;
        //Color prev_color = Color.black;
        Color[] colors = new Color[block_count];
        colors[0] = SkinManager.skin_manager.GetSkin().colors
       [UnityEngine.Random.Range(0, SkinManager.skin_manager.GetSkin().colors.Length)];
        for (int i = 1; i < block_count; i++)
        {
            Color color=Color.black;
            for (int j = 0;j < SkinManager.skin_manager.GetSkin().colors.Length;j++)
             {
                bool cond1 = ((SkinManager.skin_manager.GetSkin().colors[j] != colors[i - 1]) && (i != block_count - 1));
                bool cond2 = (i == block_count - 1) && (SkinManager.skin_manager.GetSkin().colors[j] != colors[i - 1])
                          && (SkinManager.skin_manager.GetSkin().colors[j] != colors[0]);
                if (cond1||cond2)
                {
                     color = SkinManager.skin_manager.GetSkin().colors[j];
                     break;
                }
             }
            colors[i] = color;
        }

        for (int i=0;i<block_count;i++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                for (int x = (int)(i * block_size); x < (int)((i + 1) * block_size); x++)
                {
                    texture.SetPixel(x, y, colors[i]);
                }
            }
        }
        

        texture.Apply();
        //GetComponent<SpriteRenderer>().sprite = Sprite.Create
        //    (texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }

    protected override void Update()
    {
        base.Update();
        

        x = left_dir? Mathf.Repeat(Time.time * scrollSpeed, 1): Mathf.Repeat(-Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(x, savedOffset.y);
        rend.material.SetTextureOffset("_MainTex", offset);

        //if (Input.GetKey(KeyCode.A))
            //CheckIfPassed();




    //if (!left_dir)
    {
            //x -= 0.5f;
            //print(texture.GetPixel((int)(texture.width/2.0f + texture.width * x), (int)(texture.height / 2.0f)));
            
        }
        
    }

    //void func1(int[] mas, int x, int y, out int vozvrat, out int vozvrat2)//x,y просто от балды sooqa blyat nahhooooy
    //{
    //    for (int i = 0; i < mas.Length; i++)
    //    {
    //        //делаем хуйню с массивом
    //    }
    //    vozvrat = 213543456;//возвращаем хуйню, которую тебе надо вытащить
    //    vozvrat2 = 457567567;
    //}

    //void func2(int[] mas, int vozvrat, int vozvrat2)
    //{
    //    //делаем еще какую-то хуйню с массивом
    //}

    //void main_func()//отсюда типа вызываем funkцii понел да blyat
    //{
    //    int[] mas = new int[10];

    //    int vozvrat, vozvrat2;
    //    func1(mas, 1, 2, out vozvrat, out vozvrat2);//типа операция с массивом, и вернули значения которые нужны ок да азазаз
    //    func2(mas, vozvrat, vozvrat2);//сюда передали сохраненные значения
    //    //вообще ниибу оно скомпилится или нет, рандомную поебту набросал фастом
    //}
}


    //BlockManager block_manager;


    //public override void InitLine()
    //{
    //    active = true;
    //    block_manager = GetComponent<BlockManager>();
    //    block_manager.InitBlocks();
    //    //tran.position = tran.position - new Vector3(5.0f, 0.0f, 0.0f);
    //}

    //protected override void CheckIfPassed()
    //{
    //    if ((active) && (tran.position.y - height <= Ball.ball.collision_point.position.y))
    //    {
    //        List<Color> colors = block_manager.CheckCollisions();
    //        Ball.ball.LinePassed(colors,false);
    //    }
    //}

    //public override void ChangeColor()
    //{
    //    block_manager.SetRandomColors();
    //}




