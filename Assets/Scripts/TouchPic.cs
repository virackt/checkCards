using UnityEngine;
using System.Collections;

public class TouchPic : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
		if (Input.GetMouseButtonDown (0)) {
				
//			Debug.Log(GameObje.transform.position.x);
				Debug.Log ("Clicked");
			checkTouch(Input.mousePosition);
		}

		if (isTouched ()) {
			Debug.Log("touched");		
		}
//        if (Input.touchCount > 0)
//        {
//
//            if (Input.GetTouch(0).phase == TouchPhase.Began)
//            {
//                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
//                if (hit)
//                {
//                    Debug.Log(hit.transform.gameObject.name);
//                    
//                }
//            }
//        }
		}


	public void checkTouch(Vector3 pos){
		Vector3 wp = Camera.main.WorldToScreenPoint (pos);
		Vector2 touchPos = new Vector2 (wp.x, wp.y);
		Collider2D hit = Physics2D.OverlapPoint (touchPos);
		if (hit) {
			Debug.Log(hit.gameObject.name);		
		}
	}

	public bool isTouched() {
		bool result = false;
		if(Input.touchCount == 1) {
			if(Input.touches[0].phase == TouchPhase.Ended) {
				Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
				Vector2 touchPos = new Vector2(wp.x, wp.y);
				if (collider2D == Physics2D.OverlapPoint(touchPos)) {
					result = true;
				}
			}
		}
		if(Input.GetMouseButtonUp(0)) {
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos = new Vector2(wp.x, wp.y);
			Collider2D cd = Physics2D.OverlapPoint(mousePos);
			if (cd) {
				result = true;
				Debug.Log(cd.gameObject.name);
				SpriteRenderer renderer = (SpriteRenderer)cd.gameObject.renderer;
				renderer.sprite = new Sprite();
			}
		}
		return result;
	}

	
}
