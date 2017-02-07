using UnityEngine;
using System.Collections;

public class SpawnWaves : MonoBehaviour
{
    float start_delay=5.0f;
    public Pool pool;
    [Space(20)]
    public float startWait;

    
    float dist;
    float edge;
    int lines_passed;
    int lines_spawned;

    bool is_spawning;


    float Dist
    {
        get
        {
            return dist;
        }

        set
        {
            dist = Mathf.Clamp(value, GameController.game_controller.GetLvlData().min_dist, GameController.game_controller.GetLvlData().max_dist);
        }
    }

    void Start ()
    {
        lines_passed = 0;
        lines_spawned = 0;
        StartCoroutine(Delay());
    }
    void OnEnable()
    {
        EventManager.StartListening("LinePassed", LinePassed);
        EventManager.StartListening("ChangeLvl", ChangeLvl);
    }
    void OnDisable()
    { 
        EventManager.StopListening("LinePassed", LinePassed);
        EventManager.StopListening("ChangeLvl", ChangeLvl);
    }

    void LinePassed()
    {
        lines_passed++;
        if (lines_passed >= GameController.game_controller.GetLvlData().lines_to_chng_dist)
        {
            lines_passed = 0;
            Dist -= GameController.game_controller.GetLvlData().chng_dist_val;
        }
    }

    void ChangeLvl()
    {
        lines_passed = 0;
        lines_spawned = 0;
        StartCoroutine(Delay());

    }
    IEnumerator Delay()
    {
        is_spawning = false;
        yield return new WaitForSeconds(start_delay);
        edge = Edges.topEdge;
        Dist = GameController.game_controller.GetLvlData().max_dist;
        //SpawnWave();
        is_spawning = true;
    }

    void Update()
    {
        if ((is_spawning)&&(Edges.topEdge >= edge+dist)&&(lines_spawned < GameController.game_controller.GetLvlData().lines_to_chng_lvl))
        {
            lines_spawned++;
            edge += Dist;
            SpawnWave();
        }
    }

    void SpawnWave()
    {
        pool.Activate(new Vector2(0.0f, edge), Quaternion.identity);
    }





}
