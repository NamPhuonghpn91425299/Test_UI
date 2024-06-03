using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{

    [SerializeField] protected SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;

    public virtual void Init(int x, int y)
    {
 
        // nếu isOffset = true thid spawn màu tương ứng với _offsetColor, isOffset = flase tương ứng với màu _baseColor
    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}
