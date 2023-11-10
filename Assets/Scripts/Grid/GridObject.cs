using UnityEngine;

public class GridObject
{
    private GridSystem gridSystem;
    private GridPosition gridPosition;
    private Unit unit;

    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
    }

    public override string ToString()
    {
        return gridPosition.ToString() + "\n" + unit;
    }

    //set unit
    public void SetUnit(Unit unit)
    {
        this.unit = unit;
    }

    //get unit
    public Unit GetUnit()
    {
        return unit;
    }
}