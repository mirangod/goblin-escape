using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class Circle : MonoBehaviour
{
    public LineRenderer circleRenderer;
    private int resolution = 100;
    public float radius = 4f;

    private void Start()
    {
        DrawCircle();

        EdgeCollider2D edgeCollider = GetComponent<EdgeCollider2D>();

        // create a point matrix to define the circle's collider
        Vector2[] points = new Vector2[resolution];

        float angle = 0f;

        for (int i = 0; i < resolution; i++)
        {
            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);

            points[i] = new Vector2(x, y);

            angle += 2f * Mathf.PI / resolution;
        }

        // set the circle collider points
        edgeCollider.points = points;
    }

    // function that draws a circle with radius of size of variable
    // 'radius' and 'resolution' vertices
    private void DrawCircle()
    {
        circleRenderer.loop = true;
        circleRenderer.positionCount = resolution;

        float angle = 0f;

        for (int i = 0; i < resolution; i++)
        {
            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);

            circleRenderer.SetPosition(i, new Vector3(x, y, 0f));

            angle += 2f * Mathf.PI / resolution;
        }
    }
}
