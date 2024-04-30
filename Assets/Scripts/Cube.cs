using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private WaitForSeconds _destroyDelay;
    private bool _colorChanged = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (_colorChanged)
            return;
        if (collision.gameObject.GetComponent<Ground>())
            SetRandomColor();
            _colorChanged = true;
    }

    public void Init(int lifeTime)
    {
        _destroyDelay = new WaitForSeconds(lifeTime);

        StartCoroutine(DeferredDestroy());
    }

    public IEnumerator DeferredDestroy()
    {
        yield return _destroyDelay;
        Destroy(gameObject);
    }

    private void SetRandomColor()
    {
        Renderer cubeRenderer = GetComponent<Renderer>();

        Color randomColor = new Color
            (
            Random.value,
            Random.value,
            Random.value,
            Random.value
            );

        cubeRenderer.material.color = randomColor;
    }
}