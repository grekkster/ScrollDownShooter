using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO do vlastni tridy + import - do nejakyho hlavniho objektu?
// - něco jako GameController game objekt?/třída jako v jednom z těch příkladů na scrollovačky
// -- https://unity3d.com/learn/tutorials/topics/2d-game-creation/scrolling-repeating-backgrounds?playlist=17093
// -- https://unity3d.com/learn/tutorials/projects/space-shooter-tutorial/extending-space-shooter-enemies-more-hazards?playlist=17147
// TODO - udělat jinak/lépe podle kolizního modelu, nebo alespoň ořezat okraje spritu, aby tam nebyla neviditelná hranice od rozměrů xwinga
[System.Serializable]
public class Boundaries
{
    // TODO programově - získat z objektu
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2D;
    //private Transform transform;
    private Vector2 movement;
    public const float speed = 1f;
    public Boundaries boundaries;

    private void Awake()
    {
        //rb2D = GetComponent<Rigidbody2D>();
        //transform = GetComponent<Transform>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
    // - only for Update
    // - FixedUpdate should be called 50x/s
    // 3d/2d tutorial - používá FixedUpdate, jenže tady se sice používá physics, ale ne force, jen movemen. Update je plynulejší pohyb?
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Optimalizace?
        //movement = new Vector2(moveHorizontal, moveVertical);

        movement.x = moveHorizontal;
        movement.y = moveVertical;

        //rb2D.velocity = movement * speed;

        // Optimalizace?
        //Constraint to game screen
        //rb2D.position = new Vector2
        //(
        //    Mathf.Clamp(rb2D.position.x, boundaries.xMin, boundaries.xMax),
        //    Mathf.Clamp(rb2D.position.y, boundaries.yMin, boundaries.yMax)
        //);

        //rb2D.MovePosition(new Vector2(Mathf.Clamp(rb2D.position.x, boundaries.xMin, boundaries.xMax), Mathf.Clamp(rb2D.position.y, boundaries.yMin, boundaries.yMax)));

        transform.position = new Vector2
        (
            Mathf.Clamp(transform.position.x + movement.x*speed, boundaries.xMin, boundaries.xMax),
            Mathf.Clamp(transform.position.y + movement.y*speed, boundaries.yMin, boundaries.yMax)
        );
    }
}
