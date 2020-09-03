using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public PlayerController playerhealth;
    public Text deathMessage;

    GameManager man;//GameManager();
    int deaths = 0;
    float delay = 5f;

    Animator anim;
    float restartTimer;
    bool isDead = false, beaten = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        man = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        //deaths = man.deaths;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerhealth.health <= 0 && !isDead)
        {
            anim.SetTrigger("GameOver");
            man.IncDeaths();
            deaths = man.GetDeaths();

            if (deaths == 1 && !isDead)
            {
                deathMessage.text = "I guess it's only your first death so it's not that bad";
            }
            else if (deaths == 2 && !isDead)
            {
                deathMessage.text = "Dude that's the second death on the first level...";
            }
            else if (deaths == 3 && !isDead)
            {
                deathMessage.text = "You're fucking trash";
            }
            else if (deaths == 4 && !isDead)
            {
                deathMessage.text = "FUCK YOU";
            }
            isDead = true;
        }

        if (isDead)
        {
            restartTimer += Time.deltaTime;

            if (restartTimer >= delay)
            {
                isDead = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else if (beaten)
        {

        }
    }
}
