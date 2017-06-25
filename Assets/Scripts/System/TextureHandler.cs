using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TextureType { Default};

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
}
