using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolableMono
{
    private TrailRenderer trailRenderer;

    private void Awake() {
        trailRenderer = GetComponent<TrailRenderer>();
    }

    public override void ResetItem()
    {
        trailRenderer.Clear();
    }

    public void DrawTrail(Vector3 start, Vector3 end, float lifetime) {
        trailRenderer.AddPosition(start);
        transform.position = end;
        trailRenderer.time = lifetime;
        StartCoroutine(LifeTimeCoroutine(lifetime));
    }

    private IEnumerator LifeTimeCoroutine(float lifetime) {
        yield return new WaitForSeconds(lifetime);
        PoolManager.Instance.Push(this);
    }
}
