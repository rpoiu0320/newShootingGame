using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] float maxDistance;
    [SerializeField] int damage;

    public /*virtual*/ void Fire()
    {
        Debug.Log("รั น฿ป็");
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance))
        {
            IHittable hittable = hit.transform.GetComponent<IHittable>();
            hittable?.Hit(hit, damage);
        }
    }
}
