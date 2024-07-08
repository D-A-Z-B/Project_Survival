using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : RangedWeapon
{
    [SerializeField] private LayerMask hitLayer;
    [SerializeField] private float amplitude, frequency;

    public override void Shoot()
    {
        Vector2 playerPos = PlayerManager.Instance.Player.transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - playerPos).normalized;
        RaycastHit2D hit = Physics2D.Raycast(playerPos, direction, 7, hitLayer);
        Vector2 endPoint = hit.collider != null ? hit.point : (Vector2)transform.position + direction * 7;
        Bullet bullet = PoolManager.Instance.Pop(ObjectPooling.PoolingType.Bullet) as Bullet;
        LastShootTime = Time.time;
        CameraManager.Instance.Shake(amplitude, frequency, 0.05f);
        bullet.DrawTrail(transform.position, endPoint, 0.01f);
    }
}
