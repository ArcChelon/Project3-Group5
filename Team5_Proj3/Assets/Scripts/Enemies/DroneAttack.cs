using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttack : MonoBehaviour
{
    [SerializeField] Transform positionToMove;
    [SerializeField] float moveSpeed;
    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitToMove());
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, positionToMove.position, Time.deltaTime * moveSpeed);
        }
        
    }
    private IEnumerator waitToMove()
    {
        yield return new WaitForSeconds(2);
        isMoving = true;
    }
}
