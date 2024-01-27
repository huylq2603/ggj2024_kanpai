using UnityEngine;
using UnityEngine.UIElements;

public enum HorizontalScriptDirection
{
    Left,
    Right
}

public class HorizontalScript : MonoBehaviour
{
    public HorizontalScriptDirection Direction;
    public float Speed;

    private readonly float Scale = 0.1f;

    private Vector2 VectorDirection;
    // Start is called before the first frame update
    void Start()
    {
        switch (Direction)
        {
            case HorizontalScriptDirection.Left:
                VectorDirection = Vector2.left;
                break;
            case HorizontalScriptDirection.Right:
                VectorDirection = Vector2.right;
                break;
            default:
                throw new System.Exception("Must set direction");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(VectorDirection.normalized * (Speed * Scale));
    }
}
