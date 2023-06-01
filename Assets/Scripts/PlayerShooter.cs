using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;

// �ſ� ���� �Ѿ��� �����ϴ°ɷ� �����ϸ� ������ ������� ���ŵǱ⿡ ��ü�� ����ϴ� ������ �߻��� �� ����
// ���� ������ �ٷ� �״� ����ĳ��Ʈ�� ����

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
