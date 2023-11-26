using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : BaseAction
{
    public event EventHandler OnStartMoving;
    public event EventHandler OnStopMoving;
    [SerializeField] private int maxMoveDistance = 4;

    private Vector3 targetPosition;

    protected override void Awake()
    {
        base.Awake();//run base awake 
        targetPosition = transform.position;
    }

    void Update()
    {
        if (!isActive)
        {
            return;
        }

        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        float stoppingDistance = .1f;
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            float moveSpeed = 4f;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
        else
        {
            OnStopMoving?.Invoke(this, EventArgs.Empty);

            ActionComplete();
        }

        float rotateSpeed = 10f;
        transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

    }

    public override void TakeAction(GridPosition gridPosition, Action onActionComplete)
    {
        ActionStart(onActionComplete);

        this.targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);

        OnStartMoving?.Invoke(this, EventArgs.Empty);

    }

    //return list of grid valid positions 
    public override List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validGridPosition = new List<GridPosition>();
        GridPosition unitGridPosition = unit.GetGridPosition();

        //cycle through potential unit positions
        for (int x = -maxMoveDistance; x <= maxMoveDistance; x++)
        {
            for (int z = -maxMoveDistance; z <= maxMoveDistance; z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x, z);
                GridPosition testGridPosition = unitGridPosition + offsetGridPosition;

                //if is in bounds
                if (!LevelGrid.Instance.IsValidGridPosition(testGridPosition))
                {
                    // if its not valid continuie to next iteration
                    //skips to the next iteration
                    continue;
                }

                //same grid position where unit is already--ignore it
                if (unitGridPosition == testGridPosition)
                {
                    continue;
                }

                //Grid position already occupied with another unit
                if (LevelGrid.Instance.HasAnyUnitOnGridPosition(testGridPosition))
                {
                    continue;
                }
                validGridPosition.Add(testGridPosition);
            }
        }
        return validGridPosition;
    }

    public override string GetActionName()
    {
        return "Move";
    }
}

