using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkbenchControl : MonoBehaviour
{
    [Header("Musia")]
    public AudioClip complete;
    public AudioClip draw;
    public AudioSource BGM;

    [Header("StoryBook")]
    public GameObject storyBook;

    [Header("Drawing")]
    public GameObject pencil;
    public GameObject drawFinishText;
    public GameObject makeMaterial;
    public Sprite finishMakeMaterial;
    public BoxCollider boxC;
    List<GameObject> pencils = new List<GameObject>(0);

    public static bool isDrawing;
    public bool isDrawingComplete;
    public float _completionThreshold;
    public float _completionPercentage;
    float _drawnArea;
    bool isPress;

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

        storyBook.SetActive(CameraController.isLookWorkbench);
        makeMaterial.SetActive(CameraController.isLookMake);
    }

    void Drawing()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2.5f);

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
            SoundControl.isDraw = true;
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
                BGM.PlayOneShot(complete);
                SoundControl.isDraw = false;
                BedControl.isNight = true;           //•º•rµÄ
                drawFinishText.SetActive(true);
                isDrawingComplete = true;
                makeMaterial.GetComponent<SpriteRenderer>().sprite = finishMakeMaterial;
                if (GameControl._day == 2)
                {
                    UIController.isContentActive = true;
                    TextControl.textCount = 7;
                    GameControl.isFinishSweaterContent = true;
                    TaskController._taskNumber = 6;
                }
                Invoke("Drawing_ClearAllPencils", 1f);
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
        CameraController.isLookWorkbench = true;
        CameraController.isLookMake = false;
    }

    bool Drawing_isWithInBoundary(Vector3 pos)
    {
        Bounds _bounds = boxC.bounds;

        return _bounds.Contains(pos);
    }
}
