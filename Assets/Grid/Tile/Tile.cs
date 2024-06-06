using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public abstract class Tile : MonoBehaviour
{
    public string tileName;
    [SerializeField] protected SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private bool _isWalkble;
    public BaseUnit occupiedUnit;
    public bool IsWalkble => _isWalkble && occupiedUnit == null;

    public virtual void Init(int x, int y)
    {
 
        // nếu isOffset = true thid spawn màu tương ứng với _offsetColor, isOffset = flase tương ứng với màu _baseColor
    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
        MenuManager.Instance.ShowTileInfo(this);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
        MenuManager.Instance.ShowTileInfo(null);
    }


    private void OnMouseDown()
    {
        //if (GameManager.Instance.gameState != GameManager.GameState.HeroesTurn) return;

        if (occupiedUnit != null)
        {
            if (occupiedUnit.Faction == Faction.Hero)
            {
                UnitManager.Instance.SetSelectHero((BaseHero)occupiedUnit);
            }
            else
            {
                if (UnitManager.Instance.selectHero != null)
                {
                    var enemy = (BaseEnemy)occupiedUnit;
                    Destroy(enemy.gameObject);
                    UnitManager.Instance.SetSelectHero(null);
                }
            }

        }
        else
        {
            if (UnitManager.Instance.selectHero != null)
            {
                SetUnit(UnitManager.Instance.selectHero);
                UnitManager.Instance.SetSelectHero(null);
            }
        }
    }
    //void OnMouseDown()
    //{
    //    if (GameManager.Instance.gameState != GameManager.GameState.HeroesTurn) return;

    //    if (occupiedUnit != null)
    //    {
    //        if (occupiedUnit.Faction == Faction.Hero) UnitManager.Instance.SetSelectHero((BaseHero)occupiedUnit);
    //        else
    //        {
    //            if (UnitManager.Instance.selectHero != null)
    //            {
    //                var enemy = (BaseEnemy)occupiedUnit;
    //                Destroy(enemy.gameObject);
    //                UnitManager.Instance.SetSelectHero(null);
    //            }
    //        }
    //    }
    //    else
    //    {
    //        if (UnitManager.Instance.selectHero != null)
    //        {
    //            SetUnit(UnitManager.Instance.selectHero);
    //            UnitManager.Instance.SetSelectHero(null);
    //        }
    //    }

    //}
    public void SetUnit(BaseUnit unit)
    {
        if (unit.OccupiedTile != null) unit.OccupiedTile.occupiedUnit = null;

        unit.transform.position = transform.position;
        occupiedUnit = unit;
        unit.OccupiedTile = this;
    }
}
