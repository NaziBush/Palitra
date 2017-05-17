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
        colors[0] = SkinManager.skin_manager.GetCurrentSkin().colors
       [UnityEngine.Random.Range(0, SkinManager.skin_manager.GetCurrentSkin().colors.Length)];

        for (int i = 1; i < block_count; i++)
        {
            Color color=Color.black;
            for (int j = 0;j < SkinManager.skin_manager.GetCurrentSkin().colors.Length;j++)
             {
                bool cond1 = ((SkinManager.skin_manager.GetCurrentSkin().colors[j] != colors[i - 1]) && (i != block_count - 1));
                bool cond2 = (i == block_count - 1) && (SkinManager.skin_manager.GetCurrentSkin().colors[j] != colors[i - 1])
                          && (SkinManager.skin_manager.GetCurrentSkin().colors[j] != colors[0]);

                if (cond1||cond2)
                {
                     color = SkinManager.skin_manager.GetCurrentSkin().colors[j];
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
    }

    protected override void Update()
    {
        base.Update();
        x = left_dir? Mathf.Repeat(Time.time * scrollSpeed, 1): Mathf.Repeat(-Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(x, savedOffset.y);
        rend.material.SetTextureOffset("_MainTex", offset);      
    }
}


  



