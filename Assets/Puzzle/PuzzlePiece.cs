using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer _renderer; 
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip pickUpClip, dropClip;

    [SerializeField] protected bool isDragging, _placed;
    protected Vector2 _offset, _originalPositon;
    protected PuzzleSlot _slot;

    public void Init(PuzzleSlot slot)
    {
        _renderer.sprite = slot._rendererSlot.sprite;
        _slot = slot;
    }

    private void Awake()
    {
        this._originalPositon = transform.position;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (_placed) return;
        if (!isDragging || _placed) return;
        var mousePosition = GetMousePos();
        transform.position = mousePosition - _offset;


    }

    private void OnMouseDown()
    {
        this.isDragging = true;
        this.audioSource.PlayOneShot(pickUpClip);
        this._offset = GetMousePos() - (Vector2)transform.position;
    }

    private void OnMouseUp()
    {
        if (Vector2.Distance(transform.position, _slot.transform.position) < 1f)
        {
            
            transform.position = _slot.transform.position;
            _slot.Placed();
            _placed = true;
        }
        else
        {
        transform.position = this._originalPositon;
        this.audioSource.PlayOneShot(dropClip);
        this.isDragging = false;
        }
    }
    protected virtual Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
