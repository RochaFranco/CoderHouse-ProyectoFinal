using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Transform target;
    public float comportamiento;
    private NavMeshAgent agente;
    [SerializeField] private WP_Actor wpa;
    [SerializeField] private float distance = 10f;
    private float distance_Player;



    void Start()
    {
        anim = GetComponent<Animator>();
        agente = GetComponent<NavMeshAgent>();
        comportamiento = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        distance_Player = Vector3.Distance(transform.position, target.position);
        Comportamiento_Del_Enemigo();
        
    }

    public void Comportamiento_Del_Enemigo()
    {
        switch (comportamiento)
        {
            case 1:
                agente.destination = wpa.target.position;
                break;
            case 2:
                agente.destination = target.position;
                break;
        }
    }

    public void Dejar_De_Seguir_Player()
    {
        if (distance < distance_Player)
        {
            comportamiento = 1;
        }
    }

}
