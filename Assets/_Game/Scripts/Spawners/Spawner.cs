using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    protected virtual IEnumerator DelayTimeToSpawn(float _timeToSpawn)
    {
        yield return new WaitForSeconds(_timeToSpawn);
    }

    protected virtual void Spawn(List<T> _prefabsArray, float[] _rangeSpawnPosition, Transform _prefabsHolder)
    {
        float randomSpawnPosition = Random.Range(0, _rangeSpawnPosition.Length);
        var randomSpawnObject = new Vector2(randomSpawnPosition, transform.position.y);

        T prefabToSpawn = _prefabsArray[Random.Range(0, _prefabsArray.Count)];
        Instantiate(prefabToSpawn, randomSpawnObject, Quaternion.identity, _prefabsHolder);
    }
}
