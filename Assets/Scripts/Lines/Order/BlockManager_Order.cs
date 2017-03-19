using UnityEngine;
using System.Collections;

public class BlockManager_Order : MonoBehaviour
{
    public int block_count;
    public GameObject block;
    public Transform block_holder;
    public Transform arrow;

    Block_Order[] block_mas;
    Line_Order line;
    float block_size;
    float window_size;
    //int active_block_count;
    int current_block;
    

    void Start()
    {
        window_size = Edges.rightEdge - Edges.leftEdge;
        block_size = window_size / (float)block_count;
        line = GetComponent<Line_Order>();
        InitBlocks();
    }

    void OnEnable()
    {
        //active_block_count = block_count;
        EventManager.StartListening("BallColorChanged", ColorChanged);
        current_block = 0;
        arrow.gameObject.SetActive(true);
        if (block_mas!=null)
            arrow.position = block_mas[0].GetPosition();
    }
    void OnDisable()
    {
        EventManager.StopListening("BallColorChanged", ColorChanged);
    }
    void ColorChanged()
    {
        if (line.CheckIfActive())
        {
            if (Ball.ball.sprite_rend.color == block_mas[current_block].GetColor())
            {
                //active_block_count--;
                block_mas[current_block].Disable();
                current_block++;


                if (current_block >= block_count)
                {
                    line.Disable();
                    arrow.gameObject.SetActive(false);

                    return;
                }
                arrow.position = block_mas[current_block].GetPosition();
            }
            else
            {
                foreach (Block_Order item in block_mas)
                {
                    item.Enable();
                }
                current_block = 0;
                arrow.position = block_mas[0].GetPosition();
            }
        }
    }
    void InitBlocks()
    {
        Vector3 spawn_position;
        GameObject obj;

        for (int i = 0; i < block_count; i++)
        {
            spawn_position = new Vector3(Edges.leftEdge + block_size / 2.0f + block_size * i, transform.position.y);
            obj = (GameObject)Instantiate(block, spawn_position, Quaternion.identity);
            obj.transform.localScale = new Vector3(block_size + 0.1f, obj.transform.localScale.y, 1.0f);
            Color color = GameController.game_controller.GetLvlData().colors
            [Random.Range(0, GameController.game_controller.GetLvlData().colors.Length)];
            obj.GetComponent<Block_Order>().SetColor(color);
            obj.transform.SetParent(block_holder);
        }
        block_mas = GetComponentsInChildren<Block_Order>();
        arrow.position = block_mas[0].GetPosition();
    }

    public IEnumerator SetRandomColors()
    {
        //print("sfg");
        while (block_mas == null)
            yield return new WaitForEndOfFrame();


        //создаем и заполняем массив цветов
        int color_count = GameController.game_controller.GetLvlData().colors.Length > block_count ?
            GameController.game_controller.GetLvlData().colors.Length : block_count;

        Color[] colors = new Color[color_count];
        for (int i = 0; i < color_count; i++)
        {

            if (i < 3)
            {
                colors[i] = GameController.game_controller.GetLvlData().colors[i];
                //Debug.Log(colors[i]);
            }
            else
            {
                colors[i] = GameController.game_controller.GetLvlData().colors
                    [Random.Range(0, GameController.game_controller.GetLvlData().colors.Length)];
            }
        }
        //перемешиваем массив цветов
        new System.Random().Shuffle(colors);
        //присваеваем цвета блокам
        for (int i = 0; i < block_count; i++)
        {
            block_mas[i].SetColor(colors[i]);
        }


    }
    
}
