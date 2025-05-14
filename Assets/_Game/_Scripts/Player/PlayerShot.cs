using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    private bool isShot;
    private float timeToShot;
    private float delayTimeShot;
    private bool hasLoggedStopShoting;

    public bool GetShoting()
    {
        return isShot;
    }

    public void SetShoting(bool _isShot)
    {
        isShot = _isShot;
    }

    public float GetTimeToShot()
    {
        return timeToShot;
    }

    public void SetTimeToShot(float _timeToShot)
    {
        timeToShot = _timeToShot;
        delayTimeShot = timeToShot;
    }

    public void Shot()
    {
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
            timeToShot = delayTimeShot;
        }
    }
}
