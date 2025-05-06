using UnityEngine;
public enum GenerationtransformType
{
    Border,
    Inside
}

public class Spawner : MonoBehaviour
{
    public SpriteRenderer planet;
    private float radius;

    void Start()
    {
        radius = planet.bounds.size.x / 2;
    }

    public void Spawn(GenerationtransformType GTT,GameObject GO)
    {
        float angle = Random.Range(0f, 1f)*360;
        switch (GTT)
        {
            case GenerationtransformType.Border:
                GameObject temp= Instantiate(GO, Quaternion.Euler(0, 0, angle) * new Vector3(0, radius, -1), Quaternion.Euler(0, 0, angle));
                temp.transform.parent = planet.transform;
                break;

            case GenerationtransformType.Inside:
                GameObject temp2 = Instantiate(GO, Quaternion.Euler(0, 0, angle) * new Vector3(0, Random.Range(radius*0.2f, radius), -1), Quaternion.Euler(0, 0, angle));
                temp2.transform.parent = planet.transform;
                break;
        }
    }
}
