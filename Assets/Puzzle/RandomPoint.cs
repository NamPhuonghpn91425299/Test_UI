using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomPoint : MonoBehaviour
{
    [SerializeField]
    private List<Transform> points; // Danh sách các điểm cần trộn

    void Start()
    {
        // Trộn danh sách các điểm khi bắt đầu
        points = Shuffle(points);

        // In ra danh sách các điểm sau khi trộn
        foreach (Transform point in points)
        {
            Debug.Log(point);
        }
    }

    // Hàm trộn danh sách các điểm
    public List<T> Shuffle<T>(List<T> list)
    {
        return list.OrderBy(item => Random.value).ToList();
    }
}
