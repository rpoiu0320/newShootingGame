using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private ParticleSystem bulletEffect;
    [SerializeField] float maxDistance;
    [SerializeField] int damage;

    private TrailRenderer muzzleEffect;

    private void Awake()
    {
        muzzleEffect = GetComponentInChildren<TrailRenderer>();
    }

    public /*virtual*/ void Fire()
    {
        Debug.Log("รั น฿ป็");
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance))
        {
            
            Instantiate(muzzleEffect, hit.transform.position, Quaternion.LookRotation(hit.normal));
            IHittable hittable = hit.transform.GetComponent<IHittable>();
            hittable?.Hit(hit, damage);
        }
    }

    /*IEnumerator TrailRoutine(Vector3 startPoint, Vector3 endPoint)
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance))
        {
            TrailRenderer trail = Instantiate(bulletEffect, hit.point, Quaternion.LookRotation(hit.normal), true);
            IHittable hittable = hit.transform.GetComponent<IHittable>();
            hittable?.Hit(hit, damage);
        }
        else
        {
            TrailRenderer trail = Instantiate(bulletEffect, hit.point, Quaternion.LookRotation(hit.normal), true);
        }
        

        float rate = Vector2.Distance(startPoint, endPoint) / maxDistance;

        float time = 0;
        while (time < 1)
        {
            TrailRenderer.
        }
    }*/
}
