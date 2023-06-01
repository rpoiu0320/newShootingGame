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
            ParticleSystem effect = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal)); // LookRotation�� ���͸� �־��ָ� �� �������� �ٶ󺸰� ����, hit.nomal�� �浹 �������� �浹ü�� �鿡 ��������
            effect.transform.parent = hit.transform;
            Destroy(effect.gameObject, 3f);

            TrailRenderer trail = Instantiate(bulletTrail, muzzleEffect.transform.position, Quaternion.identity);
            //                                  �����Ұ�,       ���� ��ġ,                      ȸ��(identity ȸ�� ����)

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
