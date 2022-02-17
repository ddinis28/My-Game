using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class enemyController : MonoBehaviour {
    private Transform enemyHolder;
    public float speed;
    
    public Text winText;
    public Text backToMenu;
   
	// Use this for initialization
	void Start () {

        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        enemyHolder = GetComponent<Transform>();
	}
	
	void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed;

        foreach(Transform enemy in enemyHolder)
        {
            if (enemy.position.x < -10.5 || enemy.position.x > 10.5)
            {
                speed = -speed;
                enemyHolder.position += Vector3.down * 0.5f;
                return;
            }

            if (enemy.position.y <= -4)
            {
                GameOver.isPlayerDead = true;
                Time.timeScale = 0;
            }
        }
        if (enemyHolder.childCount <= 10)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
        }
        if (enemyHolder.childCount == 0 )
        {
            winText.enabled = true;
            backToMenu.enabled = true;
            if (Input.GetKeyUp(KeyCode.B))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
    }
}
