using UnityEngine;

public enum RacketAxis
{
    LeftRacket,
    RightRacket
}

public class VerticalMovement : MonoBehaviour
{
    public float movementSpeed = 30;
    public RacketAxis axis = RacketAxis.LeftRacket;

    private void FixedUpdate()
    {
        float v = Input.GetAxisRaw(axis.ToString());
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, v * movementSpeed);
    }
}
