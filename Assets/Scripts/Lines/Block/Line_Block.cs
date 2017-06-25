using UnityEngine;
using System.Collections.Generic;
using System;

public class Line_Block : Line
{
    int block_count = 5;
    float scrollSpeed = 0.5f;
    private Vector2 savedOffset;
    Renderer left_rend;
    Renderer right_rend;
    bool left_dir = true;
    float x;
    Texture2D main_texture;

    public override void InitLine()
    {
        left_dir = UnityEngine.Random.value > 0.5f ? true : false;
        scrollSpeed = GameController.game_controller.GetLvlData().block_prop.speed;
        block_count = GameController.game_controller.GetLvlData().block_prop.block_count;
        //anim.ResetAnimation();
        base.InitLine();
        
    }

    protected override void CheckIfPassed()
    {
        if ((active) && (tran.position.y - height <= Ball.ball.collision_point.position.y))
        {
            
            //float xx = x;
            //if ((x > 0.5f) && (x <= 1.0f))
            //    xx = x - 0.5f;
           
            int coord_x = (int)(main_texture.width / 2.0f + main_texture.width * x);
            //print(texture.GetPixel(coord_x, (int)(texture.height / 2.0f)));
            List <Color> colors = new List<Color>();
            for (int i=-1;i<=1;i++)
            {
                colors.Add(main_texture.GetPixel(coord_x+i, (int)(main_texture.height / 2.0f)));
            }
            Ball.ball.LinePassed(colors,false);
            anim.BeginAnimation();
            //anim.BeginAnimation(height, Ball.ball.collision_point.position.y, tran.position.y);
        }
    }

    protected override void Awake()
    {
        //base.Awake();
        tran = GetComponent<Transform>();
        left_rend=left.GetComponent<Renderer>();
        right_rend=right.GetComponent<Renderer>();
        savedOffset = left_rend.sharedMaterial.GetTextureOffset("_MainTex");
        
        
    }
    public override void ChangeColor()
    {
        Color[] colors = SkinManager.skin_manager.GetCurrentSkin().colors;
        Texture2D[] texture = TextureHandler.CreateTexture(colors,block_count,out main_texture);
        SetTexture(texture);
        right.GetComponent<MeshRenderer>().materials[0].mainTextureScale = new Vector2(-1, 1);
        // Texture2D texture = new Texture2D(125, 80);

        // height = texture.height*Edges.pix_size*transform.localScale.y/2.0f;
        // float block_size = texture.width / (float)block_count;//в пикселях на текстуре
        // GetComponent<Renderer>().material.mainTexture = texture;
        // //Color prev_color = Color.black;
        // Color[] colors = new Color[block_count];
        // colors[0] = SkinManager.skin_manager.GetCurrentSkin().colors
        //[UnityEngine.Random.Range(0, SkinManager.skin_manager.GetCurrentSkin().colors.Length)];

        // for (int i = 1; i < block_count; i++)
        // {
        //     Color color=Color.black;
        //     for (int j = 0;j < SkinManager.skin_manager.GetCurrentSkin().colors.Length;j++)
        //      {
        //         bool cond1 = ((SkinManager.skin_manager.GetCurrentSkin().colors[j] != colors[i - 1]) &&
        //             (i != block_count - 1));
        //         bool cond2 = (i == block_count - 1) && (SkinManager.skin_manager.GetCurrentSkin().colors[j] != colors[i - 1])
        //                   && (SkinManager.skin_manager.GetCurrentSkin().colors[j] != colors[0]);

        //         if (cond1||cond2)
        //         {
        //              color = SkinManager.skin_manager.GetCurrentSkin().colors[j];
        //              break;
        //         }
        //      }
        //     colors[i] = color;
        // }

        // for (int i=0;i<block_count;i++)
        // {
        //     for (int y = 0; y < texture.height; y++)
        //     {
        //         for (int x = (int)(i * block_size); x < (int)((i + 1) * block_size); x++)
        //         {
        //             texture.SetPixel(x, y, colors[i]);
        //         }
        //     }
        // }
        //UnityEditor.AssetDatabase.CreateAsset(texture, "Assets/test.asset");
        //texture.wrapMode = TextureWrapMode.Repeat;
        //texture.Apply();
        //GetComponent<SpriteRenderer>().material = GetComponent<Renderer>().material;
        //Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), 
        //    new Vector2(0.5f, 0.5f), 100);
        //GetComponent<SpriteRenderer>().sprite = sprite;
    }

    protected override void Update()
    {
        base.Update();
        //x = left_dir? Mathf.Repeat(Time.time * scrollSpeed, 1): Mathf.Repeat(-Time.time * scrollSpeed, 1);
        //Vector2 offset = new Vector2(x, savedOffset.y);
        ////Vector2 offset_right = new Vector2(-x, savedOffset.y);


        //left_rend.materials[0].SetTextureOffset("_MainTex", offset);
        //left_rend.materials[1].SetTextureOffset("_MainTex", offset);

        //right_rend.materials[0].SetTextureOffset("_MainTex", offset);
        //right_rend.materials[1].SetTextureOffset("_MainTex", offset);
        //rend.material.mainTextureOffset=offset;
    }


}


  



