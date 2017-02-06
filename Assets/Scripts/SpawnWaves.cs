using UnityEngine;
using System.Collections;

public class SpawnWaves : MonoBehaviour
{
    float start_delay=2.0f;
    public Pool pool;
    [Space(20)]
    public float startWait;

    float dist;
    float edge;

    bool is_spawning;
    
    void Start ()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        is_spawning = false;
        yield return new WaitForSeconds(start_delay);
        edge = Edges.topEdge;
        dist = GameController.game_controller.GetLvlData().max_dist;
        SpawnWave();
        is_spawning = true;
    }

    void Update()
    {
        if ((is_spawning)&&(Edges.topEdge >= edge+dist))
        {
            edge += dist;
            SpawnWave();
        }
    }

    void SpawnWave()
    {
        pool.Activate(new Vector2(0.0f, edge), Quaternion.identity);
    }





}
