using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCue : MonoBehaviour
{
    public LineFactory lineFactory;
    public GameObject ballObject;

    private Line drawnLine;
    private Ball2D ball;


    private void Start()
    {
        ball = ballObject.GetComponent<Ball2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Start line drawing
            if (ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y))
            {
                //check if ball is there 
                //draws line
                drawnLine = lineFactory.GetLine(startLinePos, ball.transform.position, 5, Color.white);
                drawnLine.EnableDrawing(true);
            }
            Debug.Log("Line created successfully!");
        }
        else if (Input.GetMouseButtonUp(0) && drawnLine != null)
        {
            //this makes it so when clicked again the line will disapear
            drawnLine.EnableDrawing(false);


            //update the velocity of the white ball.
            //Basically moving the ball
            HVector2D v = new HVector2D(drawnLine.start.x - drawnLine.end.x, drawnLine.start.y - drawnLine.end.y);
            ball.Velocity = v;



            drawnLine = null; // End line drawing            
        }

        if (drawnLine != null)
        {
            drawnLine.end = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Update line end
        }
    }

    /// <summary>
    /// Get a list of active lines and deactivates them.
    /// </summary>
    public void Clear()
    {
        var activeLines = lineFactory.GetActive();

        foreach (var line in activeLines)
        {
            line.gameObject.SetActive(false);
        }
    }
}
