using UnityEngine;
using TMPro;

public class GridDebugObject : MonoBehaviour
{

    [SerializeField] private TextMeshPro textMeshPro;
    private GridObject gridObject;

    public void SetGridObject(GridObject gridObject)
    {
        this.gridObject = gridObject;
    }
    void Update()
    {

        textMeshPro.text = gridObject.ToString();

    }
}
