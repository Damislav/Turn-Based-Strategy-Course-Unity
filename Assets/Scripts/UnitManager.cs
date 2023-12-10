using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance { get; private set; }

    [SerializeField] private List<Unit> unitList;
    [SerializeField] private List<Unit> friendlyUnitList;
    [SerializeField] private List<Unit> enemyUnitList;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Theres more than one UnitManager " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        unitList = new List<Unit>();
        friendlyUnitList = new List<Unit>();
        enemyUnitList = new List<Unit>();
    }

    private void Start()
    {
        Unit.OnAnyUnitSpawned += Unit_OnAnySpawned;
        Unit.OnAnyUnitDead += Unit_OnAnyUnitDead;
    }

    private void Unit_OnAnySpawned(object sender, EventArgs e)
    {
        Unit unit = sender as Unit;

        Debug.Log(unit + " spawned");

        //add any unit to this list
        unitList.Add(unit);
        if (unit.IsEnemy())
        {
            //if its enemy add to the enemy list
            enemyUnitList.Add(unit);
        }
        else
        {
            //else if its not add friendly unit to the friendly list
            friendlyUnitList.Add(unit);
        }
    }

    private void Unit_OnAnyUnitDead(object sender, EventArgs e)
    {
        Unit unit = sender as Unit;

        Debug.Log(unit + " unit died");

        //add any unit to this list
        unitList.Remove(unit);
        if (unit.IsEnemy())
        {
            //if its enemy add to the enemy list
            enemyUnitList.Remove(unit);
        }
        else
        {
            //else if its not add friendly unit to the friendly list
            friendlyUnitList.Remove(unit);
        }
    }

    public List<Unit> GetUnitList()
    {
        return unitList;
    }

    public List<Unit> GetFriendlyUnitList()
    {
        return friendlyUnitList;
    }

    public List<Unit> GetEnemyUnitList()
    {
        return enemyUnitList;
    }


}
