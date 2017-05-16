using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeToSkinColor : MonoBehaviour
{
    public enum SkinColors { Color_1,Color_2,Color_3};
    public SkinColors color;
	
    void OnEnable()
    {

        EventManager.StartListening("SkinChanged", ChangeColor);
        ChangeColor();
    }

    void OnDisable()
    {
        EventManager.StopListening("SkinChanged", ChangeColor);
    }

    void ChangeColor()
    {
        Image image = GetComponent<Image>();
        if (image!=null)
        {
            image.color = SkinManager.skin_manager.GetCurrentSkin().colors[(int)color];
        }
        else
        {
            SpriteRenderer sprite_rend = GetComponent<SpriteRenderer>();
            if (sprite_rend!=null)
            {
                sprite_rend.color = SkinManager.skin_manager.GetCurrentSkin().colors[(int)color];
            }
        }
    }
}
