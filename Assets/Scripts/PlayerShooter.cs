using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;

// 매우 빠른 총알을 생성하는걸로 구현하면 프레임 기반으로 갱신되기에 물체를 통과하는 현상이 발생할 수 있음
// 따라서 맞으면 바로 죽는 레이캐스트로 구현

public class PlayerShooter : MonoBehaviour
{
    private Animator animator;
    private bool isReloading;
    private WeaponHolder weaponHolder;

    [SerializeField] Rig aimRig;
    [SerializeField] float reloadTime;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        weaponHolder = GetComponentInChildren<WeaponHolder>();
    }

    private void OnReload(InputValue value)
    {
        if (isReloading)
            return;

        StartCoroutine(ReloadRoutine());

    }

    IEnumerator ReloadRoutine()
    {
        animator.SetTrigger("Reload");
        isReloading = true;
        aimRig.weight = 0f;
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
        aimRig.weight = 1f;
    }

    public void Fire()
    {
        weaponHolder.Fire();
        animator.SetTrigger("Fire");
    }

    private void OnFire(InputValue value)
    {
        if (isReloading)
            return;

        Fire();
    }
}
