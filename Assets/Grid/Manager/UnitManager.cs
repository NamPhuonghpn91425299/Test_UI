using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;
    private void Awake()
    {
        if (UnitManager.Instance != null) Debug.Log("Only one use Sigleton");
        UnitManager.Instance = this;
    }
}
