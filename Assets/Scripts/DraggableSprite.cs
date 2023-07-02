using UnityEngine;
using System.Collections;

public class DraggableSprite : MonoBehaviour
{
    private Vector3 startPosition;
    private bool isDragging;

    private void OnMouseDown()
    {
        isDragging = true;
        startPosition = transform.position;
    }

    private void OnMouseUp()
    {
        isDragging = false;
        StartCoroutine(ReturnToStartPosition());
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            transform.position = mousePosition;
        }
    }

    private IEnumerator ReturnToStartPosition()
    {
        float lerpTime = 0.2f; // Time to interpolate back to start position
        float currentLerpTime = 0f;

        while (currentLerpTime < lerpTime)
        {
            currentLerpTime += Time.deltaTime;
            float t = currentLerpTime / lerpTime;
            transform.position = Vector3.Lerp(transform.position, startPosition, t);
            yield return null;
        }

        transform.position = startPosition;
    }
}