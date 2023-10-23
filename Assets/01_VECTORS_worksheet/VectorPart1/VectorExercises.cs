using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    int x;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX, maxY;

    private void Start()
    {
        CalculateGameDimensions();
        if (Q2a)
            Question2a();
        if (Q2b)
            Question2b(20);
        if (Q2d)
            Question2d();
        if (Q2e)
            Question2e(20);
        if (Q3a)
            Question3a();
        if (Q3b)
            Question3b();
        if (Q3c)
            Question3c();
        if (projection)
            Projection();
    }

    

    public void CalculateGameDimensions()
    {
        GameHeight = Camera.main.orthographicSize * 2f;
        GameWidth = Camera.main.aspect * GameHeight;

        maxX = GameWidth / 2;
        maxY = GameHeight / 2;
        minX = -maxX;
        minY = -maxY;
    }

    void Question2a()
    {
        //the location of the start of the vector
        startPt = new Vector2(-5, 0);
        //the location of the end of the vector
        endPt = new Vector2(2, 3);

        //This is the parameter of the drawing of the line
        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);
        drawnLine.EnableDrawing(true);

        //caculates magnitude
        Vector2 vec2 = endPt - startPt;
        Debug.Log("Magnitude = " + vec2.magnitude);
    }

    void Question2b(int n)
    {
        for (int i = 0; i < n; i++)
        {
            startPt = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            endPt = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

            drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);
            drawnLine.EnableDrawing(true);

            Vector2 vec2 = endPt - startPt;
            Debug.Log("Magnitude = " + vec2.magnitude);
        }
    }

    void Question2d()
    {
        DebugExtension.DebugArrow(
            new Vector3(0, 0, 0),
            new Vector3(5, 5, 0),
            Color.red,
            60f);
    }

    void Question2e(int n)
    {
        for (int i = 0; i < n; i++)
        {
            DebugExtension.DebugArrow(
                new Vector3(0,0,0),
                new Vector3(Random.Range(minX, maxX),
                Random.Range(minY, maxY),
                Random.Range(minY, maxY)),
                Color.white,
                60f);
        }  
    }

    public void Question3a()
    {
        
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);
        HVector2D c = a - b;
        //HVector2D c = a + b;

        //DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        //DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f);
        //DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.green, 60f);

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), - b.ToUnityVector3(), Color.green, 60f);


        float MagofA = a.Magnitude();
        Debug.Log("Magnitude of a = " + MagofA.ToString("F2"));
        float MagofB = b.Magnitude();
        Debug.Log("Magnitude of b = " + MagofB.ToString("F2"));
        float MagofC = c.Magnitude();
        Debug.Log("Magnitude of c = " + MagofC.ToString("F2"));

    }

    public void Question3b()
    {
        int x = 3;
        int y = 5;
        HVector2D a = new HVector2D(x, y);
        HVector2D b = a*2;


        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(new Vector3(1, 0, 0), b.ToUnityVector3(), Color.green, 60f);
    }

    public void Question3c()
    {
        HVector2D a = new HVector2D(3, 5);

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        a.Normalize();
        DebugExtension.DebugArrow(new Vector3(1, 0, 0), a.ToUnityVector3(), Color.green, 60f);
    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        //HVector2D v1 = b - a;
        // Your code here

        //HVector2D proj = // Your code here

        //DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
