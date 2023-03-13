using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaycast : MonoBehaviour
{

    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerToCollide;
    [SerializeField] private EnemyBehaviour enemy;
    [SerializeField] private Transform enemyTransform;
    [SerializeField] private Transform playerTransform;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();


    }

    public void Raycast()
    {
        RaycastHit hit;
        Ray ray;

        dir = playerTransform.position - enemyTransform.position;

        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layerToCollide))
        {
            if (hit.transform.tag == "Player" || Vector3.Angle(enemy.transform.forward, dir) <= 90)
            {
                enemy.comportamiento = 2;
            }
            
        }


        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layerToCollide))
        {
            if (hit.transform.tag != "Player")
            {
                enemy.Dejar_De_Seguir_Player();
            }

        }

    }
}
