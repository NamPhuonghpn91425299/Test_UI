using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour
{

    public static UnitManager Instance;
    protected List<ScriptableUnit> _units;
    public BaseHero selectHero;
    private void Awake()
    {
        if (UnitManager.Instance != null) Debug.Log("Only one use Sigleton");
        UnitManager.Instance = this;
        this._units = Resources.LoadAll<ScriptableUnit>("Units").ToList();

    }


    public virtual void SpawnHeros()
    {
        var heroCount = 1;
        for (int i = 0; i < heroCount; i++)
        {
            var randomPrefab = GetRandomUnit<BaseHero>(Faction.Hero);
            var sapwnedHero = Instantiate(randomPrefab);
            var randomSpawnTile = GridManager.Instance.GetHerospawnTile();

            randomSpawnTile.SetUnit(sapwnedHero);
        }
        GameManager.Instance.ChangeState(GameManager.GameState.SpawnEnemies);
    }

    public virtual void SpawnEnemy
       ()
    {
        var enemyCount = 1;
        for (int i = 0; i < enemyCount; i++)
        {
            var randomPrefab = GetRandomUnit<BaseHero>(Faction.Enemy);
            var sapwnedEnemy = Instantiate(randomPrefab);
            var randomSpawnTile = GridManager.Instance.GetEnemyspawnTile();

            randomSpawnTile.SetUnit(sapwnedEnemy);
        }
    }


    protected T GetRandomUnit<T>(Faction faction) where T: BaseUnit
    {
        return (T)_units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefab;
    }
    public void SetSelectHero(BaseHero hero)
    {
        selectHero = hero;
        MenuManager.Instance.ShowSelectedHero(hero);
    }
}
