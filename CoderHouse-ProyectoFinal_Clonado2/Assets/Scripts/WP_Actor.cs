using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WP_Actor : MonoBehaviour
{
    float speed = 3f;
    [SerializeField] public Transform target;
    public NavMeshAgent agente;


    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        transform.LookAt(new Vector3(target.position.x, transform.position.y, transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WayPoint")
        {
            target = other.gameObject.GetComponent<WayPoint>().nextPoint;
            transform.LookAt(new Vector3(target.position.x,transform.position.y,transform.position.z));
        }
    }
}
