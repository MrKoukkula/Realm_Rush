using UnityEngine;

[ExecuteInEditMode] [SelectionBase]
public class EditorSnap : MonoBehaviour
{
    [Range(1f, 20f)] [SerializeField] float gridSize = 10f;
    TextMesh numberLocation;

    private void Start()
    {
        numberLocation = gameObject.GetComponentInChildren<TextMesh>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / 10f) * gridSize;
        snapPos.y = Mathf.RoundToInt(transform.position.y / 10f) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / 10f) * gridSize;

        transform.position = new Vector3(snapPos.x, snapPos.y, snapPos.z);

        string labelText = snapPos.x / gridSize + "," + snapPos.z / gridSize;
        numberLocation.text = labelText;
        gameObject.name = "Waypoint " + labelText;
    }
}
