using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

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

    private Vector3 InitialPosition;
    // Start is called before the first frame update
    void Start()
    {
        var VectorDirection = Vector2.zero;
        switch (Direction)
        {
            case HorizontalScriptDirection.Left:
                VectorDirection = Vector2.left;
                InitialPosition = new Vector3(12f, 0f, 0f);
                break;
            case HorizontalScriptDirection.Right:
                VectorDirection = Vector2.right;
                InitialPosition = new Vector3(-12f, 0f, 0f);
                break;
            default:
                throw new System.Exception("Must set direction");
        }

        var Trigger = transform.Find("Trigger");
        var horizontalMovement = Trigger.AddComponent<HorizontalMovement>();
        horizontalMovement.VectorDirection = VectorDirection;
        horizontalMovement.Speed = Speed;
        horizontalMovement.Target = Target;

        Target.transform.SetPositionAndRotation(new Vector3(InitialPosition.x, Target.transform.position.y, Target.transform.position.z), quaternion.identity);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
}
