using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class View : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] private float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        direction = direction.normalized;
        // ou
        //direction = Vector3.Normalize(direction);
        RaycastHit[] hits;
        Debug.DrawRay(transform.position, direction * distance, Color.red, 3f);
        hits = Physics.RaycastAll(transform.position,direction, distance);
        foreach (RaycastHit hit in hits){
            if(hit.collider.transform == target){
                transform.position += direction * 10 * Time.deltaTime;
            }
        }
        // Debug.DrawRay(transform.position, direction * distance, Color.red, 3f);
        // hits = Physics.SphereCast(transform.position,1f, direction, distance); <== sphere
        // foreach (RaycastHit hit in hits){
        //     if(hit.collider.transform == target){
        //         transform.position += direction * 10 * Time.deltaTime;
        //     }
        // }

    }
}
