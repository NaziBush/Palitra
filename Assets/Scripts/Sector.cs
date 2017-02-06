using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Sector : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    Color sect_color;
    
    void Start()
    {
        sect_color = GetComponent<Image>().color;
    }

    #region IPointerClickHandler implementation

    public void OnPointerClick(PointerEventData eventData)
    {
        //print("Clicked me!"+gameObject.name);
        Ball.ball.SetColor(sect_color);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //print("Clicked me!"+gameObject.name);
        Ball.ball.SetColor(sect_color);
    }

    public void InitSector(Color color)
    {
        GetComponent<Image>().color = color;
        sect_color = color;
    }
    #endregion
}