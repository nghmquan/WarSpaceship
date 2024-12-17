using UnityEngine;

public class Background : MonoBehaviour
{
    [Header("Background System")]
    [SerializeField] protected Renderer backgroundRenderer;
    [SerializeField] protected float baseSpeed;
    [SerializeField] protected float speedLoop;

    [SerializeField] protected float elapsedTime = 0f;

    private void Update()
    {
        LoopingBackground();
    }

    protected void LoopingBackground()
    {
        elapsedTime += Time.deltaTime;
        float dynamicSpeed = baseSpeed + elapsedTime * speedLoop;
        backgroundRenderer.material.mainTextureOffset += new Vector2(dynamicSpeed * Time.deltaTime,0);
    }

    //Function to get elapsed magnet if needed to display on UI
    protected float GetElapsedTime()
    {
        return elapsedTime;
    }
}
