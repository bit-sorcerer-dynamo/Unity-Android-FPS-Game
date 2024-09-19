using UnityEngine;

public class CameraViewPointTracker : MonoBehaviour
{
    public EnemyManager enemyManager;
    public float smoothTime = 1f;

    private Vector3 smoothVelocity;

    void Update()
    {
        Transform selectedEnemyViewPoint = GetSelectedEnemyViewPoint(enemyManager.selectedEnemy);
        LerpTransformPositionToEnemy(selectedEnemyViewPoint.position, smoothTime);
    }

    void LerpTransformPositionToEnemy(Vector3 selectedEnemyViewPointPosition, float smoothTime)
    {
        transform.position = Vector3.SmoothDamp(transform.position, selectedEnemyViewPointPosition , ref smoothVelocity , smoothTime);
    }

    Transform GetSelectedEnemyViewPoint(Enemy selectedEnemy)
    {
        return selectedEnemy.transform.GetChild(0);
    }
}
