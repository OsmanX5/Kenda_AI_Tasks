using UnityEngine;

public class KShapeController : MonoBehaviour
{
    public LineRenderer line;
    public GameObject[] kPoints;

    void Start()
    {
        line.positionCount = kPoints.Length;
        UpdateLineRenderer();
    }

    void Update()
    {
        UpdateLineRenderer();
    }

    void UpdateLineRenderer()
    {
        for (int i = 0; i < kPoints.Length; i++)
        {
            line.SetPosition(i, kPoints[i].transform.position);
        }
    }
}