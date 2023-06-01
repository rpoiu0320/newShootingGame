using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private ParticleSystem hitEffect;
    [SerializeField] private TrailRenderer bulletTrail;
    [SerializeField] private float maxDistance;
    [SerializeField] private int damage;

    private ParticleSystem muzzleEffect;

    private void Awake()
    {
        muzzleEffect = GetComponentInChildren<ParticleSystem>();
    }

    public /*virtual*/ void Fire()
    {
        muzzleEffect.Play();

        RaycastHit hit;
        Debug.Log("hit");
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance))
        {
            IHittable hittable = hit.transform.GetComponent<IHittable>();
            ParticleSystem effect = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal)); // LookRotation은 벡터를 넣어주면 그 방향으로 바라보게 해줌, hit.nomal은 충돌 지점에서 충돌체의 면에 수직으로
            effect.transform.parent = hit.transform;
            Destroy(effect.gameObject, 3f);

            TrailRenderer trail = Instantiate(bulletTrail, muzzleEffect.transform.position, Quaternion.identity);
            //                                  생성할거,       시작 위치,                      회전(identity 회전 없이)

            hittable?.Hit(hit, damage);
        }
    }

    IEnumerator TrailRoutine(Vector3 startPoint, Vector3 endPoint)
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance))
        {
            TrailRenderer trail = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal), true);
            IHittable hittable = hit.transform.GetComponent<IHittable>();
            hittable?.Hit(hit, damage);
        }
        else
        {
            TrailRenderer trail = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal), true);
        }
        

        float rate = Vector2.Distance(startPoint, endPoint) / maxDistance;

        float time = 0;
        while (time < 1)
        {
            //TrailRenderer.
        }
    }
}
