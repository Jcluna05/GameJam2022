using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public float distance;
    public float angle;

    public LayerMask targetLayers;
    public LayerMask obstacLeslayer;
    public Collider detectedTarget;
    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distance, targetLayers);
        detectedTarget = null;
        foreach (Collider collider in colliders)
        {
            Vector3 directionToCollider = Vector3.Normalize(collider.bounds.center - transform.position);
            float angleToCollider = Vector3.Angle(transform.forward, directionToCollider);

            //comparar angulos de vision y angulos de deteccion

            if (angleToCollider < angle)
            {
                // objeto dentro del angulo de visión
                // detectar si hay algun obstaculo entre el objetivo y el enemigo
                if (!Physics.Linecast(transform.position, collider.bounds.center, out RaycastHit hit, obstacLeslayer))
                {
                    Debug.DrawLine(transform.position, collider.bounds.center, Color.green);
                    //guardamis ka referencia del objetivo detectado
                    detectedTarget = collider;
                    break;
                }
                else
                {
                    Debug.DrawLine(transform.position, hit.point, Color.blue);
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);

        Gizmos.color = Color.magenta;
        Vector3 rightDir = Quaternion.Euler(0, angle, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, rightDir * distance);
        Vector3 leftDir = Quaternion.Euler(0, -angle, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, leftDir * distance);
    }
}
