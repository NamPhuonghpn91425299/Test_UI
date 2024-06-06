using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    [SerializeField] private GameObject _selectHeroObject;
    [SerializeField] private GameObject _tileObject;
    [SerializeField] private GameObject _tileUnitObject;
    private void Awake()
    {
        if (MenuManager.Instance != null) return;
            MenuManager.Instance = this;   
    }
    public void ShowTileInfo(Tile tile)
    {
        if (tile == null)
        {
            _tileObject.SetActive(false);
            _tileUnitObject.SetActive(false);
            return;
        }
        _tileObject.GetComponentInChildren<Text>().text = tile.tileName;
        _tileObject.SetActive(true);
        if(tile.occupiedUnit)
        {
            _tileUnitObject.GetComponentInChildren<Text>().text = tile.occupiedUnit.UnitName;
            _tileUnitObject.SetActive(true);
        }
    }
    public void ShowSelectedHero(BaseHero hero)
    {
        if (hero == null)
        {
            _selectHeroObject.SetActive(false);
            return;
        }
        _selectHeroObject.GetComponentInChildren<Text>().text = hero.UnitName;
        _selectHeroObject.SetActive(true);
    }


}
