using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkbenchControl : MonoBehaviour
{
    [Header("Drawing")]
    public static bool isDrawing;
    public GameObject pencil;
    public GameObject drawFinishText;
    public BoxCollider boxC;
    public bool isDrawingComplete;
    public float _completionThreshold;
    public float _completionPercentage;
    float _drawnArea;
    bool isPress;
    List<GameObject> pencils = new List<GameObject>(0);

    void Start()
    {
        isDrawing = false;
        isDrawingComplete = false;
    }

    void Update()
    {
        if (isDrawing)
        {
            Drawing();
        }
    }

    void Drawing()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5f);

        if (Input.GetMouseButtonDown(0))
        {
            isPress = true;
            pencils.Add(Instantiate(pencil, Camera.main.ScreenToWorldPoint(mousePos), Quaternion.Euler(Vector3.zero), this.transform));
        }
        if (Input.GetMouseButtonUp(0))
        {
            isPress = false;
        }

        if (!isDrawingComplete && isPress)
        {
            if (Drawing_isWithInBoundary(Camera.main.ScreenToWorldPoint(mousePos)))
            {
                pencils[pencils.Count - 1].transform.position = Camera.main.ScreenToWorldPoint(mousePos);
                _drawnArea += _completionPercentage * Time.deltaTime;
                print(_drawnArea);
            }
        }

        Drawing_CheckDrawingCompletion();
    }
    void Drawing_CheckDrawingCompletion()
    {
        if (!isDrawingComplete)
        {
            if (_drawnArea >= _completionThreshold)
            {
                BedControl.isNight = true;           //•º•rµÄ
                drawFinishText.SetActive(true);
                isDrawingComplete = true;
                Invoke("Drawing_ClearAllPencils", 2f);
            }
        }
    }
    void Drawing_ClearAllPencils()
    {
        for (int i = 0; i < pencils.Count; i++)
        {
            Destroy(pencils[i]);
        }
        pencils.Clear();
        UIController.isFinish = true;
        drawFinishText.SetActive(false);
    }

    bool Drawing_isWithInBoundary(Vector3 pos)
    {
        Bounds _bounds = boxC.bounds;

        return _bounds.Contains(pos);
    }

    

    
}
