using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    private bool isShot;
    private float timeToShot;

    private bool hasLoggedStopShoting;

    public void Shot(bool _isShot, float _delayTimeToShot)
    {
        isShot = _isShot;

        if (!isShot)
        {
            if (!hasLoggedStopShoting)
            {
                Debug.Log("Stop shoting");
                hasLoggedStopShoting = true;
            }
            return;
        }

        hasLoggedStopShoting = false;
        timeToShot -= Time.deltaTime;

        if (timeToShot <= 0)
        {
            Bullet bullet = BulletPool.Instance.GetObjectFromPool("Bullet");
            bullet.transform.position = transform.position;
            timeToShot = _delayTimeToShot;
        }
    }
}
