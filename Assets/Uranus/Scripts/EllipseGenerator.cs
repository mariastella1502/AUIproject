
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class EllipseGenerator : MonoBehaviour
{

    [SerializeField, Range(3, 500)] private int _ellipseSegments = 50;
    [SerializeField] private Vector2 xyScale = new Vector2(5f, 3f);
    [SerializeField] private Vector2 zScale = new Vector2(0f, 0f);
    [SerializeField] private bool _showEllipseLineRender = true;
    [SerializeField] private bool _showEllipseDebugLine = true;
    [SerializeField] private Color newColor;
    [SerializeField] private float width = 1f;
    private LineRenderer _lr;

    public Vector3[] _ellipsePoints = new Vector3[0]; //per far spostare le orbite scrivi un metodo di ricalcolo bstato sulla bositione del transoform
    public Vector3[] GetEllipsePoints { get { return _ellipsePoints; } }

    private void Awake()
    {
        _lr = GetComponent<LineRenderer>();
        CalculateEllipse();
    }

    private void CalculateEllipse()
    {
        _lr.startWidth = width;
        _lr.endWidth = width;

        //number of points equals numbers of segments
        _ellipsePoints = new Vector3[_ellipseSegments];

        for (int i = 0; i < _ellipseSegments; i++)
        {
            //Calculate angle by getting current segment % 0-1
            //Multiplied by 360 for degrees, then turned to radians
            float _angle = ((float)i / (float)_ellipseSegments) * 360 * Mathf.Deg2Rad;
            //Calculate the x using the Sine of angle multiplied by xScale
            float x = Mathf.Sin(_angle) * xyScale.x;
            //Calculate the y using the Cosine of angle multiplied by yScale
            float y = Mathf.Cos(_angle) * xyScale.y;
            float z = (Mathf.Sin(_angle) * zScale.x) + (Mathf.Cos(_angle) * zScale.y);
            //Update the array value
            _ellipsePoints[i] = new Vector3(x, y, z);
        }

        if (_showEllipseLineRender)
        {
            _lr.positionCount = _ellipseSegments;
            _lr.SetPositions(_ellipsePoints);
            _lr.startColor = newColor;
            _lr.endColor = newColor;
        }
        else
        {
            _lr.positionCount = 0;
        }
    }

    private void OnValidate()
    {
        if (_lr)
        {
            CalculateEllipse();
        }
    }

    private void OnDrawGizmos()
    {
        if (!_showEllipseDebugLine)
            return;

        _ellipsePoints = new Vector3[_ellipseSegments];
        for (int i = 0; i < _ellipseSegments; i++)
        {
            //Calculate angle by getting current segment % 0-1
            //Multiplied by 360 for degrees, then turned to radians
            float _angle = ((float)i / (float)_ellipseSegments) * 360 * Mathf.Deg2Rad;
            //Calculate the x using the Sine of angle multiplied by xScale
            float x = Mathf.Sin(_angle) * xyScale.x;
            //Calculate the y using the Cosine of angle multiplied by yScale
            float y = Mathf.Cos(_angle) * xyScale.y;
            float z = (Mathf.Sin(_angle) * zScale.x) + (Mathf.Cos(_angle) * zScale.y);
            //Update the array value
            _ellipsePoints[i] = new Vector3(x, y, z);
        }

        for (int i = 0; i < _ellipsePoints.Length - 1; i++)
            Gizmos.DrawLine(_ellipsePoints[i], _ellipsePoints[i + 1]);
        Gizmos.DrawLine(_ellipsePoints[_ellipsePoints.Length - 1], _ellipsePoints[0]);
    }

}
