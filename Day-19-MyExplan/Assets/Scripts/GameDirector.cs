using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameDirector : MonoBehaviour
{

    GameObject car;
    public Car_Ctrl c_Ctrl;
    GameObject flag;
    GameObject distance;
    Text distanceText;

    public Text[] RankText;
    public Button ResetBtn;

    List<float> Rank = new List<float>();

    int Count = 0;
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("car");
        flag = GameObject.Find("flag");
        distance = GameObject.Find("Distance");
        distanceText = distance.GetComponent<Text>();

        if (ResetBtn != null)
            ResetBtn.onClick.AddListener(() => { SceneManager.LoadScene("GameScene"); });
    }

    // Update is called once per frame
    void Update()
    {
        if (Count == 3)
        {
            c_Ctrl.state = Car_State.End;
            Print();
        }

        Vector3 Pos = car.transform.position;
        Vector3 flagPos = flag.transform.position;
        float length = flagPos.x - Pos.x;

        distanceText.text = "Distance : " + Mathf.Abs(length).ToString("F2") + "m";

        if (c_Ctrl.state == Car_State.Stop)
        {
            PrintText(Count, length);
        }
    }

    void PrintText(int index, float length)
    {
        Rank.Add(Mathf.Abs(length));
        RankText[index].text = $"Player {index + 1} ; {Mathf.Abs(length):F2}m";
        Count++;
        c_Ctrl.state = Car_State.Start;
        car.transform.position = new Vector2(-7.0f, -3.7f);
    }

    void Print()
    {
        float[] index = new float[3];

        int count = 0;

        foreach (var i in Rank)
        {
            index[count] = i;
            count++;
        }

        Rank.Sort();

        RankText[0].text += $" {Rank.IndexOf(index[0])+1}µî";
        RankText[1].text += $" {Rank.IndexOf(index[1])+1}µî";
        RankText[2].text += $" {Rank.IndexOf(index[2])+1}µî";

        Count++;
    }
}