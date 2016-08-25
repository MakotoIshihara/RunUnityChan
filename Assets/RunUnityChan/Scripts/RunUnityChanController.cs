using UnityEngine;
using System.Collections;

public class RunUnityChanController : MonoBehaviour {

    [SerializeField]
    private UnityChanController unityChanController;
    [SerializeField]
    //private GameObject obstaclePrefab;
    private float elapsedTime = 0.0f;
    private bool isGameOver = false;
    public GameObject[] obstacleArray;

    void Update(){
       
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            this.unityChanController.Jump();
        } else {
            if (Input.GetKey(KeyCode.DownArrow)) {
                this.unityChanController.Down();
            } else {
                this.unityChanController.DownToUp();
            } 
        }

        //if (Input.GetMouseButtonDown(0)){
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit raycastHit;
        //    if(Physics.Raycast(ray, out raycastHit)) {
        //        if (raycastHit.transform.gameObject.tag.Contains("UnityChan")) {
        //            this.unityChanController.OnTapped();
        //        }
        //    }
        //}

        elapsedTime += Time.deltaTime;
        if(3.0f <= elapsedTime) {
            int number = Random.Range(0, obstacleArray.Length);
            GameObject obstacle = Instantiate(obstacleArray[number]);
            ObstacleController obstacleController = obstacle.GetComponent<ObstacleController>();
            obstacleController.CollidedWithUnityChan += this.ObstacleCollidedWithUnityChan;
            switch (obstacle.tag) {
                case "broadBar":
                    obstacle.transform.position = new Vector3(0.0f, 1.2f, 3.0f);
                    break;
                case "bar":
                    obstacle.transform.position = new Vector3(0.0f, 0.0f, 3.0f);
                    break;
                default:
                    break;
            }
            //obstacle.transform.position = new Vector3(0.0f, 0.0f, 3.0f);
            elapsedTime = 0.0f;
        }
    }

    private void ObstacleCollidedWithUnityChan() {
        if (this.isGameOver) {
            return;
        }
        this.unityChanController.OnCollidedWithObstacle();
        this.isGameOver = true;
    }
}
