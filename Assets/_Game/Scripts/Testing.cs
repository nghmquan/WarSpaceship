using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public List<int> intList = new List<int>();
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int stringToRetrieve = GetRandomItem(intList);
        }
    }
    public int GetRandomItem(List<int> listToRandomize)
    {
        int randomNum = Random.Range(0, listToRandomize.Count);
        int printRandom = listToRandomize[randomNum];
        print(printRandom);
        return printRandom;
    }
}
