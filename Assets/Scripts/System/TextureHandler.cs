using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureHandler 
{
    static int text_size = 256;
    static int half_size = text_size/2;

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

    

    public static Texture2D[] CreateTexture(Color[] colors, int block_count, float unused_part,
        out Color[] new_colors)
    {
        
        Texture2D[] texture = new Texture2D[2];
        texture[0] = new Texture2D(half_size, 80);
        texture[1] = new Texture2D(half_size, 80);

        new_colors = CreateBlockColors(colors, block_count);
        

        Texture2D text = new Texture2D(text_size, 80);
        int grey_left = (int)(text.width* unused_part);
        int grey_right = (int)(text.width * (1.0f-unused_part));
        //float block_size = (text.width-2.0f*unused_part) / (float)block_count;

        for(int x=0;x<text.width;x++)
        {
            for (int y=0;y<text.height;y++)
            {
                if ((x < grey_left) || (x > grey_right))
                {
                    text.SetPixel(x, y, Color.grey);
                }
            }
        }


        int block_size = (grey_right - grey_left) / block_count;

        //int h = 0;
        //int[] mas=new int[block_count];
        //for (int x=)
        int h = 0;
        int xx=0;
        for (int x=grey_left;x<=grey_right;x++)
        {
            xx++;
            if (xx>block_size)
            {
                xx = 0;
                h++;
            }
            for (int y=0;y<text.height;y++)
            {
                if (h<new_colors.Length)
                text.SetPixel(x, y, new_colors[h]);
            }
        }

        for (int x = 0; x < half_size; x++)
        {
            for (int y = 0; y < text.height; y++)
            {
                texture[0].SetPixel(x, y, text.GetPixel(x, y));
            }
        }

        for (int x = 0; x < half_size; x++)
        {
            for (int y = 0; y < text.height; y++)
            {
                texture[1].SetPixel(x, y, text.GetPixel(x + half_size, y));
            }
        }

        //for (int x = 0; x < 64; x++)
        //{
        //    for (int y = 0; y < text.height; y++)
        //    {
        //        texture[1].SetPixel(64-x, y, text.GetPixel(x+64, y));
        //    }
        //}

        text.Apply();
        texture[0].Apply();
        texture[1].Apply();

        ////
        texture[0] = text;
        texture[1] = text;
        ////
        //main_text = text;
        return texture;
    }

    public static Texture2D[] CreateTexture(Color[] colors, int block_count,
        out Color[] new_colors)
    {
        Texture2D[] texture = new Texture2D[2];
        texture[0] = new Texture2D(64, 80);
        texture[1] = new Texture2D(64, 80);
        new_colors = CreateBlockColors(colors, block_count);

        Texture2D text = new Texture2D(128, 80);
        float block_size = text.width / (float)block_count;
        for (int i = 0; i < block_count; i++)
        {
            for (int y = 0; y < text.height; y++)
            {
                for (int x = (int)(i * block_size); x < (int)((i + 1) * block_size); x++)
                {
                    text.SetPixel(x, y, new_colors[i]);
                }
            }
        }

        for (int x = 0; x < 64; x++)
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

        text.Apply();
        texture[0].Apply();
        texture[1].Apply();

        ////
        texture[0] = text;
        texture[1] = text;
        ////
        //main_text = text;
        return texture;
    }

    public static Texture2D[] CreateTexture(Color[] colors,int block_count,out Texture2D main_text)
    {
        Texture2D[] texture = new Texture2D[2];
        texture[0] = new Texture2D(64, 80);
        texture[1] = new Texture2D(64, 80);
       Color[] new_colors = CreateBlockColors(colors, block_count);

        Texture2D text= new Texture2D(128, 80);
        float block_size = text.width / (float)block_count;
        for (int i = 0; i < block_count; i++)
        {
            for (int y = 0; y < text.height; y++)
            {
                for (int x = (int)(i * block_size); x < (int)((i + 1) * block_size); x++)
                {
                    text.SetPixel(x, y, new_colors[i]);
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

        text.Apply();
        texture[0].Apply();
        texture[1].Apply();

        ////
        texture[0]=text;
        texture[1] = text;
        ////
        main_text = text;
        return texture;
    }

    static Color[] CreateBlockColors(Color[] colors, int block_count)
    {
        Color[] new_colors = new Color[block_count];
        new_colors[0] = SkinManager.skin_manager.GetCurrentSkin().colors
       [UnityEngine.Random.Range(0, SkinManager.skin_manager.GetCurrentSkin().colors.Length)];
        for (int i = 1; i < block_count; i++)
        {
            //Color color = Color.black;
            Color[] avail_col = new Color[colors.Length - 1];
            int n = 0;
            for (int j = 0; j < colors.Length; j++)
            {
                if (new_colors[i - 1] != colors[j])
                {
                    avail_col[n] = colors[j];
                    n++;
                }
            }
            new_colors[i] = avail_col[UnityEngine.Random.Range(0, avail_col.Length)];
        }

        for (int i = 0; i < colors.Length; i++)
        {
            if ((colors[i] != new_colors[0]) && (colors[i] != new_colors[new_colors.Length - 2]))
            {
                new_colors[new_colors.Length - 1] = colors[i];
                break;
            }
        }
        return new_colors;
    }
}
