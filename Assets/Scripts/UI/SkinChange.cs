using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinChange : MonoBehaviour
{
    public Image[] sectors;
    public Text skin_count_text;
    public Text price_text;
    public Text score_text;
    public Text set_skin_text;
    int skin_number;

    public void NextSkin()
    {
        if (skin_number == SkinManager.skin_manager.GetTotalSkinCount() - 1)
        {
            skin_number = 0;
        }
        else
        {
            skin_number++;
        }
        UpdateSkin();
        UpdateText();
    }

    public void PrevSkin()
    {
        if (skin_number == 0)
        {
            skin_number = SkinManager.skin_manager.GetTotalSkinCount() - 1;
        }
        else
        {
            skin_number--;
        }
        UpdateSkin();
        UpdateText();
    }

    public void SetSkin()
    {
        if (CheckIfAvailable(skin_number))
        {
            SkinManager.skin_manager.SetActiveSkin(skin_number);
        }
        else
        {
            if (GlobalScore.global_score.Score >= SkinManager.skin_manager.GetSkinByNumber(skin_number).price)
            {
                GlobalScore.global_score.Score -= SkinManager.skin_manager.GetSkinByNumber(skin_number).price;
                PlayerPrefs.SetInt(SkinManager.skin_manager.GetSkinByNumber(skin_number).name, 1);
            }
        }
        
        UpdateText();
        
        
    }

    void Start()
    {
        skin_number = SkinManager.skin_manager.GetSkinNumber();
        for (int i=0;i<SkinManager.skin_manager.GetTotalSkinCount();i++)
        {
            if ((!CheckIfAvailable(i))&&(SkinManager.skin_manager.GetSkinByNumber(i).price==0))
            {
                PlayerPrefs.SetInt(SkinManager.skin_manager.GetSkinByNumber(i).name, 1);
            }
        }
        UpdateSkin();
        UpdateText();
        UpdateScore();
    }

    void UpdateSkin()
    {
        for (int i = 0; i < sectors.Length;i++)
        {
            sectors[i].color = SkinManager.skin_manager.GetSkinByNumber(skin_number).colors[i];
        }

    }

    void UpdateText()
    {
        skin_count_text.text = (skin_number+1).ToString()+"/"+SkinManager.skin_manager.GetTotalSkinCount();
        price_text.text = SkinManager.skin_manager.GetSkinByNumber(skin_number).price.ToString();
        score_text.text = GlobalScore.global_score.Score.ToString();
        if (CheckIfAvailable(skin_number))
        {
            set_skin_text.text = "Set";
        }
        else
        {
            set_skin_text.text = "Buy";
        }
    }

    void UpdateScore()
    {
        score_text.text = GlobalScore.global_score.Score.ToString();
    }
	
    bool CheckIfAvailable(int number)
    {
        if (PlayerPrefs.HasKey(SkinManager.skin_manager.GetSkinByNumber(number).name))
        {
            return true;
        }
        
        return false;
    }
}
