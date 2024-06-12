using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _img;
    [SerializeField] private Sprite _default, _pressed;
    [SerializeField] private AudioClip _compressClip, _uncompressClip;
    [SerializeField] private AudioSource _audioSource;
    public void OnPointerDown(PointerEventData eventData)
    {
        _img.sprite = _pressed;
        _audioSource.PlayOneShot(_compressClip);

       //throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _img.sprite = _default;
        _audioSource.PlayOneShot(_uncompressClip);
        //throw new System.NotImplementedException();
    }
    public virtual void Clicked() {
        Debug.Log("Clicked!");

        
    }
}
