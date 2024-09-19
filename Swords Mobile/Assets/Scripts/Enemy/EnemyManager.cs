using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemies;
    public List<Transform> attackPoints;

    [HideInInspector] public Enemy selectedEnemy;

    private List<Enemy> enemiesInAttackRange;
    private float attackInterval = 5f;
    private Enemy.AttackType[] attackTypes = (Enemy.AttackType[])System.Enum.GetValues(typeof(Enemy.AttackType));

    private void Awake()
    {
        foreach (Enemy enemy in enemies)
        {
            enemy.attackPoint = attackPoints[Random.Range(0, attackPoints.Count)];
            Debug.Log(enemy.attackPoint.tag);
        }

        enemiesInAttackRange = enemies;
    }

    private void Start()
    {

        // FIXME :: Selecting Enemy should not be a timely process, instead it should occur when after an attack is completed
        InvokeRepeating("SelectEnemy", 0f, 3f);

        if(enemiesInAttackRange.Count > 0)
        {
            InvokeRepeating("RandomAttack", 1f, attackInterval);
        }
    }

    // TODO -> Check if enemy is in attack range 
    // TODO -> Make The Random Attack more specific and let it depend on values such as GetDistanceFromPlayer()

    public void SelectEnemy()
    {
        int randomIndex = Random.Range(0, enemiesInAttackRange.Count);
        selectedEnemy = enemiesInAttackRange[randomIndex];
    }
    
    void RandomAttack()
    {
        // Select A Random Attack from selectedEnemy
        Enemy.AttackType randomAttackType = attackTypes[Random.Range(0, attackTypes.Length)];

        selectedEnemy.PerformAttack(randomAttackType);
    }

    

}
