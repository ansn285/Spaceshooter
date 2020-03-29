using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
public class GameController : MonoBehaviour
{
    [System.NonSerialized] public GameObject[] enemiesInScene;
    public int lightEnemyCount;
    public int heavyEnemyCount;

    public GameObject healthPowerup;
    public GameObject missilePowerup;

    public Canvas gameOverCanvas;
    public Canvas pauseMenu;

    [System.NonSerialized] public int showMissileHelp;

    private PlayerController player;

    private void Start()
    {
        Time.timeScale = 0;
        GameObject.Find("HelpCanvas").GetComponent<Canvas>().enabled = true;
        showMissileHelp = 1;
        InvokeRepeating("PowerupSpawn", 10, 10);

        player = GameObject.Find("Spaceship").GetComponent<PlayerController>();
    }


    private void Update()
    {
        enemiesInScene = GameObject.FindGameObjectsWithTag("Enemy");

        if (GameObject.Find("Spaceship") && player.health <= 0)
        {
            GameObject.Find("Spaceship").SetActive(false);
            Time.timeScale = 0;
            gameOverCanvas.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.enabled)
        {
            TogglePauseMenu(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.enabled)
        {
            TogglePauseMenu(false);
        }

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void PowerupSpawn()
    {
        int choice = Random.Range(0, 2);
        if (choice == 0)
        {
            Instantiate(healthPowerup, new Vector2(Random.Range(-9, 9), transform.position.y), Quaternion.identity);
        }
        else
        {
            Instantiate(missilePowerup, new Vector2(Random.Range(-9, 9), transform.position.y), Quaternion.identity);
        }
    }

    public void TogglePauseMenu(bool state)
    {
        if (state)
        {
            Time.timeScale = 0;
            pauseMenu.enabled = true;
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.enabled = false;
        }
    }

}
