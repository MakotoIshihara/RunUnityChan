using UnityEngine;
using System.Collections;

public class UnityChanController : MonoBehaviour {

	public void Jump(){
        this.GetComponent<Animator>().SetTrigger("jump");
	}

    public void Down() {
        this.GetComponent<Animator>().SetBool("Down", true);
    }

    public void DownToUp() {
        this.GetComponent<Animator>().SetBool("Down", false);
    }

    public void OnCollidedWithObstacle() {
        this.GetComponent<Animator>().SetTrigger("Collision");
    }
	
	// Update is called once per frame
	public void OnCallChangeFace() {
	
	}
}
