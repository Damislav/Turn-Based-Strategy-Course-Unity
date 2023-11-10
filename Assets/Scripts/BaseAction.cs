using UnityEngine;

public class BaseAction : MonoBehaviour
{
    protected Unit unit;
    protected bool isActive;

    void Awake()
    {
        unit = GetComponent<Unit>();
    }

}
