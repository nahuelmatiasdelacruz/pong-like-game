using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 25;
    private bool hasTheBallMoved = false;
    private Color leftRacketColor;
    private Color rightRacketColor;
    private SpriteRenderer ballRenderer;
    private TrailRenderer ballTrailRenderer;

    private void Awake()
    {
        leftRacketColor = GameObject.Find("Racket_Left").GetComponent<SpriteRenderer>().color;
        rightRacketColor = GameObject.Find("Racket_Right").GetComponent<SpriteRenderer>().color;
        ballRenderer = GetComponent<SpriteRenderer>();
        ballTrailRenderer = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        if (!hasTheBallMoved && GameManager.sharedInstance.gameStarted)
        {
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.right * speed;
            hasTheBallMoved = true;
        }
        if (GameManager.sharedInstance.gameStarted)
        {
            if(GetComponent<Rigidbody2D>().linearVelocity.x > 0)
            {
                ballRenderer.color = leftRacketColor;
                ballTrailRenderer.startColor = leftRacketColor;
                ballTrailRenderer.endColor = leftRacketColor;
            }
            else
            {
                ballRenderer.color = rightRacketColor;
                ballTrailRenderer.startColor = rightRacketColor;
                ballTrailRenderer.endColor = rightRacketColor;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Racket")) return;
        float y = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
        RacketAxis axis = collision.gameObject.GetComponent<VerticalMovement>().axis;
        int x = 1;
        if(axis == RacketAxis.LeftRacket)
        {
            x = -1;
        }
        Vector2 direction = new Vector2(x, y).normalized;
        GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
    }

    float HitFactor(Vector2 ballPosition, Vector2 racketPosition, float raquetHeight) => (ballPosition.y - racketPosition.y) / raquetHeight;
}
