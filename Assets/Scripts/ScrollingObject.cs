using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

    public float scrollSpeed;
    private Vector3 startPosition;
    // TODO tileSizeY private + ziskat primo z textury!
    private float tileSizeY;

    //TODO varianty:
    //https://unity3d.com/learn/tutorials/topics/2d-game-creation/2d-scrolling-backgrounds?playlist=17093
    //https://unity3d.com/learn/tutorials/topics/2d-game-creation/scrolling-repeating-backgrounds?playlist=17093

    // Use this for initialization
    void Start () {
        startPosition = transform.position;
        Renderer renderer = GetComponentInChildren<Renderer>();
        tileSizeY = renderer.bounds.size.y;
    }
	
	// Update is called once per frame
    // TODO předělat - sekne se to, když se resetuje pozadí - když jedno odroluje, posunout ho nahoru, pak zas to druhý
	void Update() {
        //a)
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);
        transform.position = startPosition + Vector3.down * newPosition;

        // Optimalizace?
        //b) reset position of the bottom rolled out texture
        var backgroundArray = GetComponentsInChildren<Transform>();
    }
}
