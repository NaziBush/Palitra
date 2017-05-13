using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour
{
    Line_Default line;
    Transform tran;
    [SerializeField]
    float dist;

    // Use this for initialization
    void Start()
    {
        line = GetComponent<Line_Default>();
        tran = GetComponent<Transform>();

    }

    void OnEnable()
    {
        StartCoroutine(SwitchColor());
    }

    IEnumerator SwitchColor()
    {
        yield return new WaitForSeconds(0.2f);
        while (tran.position.y - Ball.ball.gameObject.transform.position.y > dist)
        {
            //line.ChangeColor(SkinManager.skin_manager.GetCurrentSkin().colors[Random.Range(0, SkinManager.skin_manager.GetCurrentSkin().colors.Length)]);
            line.ChangeColor();
            yield return new WaitForSeconds(1.0f);
        }
    }
}
