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
        GetComponent<Image>().color = SkinManager.skin_manager.GetCurrentSkin().colors[(int)color];
    }
}
