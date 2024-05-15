using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    public SpriteRenderer _rendererSlot;
    [SerializeField] protected AudioSource audioSource;
    //[SerializeField] protected AudioClip _completeClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Placed()
    {
        audioSource.Play();
    }



}
