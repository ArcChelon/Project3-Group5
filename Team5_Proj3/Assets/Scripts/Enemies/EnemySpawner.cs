using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    private bool spawnAble = true;
    [SerializeField] Transform shooter;
    [SerializeField] Transform runner;
    [SerializeField] Transform drone;
    [SerializeField] float coolDownTime;
    private string currentScene;
    
    [SerializeField] Transform targetPosition;
    private Vector3 currentPosition;
    private Quaternion rotation;


    [Header("Enemy Weights")] 
    [SerializeField] int shooterWeight;
    [SerializeField] int runnerWeight;
    [SerializeField] int droneWeight;
    [Header("Enemies to spawn")]
    [SerializeField] int spawnCount;

    private void Start()
    {

        rotation = targetPosition.rotation;
        currentScene = SceneManager.GetActiveScene().name;
    }
    private IEnumerator coolDownSpawn()
    {
        
        yield return new WaitForSeconds(coolDownTime);
        
        spawnAble = true;
    }

    private void Update()
    {
        currentPosition = new Vector3(targetPosition.position.x, targetPosition.position.y, targetPosition.position.z);
        if (spawnAble)
        {
            
            int decree = Random.Range(0, 2);
            if (decree == 1)
            {
                
                //int enemies = Random.Range(1, 3);
                SpawnEnemy(spawnCount);
                spawnAble = false;
                StartCoroutine(coolDownSpawn());
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        print("Triggered");
        if (other.CompareTag("EndZone"))
        {
            this.gameObject.SetActive(false);
        }
        if (other.CompareTag("MiddleZone"))
        {
            this.gameObject.SetActive(false);
        }
    }





    private void SpawnEnemy(int enemies)
    {
        float[] positions = new float[3];
        positions[0] = 3;
        positions[1] = 0;
        positions[2] = -3;
        float previous1 = 5;
        float previous2 = 5;
        if (enemies == 2)
        {

            for (int i = 0; i < enemies; i++)
            {
                int chosen = Random.Range(0, 3);


                if (chosen == (int)previous1)
                {

                    while (chosen == (int)previous1)
                    {
                        chosen = Random.Range(0, 3);
                    }
                }

                previous1 = chosen;
                Transform enemie = SelectEnemy();
                Vector3 intPosition = new Vector3(currentPosition.x, currentPosition.y, positions[chosen]);
                Transform unit = Instantiate(enemie, intPosition, rotation);


            }
        }

        else if (enemies == 3)
        {
            for (int i = 0; i < enemies; i++)
            {
                int chosen = Random.Range(0, 3);


                if (chosen == (int)previous1 || chosen == (int)previous2)
                {

                    while (chosen == (int)previous1 || chosen == (int)previous2)
                    {
                        chosen = Random.Range(0, 3);
                    }
                }

                
                Transform enemie = SelectEnemy();
                Vector3 intPosition = new Vector3(currentPosition.x, currentPosition.y, positions[chosen]);
                Transform unit = Instantiate(enemie, intPosition, rotation);
                if(i == 0)
                {
                    previous1 = chosen;
                }
                else if(i == 1)
                {
                    previous2 = chosen;
                }
            }




        }
        
        
    }
    private Transform SelectEnemy()
    {
        
        int shooterChance = Random.Range(1, 100) + shooterWeight;
        int runnerChance = Random.Range(1, 100) + runnerWeight;
        int droneChance = Random.Range(1, 100) + droneWeight;
        if (shooterChance > runnerChance && shooterChance > droneChance)
        {
            Transform chosen = shooter;
            return chosen;
        }
        else if (runnerChance > shooterChance && runnerChance > droneChance)
        {
            Transform chosen = runner;
            return chosen;
        }
        else if (droneChance > shooterChance && droneChance > runnerChance)
        {
            Transform chosen;
            if (currentScene == "Level_2")
            {
                 chosen = drone;
            }
            else
            {
                 chosen = shooter;
            }
            
            return chosen;
        }
        else
        {
            Transform chosen = drone;
            return chosen;
        }


    }
}
