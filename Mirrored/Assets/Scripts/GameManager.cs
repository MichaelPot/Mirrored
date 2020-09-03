using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    int deaths = 0;
    private static GameManager instance = null;
    public bool hasMakeMirror = false, hasTPEnemy = false, has2Hit = false;
    public int skillPoints = 0;
    EnemySpawner spawner;
    bool done = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawner.allDead && !done)
        {
            skillPoints++;
            Debug.Log(skillPoints);
            done = true;
        }
    }

    public void IncDeaths()
    {
        deaths++;
    }

    public int GetDeaths()
    {
        return deaths;
    }
}
