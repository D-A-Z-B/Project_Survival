using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : RangedWeapon
{
    public override void Shoot()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 10);
        Vector2 endPoint = hit.collider != null ? hit.point : (Vector2)transform.position + direction * 10;
        Bullet bullet = PoolManager.Instance.Pop(ObjectPooling.PoolingType.Bullet) as Bullet;
        bullet.DrawTrail(transform.position, endPoint, 0.02f);
    }
}
