using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance;

    [Header("Cursor Image")]
    [SerializeField] public Texture2D Idle;
    [SerializeField] public Texture2D PushToLeft;
    [SerializeField] public Texture2D PushToRight;
    [SerializeField] public Texture2D Pain;

    public ChirnoManager chirno;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Cursor.SetCursor(Idle, new Vector2(Idle.width/2, Idle.height / 2), CursorMode.ForceSoftware);
        UI_Mapper.Instance.SetFairyImage(FairyFace.Idle);
        if (ChirnoManager.Instance != null) chirno = ChirnoManager.Instance;
    }

    private void Update()
    {
        if (chirno == null)
        {
            Cursor.SetCursor(Idle, new Vector2(Idle.width / 2, Idle.height / 2), CursorMode.ForceSoftware);
            UI_Mapper.Instance.SetFairyImage(FairyFace.Idle);
            return;
        }

        if (GameManager.Instance.PushLeft <= 0)
        {
            UI_Mapper.Instance.SetFairyImage(FairyFace.Pain);
            Cursor.SetCursor(Pain, new Vector2(Idle.width / 2, Idle.height / 2), CursorMode.ForceSoftware);
            return;
        }

        RaycastHit hit;
        Vector3 camPosition = Camera.main.transform.localPosition;
        Vector3 mousez = Camera.main.WorldToScreenPoint(new Vector3(0, 0, Input.mousePosition.z));
        Vector3 origin = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mousez.z));

        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < chirno.transform.position.x)
        {
            UI_Mapper.Instance.SetFairyImage(FairyFace.PushToRight);
            Cursor.SetCursor(PushToRight, new Vector2(PushToRight.width, PushToRight.height / 2), CursorMode.ForceSoftware);

            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                chirno.PushChirno(false);
            }
        }
        else
        {
            UI_Mapper.Instance.SetFairyImage(FairyFace.PushToLeft);
            Cursor.SetCursor(PushToLeft, new Vector2(0, PushToLeft.height / 2), CursorMode.ForceSoftware);
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                chirno.PushChirno(true);
            }
        }

    //    var hit2D = Physics2D.Raycast(new Vector2(origin.x, origin.y), Vector2.up, 1f, LayerMask.GetMask("Player"));

    //    if (hit2D.collider)
    //    {
    //        if (hit2D.collider.CompareTag("Player"))
    //        {
    //            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < chirno.transform.position.x)
    //            {
    //                UI_Mapper.Instance.SetFairyImage(FairyFace.PushToRight);
    //                Cursor.SetCursor(PushToRight, new Vector2(PushToRight.width, PushToRight.height / 2), CursorMode.ForceSoftware);
                    
    //                if (Input.GetMouseButtonDown(0))
    //                {
    //                    chirno.PushChirno(false);
    //                }
    //            }
    //            else
    //            {
    //                UI_Mapper.Instance.SetFairyImage(FairyFace.PushToLeft);
    //                Cursor.SetCursor(PushToLeft, new Vector2(0, PushToLeft.height / 2), CursorMode.ForceSoftware);
    //                if (Input.GetMouseButtonDown(0))
    //                {
    //                    chirno.PushChirno(true);
    //                }
    //            }
    //        }
    //    }
    //    else
    //    {
    //        UI_Mapper.Instance.SetFairyImage(FairyFace.Idle);
    //        Cursor.SetCursor(Idle, new Vector2(Idle.width / 2, Idle.height / 2), CursorMode.ForceSoftware);
    //    }
    }


}
