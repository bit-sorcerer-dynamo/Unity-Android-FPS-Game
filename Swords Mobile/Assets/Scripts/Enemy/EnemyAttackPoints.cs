using UnityEngine;

public class EnemyAttackPoints : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        transform.position = player.position;
    }
}
