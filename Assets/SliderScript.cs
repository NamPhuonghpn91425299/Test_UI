using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class SliderScript : MonoBehaviour
{
    [SerializeField] protected Slider _slider;
    [SerializeField] protected TextMeshProUGUI _slidertext;
    
    // Start is called before the first frame update
    void Start()
    {
        _slider.onValueChanged.AddListener((v) => _slidertext.text = v.ToString("0.00"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
