using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private bool spawnAble = true;
    [SerializeField] Transform shooter;
    [SerializeField] Transform runner;
    [SerializeField] float coolDownTime;
    
    [SerializeField] Transform targetPosition;
    private Vector3 currentPosition;
    private Quaternion rotation;

    private void Start()
    {

        rotation = targetPosition.rotation;
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
                SpawnEnemy(2);
                spawnAble = false;
                StartCoroutine(coolDownSpawn());
            }
        }
    }

    private void SpawnEnemy(int enemies)
    {
        int[] positions = new int[enemies];
       if(enemies > 1)
        {
            int position1 = Random.Range(1, 4);
            int position2 = Random.Range(1, 4);
            if (position1 == position2)
            {
                if(position1 == 1)
                {
                    position1 += 1;
                }
                else
                {
                    position1 -= 1;
                }
            }
            positions[0] = position1;
            positions[1] = position2;
            
            for(int i = 0; i < positions.Length; i++)
            {
                
                if(positions[i] == 1)
                {
                    Transform enemie;
                    int enemyPicked = Random.Range(1, 3);
                    if(enemyPicked == 1)
                    {
                        enemie = shooter;
                        Vector3 intPosition = new Vector3(currentPosition.x, currentPosition.y, 0);
                        Transform unit = Instantiate(enemie, intPosition, rotation);
                    }
                    else
                    {
                        enemie = runner;
                        Vector3 intPosition = new Vector3(currentPosition.x, currentPosition.y, 0);
                        Transform unit = Instantiate(enemie, intPosition, rotation);
                    }
                    
                }
                else if (positions[i] == 2)
                {
                    Transform enemie;
                    int enemyPicked = Random.Range(1, 3);
                    if (enemyPicked == 1)
                    {
                        enemie = shooter;
                        Vector3 intPosition = new Vector3(currentPosition.x, currentPosition.y, 3);
                        Transform unit = Instantiate(enemie, intPosition, rotation);
                    }
                    else
                    {
                        enemie = runner;
                        Vector3 intPosition = new Vector3(currentPosition.x, currentPosition.y, 3);
                        Transform unit = Instantiate(enemie, intPosition, rotation);
                    }
                }
                else if (positions[i] == 3)
                {
                    Transform enemie;
                    int enemyPicked = Random.Range(1, 3);
                    if (enemyPicked == 1)
                    {
                        enemie = shooter;
                        Vector3 intPosition = new Vector3(currentPosition.x, currentPosition.y, -3);
                        Transform unit = Instantiate(enemie, intPosition, rotation);
                    }
                    else
                    {
                        enemie = runner;
                        Vector3 intPosition = new Vector3(currentPosition.x, currentPosition.y, -3);
                        Transform unit = Instantiate(enemie, intPosition, rotation);
                    }
                }
            }
            



        }
        
        
    }
}
