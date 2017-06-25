using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureHandler 
{
    
	public static Texture2D[] CreateTexture(Color color)
    {
        Texture2D[] texture = new Texture2D[2];
        texture[0] = new Texture2D(64, 80);
        texture[1] = new Texture2D(64, 80);

        for(int k=0;k<texture.Length;k++)
        {
             for (int i=0;i<texture[k].width;i++)
            {
                for (int j=0;j<texture[k].height;j++)
                {
                    texture[k].SetPixel(i, j, color);
                }
            }
            texture[k].Apply();
        } 
                   
        return texture;
    }

    public static Texture2D[] CreateTexture(Color[] colors,int block_count,out Texture2D main_text)
    {
        Texture2D[] texture = new Texture2D[2];
        texture[0] = new Texture2D(64, 80);
        texture[1] = new Texture2D(64, 80);

        Color[] new_colors = new Color[block_count];
        new_colors[0] = SkinManager.skin_manager.GetCurrentSkin().colors
       [UnityEngine.Random.Range(0, SkinManager.skin_manager.GetCurrentSkin().colors.Length)];
        for (int i = 1; i < block_count; i++)
        {
            Color color = Color.black;
            for (int j = 0; j < SkinManager.skin_manager.GetCurrentSkin().colors.Length; j++)
            {
                bool cond1 = ((SkinManager.skin_manager.GetCurrentSkin().colors[j] != new_colors[i - 1]) &&
                    (i != block_count - 1));
                bool cond2 = (i == block_count - 1) && 
                    (SkinManager.skin_manager.GetCurrentSkin().colors[j] != new_colors[i - 1]) &&
                    (SkinManager.skin_manager.GetCurrentSkin().colors[j] != new_colors[0]);

                if (cond1 || cond2)
                {
                    color = SkinManager.skin_manager.GetCurrentSkin().colors[j];
                    break;
                }
            }
            new_colors[i] = color;
        }

        Texture2D text= new Texture2D(128, 80);
        float block_size = text.width / (float)block_count;
        for (int i = 0; i < block_count; i++)
        {
            for (int y = 0; y < text.height; y++)
            {
                for (int x = (int)(i * block_size); x < (int)((i + 1) * block_size); x++)
                {
                    text.SetPixel(x, y, colors[i]);
                }
            }
        }

        for (int x=0;x<64;x++)
        {
            for (int y = 0; y < text.height; y++)
            {
                 texture[0].SetPixel(x, y, text.GetPixel(x, y));
            }
        }

        for (int x = 0; x < 64; x++)
        {
            for (int y = 0; y < text.height; y++)
            {
                texture[1].SetPixel(x, y, text.GetPixel(x + 64, y));
            }
        }
        
        //for (int x = 0; x < 64; x++)
        //{
        //    for (int y = 0; y < text.height; y++)
        //    {
        //        texture[1].SetPixel(64-x, y, text.GetPixel(x+64, y));
        //    }
        //}
        texture[0].Apply();
        texture[1].Apply();

        main_text = text;
        return texture;
    }
}
