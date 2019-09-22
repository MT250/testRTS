using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = 1f;

    private new Camera camera;
    private GameManager gameManager;
    private void Start()
    {
        camera = GetComponent<Camera>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        MoveCamera();
        MouseClick();
        KeyboardControl();
        Zoom();
    }

    private void KeyboardControl()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameManager.selectedUnit != null) gameManager.ResetUnitSelection();
        }
    }

    private void Zoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            camera.fieldOfView += -Input.GetAxis("Mouse ScrollWheel") * 10;
            if (camera.fieldOfView >= 60) camera.fieldOfView = 60;
            if (camera.fieldOfView <= 20) camera.fieldOfView = 20;
        }
    }

    private void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                if (hit.transform.GetComponent<Unit>() != null)
                {
                    gameManager.selectedUnit = hit.transform.GetComponent<Unit>();
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (gameManager.selectedUnit != null)
            {
                Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hitPosition, Mathf.Infinity);
                if (hitPosition.transform.GetComponent<Interactable>()) { gameManager.selectedUnit.SetFocus(hitPosition.transform.gameObject); }
                else gameManager.selectedUnit.MoveTo(hitPosition.point);
            }
        }

    }

    void MoveCamera()
    {
        //TODO: 'switch' better?
        if (Input.GetKey(KeyCode.W)) { transform.Translate(new Vector3(0, 0, scrollSpeed), Space.World); }
        if (Input.GetKey(KeyCode.A)) { transform.Translate(new Vector3(-scrollSpeed, 0, 0), Space.World); }
        if (Input.GetKey(KeyCode.S)) { transform.Translate(new Vector3(0, 0, -scrollSpeed), Space.World); }
        if (Input.GetKey(KeyCode.D)) { transform.Translate(new Vector3(scrollSpeed, 0, 0), Space.World); }
    }
}
