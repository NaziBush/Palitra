using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Sector : MonoBehaviour, IPointerClickHandler
{
    Color color;
    
    void Start()
    {
        color = GetComponent<Image>().color;
    }

    #region IPointerClickHandler implementation

    public void OnPointerClick(PointerEventData eventData)
    {
        //print("Clicked me!"+gameObject.name);
        Ball.ball.SetColor(color);
    }

    #endregion
}