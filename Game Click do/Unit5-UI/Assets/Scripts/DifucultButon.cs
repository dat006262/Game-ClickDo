using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DifucultButon : MonoBehaviour
{
    public int dificult_int;
    private Button btn;
    private SpawnManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SetDificult);
        gamemanager =GameObject.Find("Game Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetDificult() 
    {

        gamemanager.StartGame(dificult_int);
    }
}
