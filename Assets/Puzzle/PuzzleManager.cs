using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] protected List<PuzzleSlot> _slotPrefab;
    [SerializeField] protected PuzzlePiece _piecePrefab;
    [SerializeField] protected Transform _slotParent, _pieceParent;
    // Start is called before the first frame update
    void Start()
    {
        this.spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spawn()
    {
        var randomSet = _slotPrefab.OrderBy(s => Random.value).Take(5).ToList();

        for (int i = 0; i < randomSet.Count; i++)
        {

            var spawnedSlot = Instantiate(randomSet[i], _slotParent.GetChild(i).position, Quaternion.identity);

            var spawnedPiece = Instantiate(_piecePrefab, _pieceParent.GetChild(i).position, Quaternion.identity);
            spawnedPiece.Init(spawnedSlot);
        }
    }
}
