using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public enum HorizontalScriptDirection
{
    Left,
    Right
}

public class HorizontalSetup : MonoBehaviour
{
    public HorizontalScriptDirection Direction = HorizontalScriptDirection.Right;
    public float Speed = 1f;
    public GameObject Target;

    private float RandomRangeLimit = 5f;
    private Vector3 InitialPosition;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 vectorDirection;
        var randomXJitter = 0f;

        switch (Direction)
        {
            case HorizontalScriptDirection.Left:
                vectorDirection = Vector2.left;
                InitialPosition = new Vector3(12f, 0f, 0f);
                randomXJitter = UnityEngine.Random.Range(0f, RandomRangeLimit);
                break;
            case HorizontalScriptDirection.Right:
                vectorDirection = Vector2.right;
                InitialPosition = new Vector3(-12f, 0f, 0f);
                randomXJitter = UnityEngine.Random.Range(-RandomRangeLimit, 0);
                break;
            default:
                throw new System.Exception("Must set direction");
        }

        var Trigger = transform.Find("Trigger");
        var horizontalMovement = Trigger.AddComponent<HorizontalMovement>();
        horizontalMovement.VectorDirection = vectorDirection;
        horizontalMovement.Speed = Speed;
        horizontalMovement.Target = Target;


        Target.transform.SetPositionAndRotation(new Vector3(InitialPosition.x + randomXJitter, Target.transform.position.y, Target.transform.position.z), quaternion.identity);

        if (Direction == HorizontalScriptDirection.Left)
        {
            Target.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
}
