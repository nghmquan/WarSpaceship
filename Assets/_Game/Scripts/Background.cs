using UnityEngine;

public class Background : Singleton<Background>
{
    [Header("Background System")]
    [SerializeField] private Renderer backgroundRenderer;
    [SerializeField] private float baseSpeed;
    [SerializeField] private float speedLoop;
    [SerializeField] private float elapsedTime = 0f;

    public void LoopingBackground()
    {
        elapsedTime += Time.deltaTime;
        float dynamicSpeed = baseSpeed + elapsedTime * speedLoop;
        backgroundRenderer.material.mainTextureOffset += new Vector2(dynamicSpeed * Time.deltaTime,0);
    }

    //Function to get elapsed magnet if needed to display on UI
    public float GetElapsedTime()
    {
        return elapsedTime;
    }
}
