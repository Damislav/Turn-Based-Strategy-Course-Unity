using System;
using System.Collections.Generic;
using UnityEngine;

//abstract does not let us make instance of this class
public abstract class BaseAction : MonoBehaviour
{
    //classes that inherit this can access protected
    protected Unit unit;
    protected bool isActive;

    protected Action onActionComplete;

    protected virtual void Awake()
    {
        unit = GetComponent<Unit>();
    }
    public abstract string GetActionName();

    public abstract void TakeAction(GridPosition gridPosition, Action onActionComplete);

    public virtual bool IsValidActionPosition(GridPosition gridPosition)
    {
        List<GridPosition> validGridPositionList = GetValidActionGridPositionList();
        return validGridPositionList.Contains(gridPosition);

    }
    public abstract List<GridPosition> GetValidActionGridPositionList();
}