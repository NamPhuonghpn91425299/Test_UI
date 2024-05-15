using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Floppy : MonoBehaviour
{
    [SerializeField] protected LineRenderer _renderer;
    [SerializeField] protected List<Transform> _point;
    // Start is called before the first frame update
    void Start()
    {
        _renderer.positionCount = _point.Count;
    }

    // Update is called once per frame
    void Update()
    {
        Drawline();
    }
    private void OnDrawGizmos()
    {
        _renderer.positionCount = _point.Count;
        Drawline();
    }
    protected void Drawline()
    {
        _renderer.SetPositions(_point.Select(p => p.position).ToArray());
    }

}
