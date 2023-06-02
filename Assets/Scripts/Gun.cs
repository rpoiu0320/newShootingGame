using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private ParticleSystem hitEffect;
    [SerializeField] private TrailRenderer bulletTrail;
    [SerializeField] private float maxDistance;
    [SerializeField] private float bulletSpeed;
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

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance))
        {
            IHittable hittable = hit.transform.GetComponent<IHittable>();
            ParticleSystem effect = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal)); // LookRotation�� ���͸� �־��ָ� �� �������� �ٶ󺸰� ����, hit.nomal�� �浹 �������� �浹ü�� �鿡 ��������
            effect.transform.parent = hit.transform;
            Destroy(effect.gameObject, 3f);

            StartCoroutine(TrailRoutine(muzzleEffect.transform.position, hit.point));

            hittable?.Hit(hit, damage);
        }
        else
        {
            StartCoroutine(TrailRoutine(muzzleEffect.transform.position, Camera.main.transform.forward * maxDistance));
        }
    }

    IEnumerator TrailRoutine(Vector3 startPoint, Vector3 endPoint)
    {
        TrailRenderer trail = Instantiate(bulletTrail, muzzleEffect.transform.position, Quaternion.identity);
        //                                 �����Ұ�,       ���� ��ġ,                      ȸ��(identity ȸ�� ����)
        float totalTime = Vector2.Distance(startPoint, endPoint) / bulletSpeed;
        float rate = 0;

        while (rate < 1)
        {
            trail.transform.position = Vector3.Lerp(startPoint, endPoint, rate); ;
            rate += Time.deltaTime / totalTime;

            yield return null;
        }
        Destroy(trail);
    }
}
