using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class EditorSnap : MonoBehaviour
{
    
    TextMesh numberLocation;
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    private void Start()
    {
        numberLocation = gameObject.GetComponentInChildren<TextMesh>();
    }
    // Update is called once per frame
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        float gridSize = waypoint.GetGridSize;
        //print(waypoint.GetGridPos);

        transform.position = new Vector3(waypoint.GetGridPos.x, 0f, waypoint.GetGridPos.y);
    }

    private void UpdateLabel()
    {
        float gridSize = waypoint.GetGridSize;
        string labelText = waypoint.GetGridPos.x / gridSize + "," + waypoint.GetGridPos.y / gridSize;
        numberLocation.text = labelText;
        gameObject.name = "Waypoint " + labelText;
    }
}
