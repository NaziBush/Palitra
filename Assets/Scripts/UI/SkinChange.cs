using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinChange : MonoBehaviour
{
    public Image[] sectors;
    public Text skin_text;

    public void NextSkin()
    {
        SkinManager.skin_manager.NextSkin();
        UpdateSkin();
        UpdateText();
    }

    public void PrevSkin()
    {
        SkinManager.skin_manager.PrevSkin();
        UpdateSkin();
        UpdateText();
    }

    void Start()
    {
        UpdateSkin();
        UpdateText();
    }

    void UpdateSkin()
    {
        for (int i = 0; i < sectors.Length;i++)
        {
            sectors[i].color = SkinManager.skin_manager.GetSkin().colors[i];
        }
    }

    void UpdateText()
    {
        skin_text.text = (SkinManager.skin_manager.GetSkinNumber()+1).ToString()+"/"+SkinManager.skin_manager.GetTotalSkinCount();
    }
	
}
