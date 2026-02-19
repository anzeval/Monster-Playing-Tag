using UnityEngine;

public class ExplosionHandler : MonoBehaviour
{
    [SerializeField] private float explotionTime = 0.3f;
    private float explotionTimer = 0f;

    public void CauseExplosion()
    {
        Instantiate(gameObject, transform.position, Quaternion.identity, transform);
    }

    void Update()
    {
        if(explotionTime > explotionTimer)
        {
            explotionTimer += Time.deltaTime;
        } 
        else
        {
            Destroy(gameObject);
        }
    }
}
