using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject lightEnemy;
    public GameObject heavyEnemy;
    public GameObject boss;
    private int bossCount = 1;

    private Vector3 hatFormation;
    private Vector3 vFormation;
    private Vector3 straightFormation;

    public float[] hatForm;
    public float[] vForm;

    private GameController gameController;
    private GameObject[] spawnedObjects;
    private int chosenFormation;
    private bool formChosen;
    private float[] spawnDestination;

    public Canvas bossHealthCanvas;

    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        formChosen = false;
        chosenFormation = Random.Range(0, 3);
        spawnedObjects = new GameObject[5];

        //If random chooses 0 then apply hat formation to the enemy
        if (chosenFormation == 0)
        {
            
            for (int i = 0; i < spawnedObjects.Length; i++)
            {
                spawnedObjects[i] = Instantiate(lightEnemy, new Vector3(-4 + (2 * i), transform.position.y, 0), Quaternion.identity);
                spawnDestination = hatForm;
            }
        }
        //If random chooses 1 then apply v formation to the enemy
        if (chosenFormation == 1)
        {

            for (int i = 0; i < spawnedObjects.Length; i++)
            {
                spawnedObjects[i] = Instantiate(lightEnemy, new Vector3(-4 + (2 * i), transform.position.y, 0), Quaternion.identity);
                spawnDestination = vForm;
            }
        }
        //If random chooses 2 then apply straight line formation to the enemy
        if (chosenFormation == 2)
        {

            for (int i = 0; i < spawnedObjects.Length; i++)
            {
                spawnedObjects[i] = Instantiate(lightEnemy, new Vector3(-4 + (2 * i), transform.position.y, 0), Quaternion.identity);
                spawnDestination = new float[5];
                spawnDestination[0] = 6.45f;
                spawnDestination[1] = 6.45f;
                spawnDestination[2] = 6.45f;
                spawnDestination[3] = 6.45f;
                spawnDestination[4] = 6.45f;
            }
        }

    }

    private void Update()
    {
        if (gameController.enemiesInScene != null && gameController.enemiesInScene.Length != 0)
        {
            formChosen = false;
            for (int i = 0; i < spawnedObjects.Length; i++)
            {
                if (spawnedObjects[i] != null && spawnedObjects[i].transform.position.y != spawnDestination[i])
                {
                    spawnedObjects[i].transform.position = Vector2.MoveTowards(spawnedObjects[i].transform.position, new Vector2(spawnedObjects[i].transform.position.x, spawnDestination[i]), 15 * Time.deltaTime);
                }
            }
        }

        if (gameController.enemiesInScene != null && gameController.enemiesInScene.Length == 0 && !formChosen)
        {
            if (gameController.lightEnemyCount >= 5)
            {
                gameController.lightEnemyCount -= 5;
            }
            else
            {
                gameController.heavyEnemyCount -= 5;
            }
            RespawnEnemies();
            formChosen = true;
        }

        
        if (gameController.enemiesInScene != null && gameController.lightEnemyCount <= 0 && gameController.heavyEnemyCount <= 0 && gameController.enemiesInScene.Length == 0 && bossCount == 1)
        {
            Instantiate(boss, transform.position, Quaternion.identity);
            bossHealthCanvas.enabled = true;
            bossCount--;
        }

    }

    private void RespawnEnemies()
    {
        if (gameController.lightEnemyCount >= 5)
        {
            chosenFormation = Random.Range(0, 2);
            spawnedObjects = new GameObject[5];

            //If random chooses 0 then apply hat formation to the enemy
            if (chosenFormation == 0)
            {

                for (int i = 0; i < spawnedObjects.Length; i++)
                {
                    spawnedObjects[i] = Instantiate(lightEnemy, new Vector3(-4 + (2 * i), transform.position.y, 0), Quaternion.identity);
                    spawnDestination = hatForm;
                }
            }
            //If random chooses 1 then apply v formation to the enemy
            if (chosenFormation == 1)
            {

                for (int i = 0; i < spawnedObjects.Length; i++)
                {
                    spawnedObjects[i] = Instantiate(lightEnemy, new Vector3(-4 + (2 * i), transform.position.y, 0), Quaternion.identity);
                    spawnDestination = vForm;
                }
            }
            //If random chooses 2 then apply straight line formation to the enemy
            if (chosenFormation == 2)
            {

                for (int i = 0; i < spawnedObjects.Length; i++)
                {
                    spawnedObjects[i] = Instantiate(lightEnemy, new Vector3(-4 + (2 * i), transform.position.y, 0), Quaternion.identity);
                    spawnDestination = new float[5];
                    spawnDestination[0] = 6.45f;
                    spawnDestination[1] = 6.45f;
                    spawnDestination[2] = 6.45f;
                    spawnDestination[3] = 6.45f;
                    spawnDestination[4] = 6.45f;
                }
            }
        }

        if (gameController.lightEnemyCount == 0 && gameController.heavyEnemyCount >= 5)
        {
            chosenFormation = Random.Range(0, 3);
            spawnedObjects = new GameObject[5];

            //If random chooses 0 then apply hat formation to the enemy
            if (chosenFormation == 0)
            {

                for (int i = 0; i < spawnedObjects.Length; i++)
                {
                    spawnedObjects[i] = Instantiate(heavyEnemy, new Vector3(-4 + (2 * i), transform.position.y, 0), Quaternion.identity);
                    spawnDestination = hatForm;
                }
            }
            //If random chooses 1 then apply v formation to the enemy
            if (chosenFormation == 1)
            {

                for (int i = 0; i < spawnedObjects.Length; i++)
                {
                    spawnedObjects[i] = Instantiate(heavyEnemy, new Vector3(-4 + (2 * i), transform.position.y, 0), Quaternion.identity);
                    spawnDestination = vForm;
                }
            }
            //If random chooses 2 then apply straight line formation to the enemy
            if (chosenFormation == 2)
            {

                for (int i = 0; i < spawnedObjects.Length; i++)
                {
                    spawnedObjects[i] = Instantiate(heavyEnemy, new Vector3(-4 + (2 * i), transform.position.y, 0), Quaternion.identity);

                    spawnDestination = new float[5];
                    spawnDestination[0] = 6.45f;
                    spawnDestination[1] = 6.45f;
                    spawnDestination[2] = 6.45f;
                    spawnDestination[3] = 6.45f;
                    spawnDestination[4] = 6.45f;
                }
            }
        }
    }

    public GameObject[] SpawnMinions()
    {
        // Instantitating 2 light enemies and 2 heavy enemnies
        var m1 = Instantiate(lightEnemy, transform.position, Quaternion.identity);
        var m2 = Instantiate(lightEnemy, transform.position, Quaternion.identity);
        var m3 = Instantiate(heavyEnemy, transform.position, Quaternion.identity);
        var m4 = Instantiate(heavyEnemy, transform.position, Quaternion.identity);

        GameObject[] minions = new GameObject[4];
        minions[0] = m1;
        minions[1] = m2;
        minions[2] = m3;
        minions[3] = m4;

        return minions;
    }

}
