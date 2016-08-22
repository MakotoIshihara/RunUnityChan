using UnityEngine;
using System.Collections;

public class UnityChanController : MonoBehaviour {

	public void OnTapped(){
        this.GetComponent<Animator>().SetTrigger("jump");
	}

    public void OnCollidedWithObstacle() {
        this.GetComponent<Animator>().SetTrigger("Collision");
    }
	
	// Update is called once per frame
	public void OnCallFace() {
	
	}
}
