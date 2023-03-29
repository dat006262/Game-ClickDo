using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    private float spawnwait=2;
    public List<GameObject> list_target;//Cách 2:mảng public GameObject[] list_target2;
    public TextMeshProUGUI score_txt;
    private int score = 0;
    public bool isGameActive = true;
    public Button restart_button;

    public TextMeshProUGUI gameoover_txt;
    public GameObject Menu;
    // Start is called before the first frame update
    void Start()
    {  
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Spawn_target() 
    {
        while( isGameActive) 
        {
            yield return new WaitForSeconds(spawnwait);
            int index= Random.Range(0,list_target.Count);
            Instantiate(list_target[index]);
        }
    }
    public void Update_Diem(int scoretoAdd) 
    {
        score+=scoretoAdd;
        score_txt.text = "Score: " + score;
    }
    public void Gameover() {
        isGameActive = false;
        gameoover_txt.gameObject.SetActive(true);
        restart_button.gameObject.SetActive(true);

    }
    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int dificult) 
    {
        isGameActive = true;
        StartCoroutine(Spawn_target());
        score = 0;
        gameoover_txt.gameObject.SetActive(false);
        restart_button.gameObject.SetActive(false);
        Update_Diem(0);
        Menu.gameObject.SetActive(false);
        spawnwait = spawnwait / (dificult );
    }
}
