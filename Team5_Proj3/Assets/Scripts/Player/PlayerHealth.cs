using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerLives;



    public void damagePlayer()
    {
        playerLives -= 1;
        if(playerLives <= 0)
        {
            // CONNOR DEATH GOES HERE
            print("Player has died");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
