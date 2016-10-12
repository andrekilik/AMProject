using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LeaderboardScript : MonoBehaviour {

    private HandleScore _handleScore = new HandleScore();
    private bool resetLeaderboard = false; // CUIDADO AQUI
    public bool fadeIn = true, inputEndA = false, inputEndB = false, inputEndC = false, finishedTyping = true;
    public Text inputTextA, inputTextB, inputTextC, actionText;
    public GameObject input;
    public int index = 0;
    public List<TypeValue> typeList = new List<TypeValue>();

    // Use this for initialization
    void Start () {
        List<Score> leaderboard = new List<Score>();

        // feed typeList
        for (int i = 0; i < ConfigurationScript.charList.Count; i++)
        {
            typeList.Add(new TypeValue
            {
                Index = i,
                Value = ConfigurationScript.charList[i]
            });
        }

        if (ConfigurationScript.score > 0)
        {
            _handleScore.AddScore("---");
        }

        leaderboard = _handleScore.GetScore().OrderByDescending(x => x.score).ToList();

        for (int i = 0; i < leaderboard.Count; i++)
        {
            transform.Find("Names/Name" + i).GetComponent<Text>().text = leaderboard[i].name;
            transform.Find("Scores/Score" + i).GetComponent<Text>().text = leaderboard[i].score.ToString();
        }

        var gotHighScore = leaderboard.Where(x => x.name == "---");
        if (gotHighScore.Count() > 0)
        {
            finishedTyping = false;
            input.SetActive(true);
            input.transform.position = transform.Find("Names/Name" + gotHighScore.First().rank).position;
            transform.Find("Names/Name" + gotHighScore.First().rank).gameObject.SetActive(false);
            InvokeRepeating("BlinkText", 0, 0.3f);
        }
        else
            finishedTyping = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (finishedTyping)
            actionText.text = "Back to menu";
        else
            actionText.text = "Confirm";

        if (Input.GetButtonDown("Jump") && finishedTyping)
        {
            ConfigurationScript.score = 0;
            SceneManager.LoadScene("IntroScene");
        }

        if (Input.GetButtonDown("Jump") && index <= 2)
        {
            switch (index)
            {
                case 0:
                    EndInputBlink(ref inputEndA);
                    break;
                case 1:
                    EndInputBlink(ref inputEndB);
                    break;
                case 2:
                    EndInputBlink(ref inputEndC);
                    finishedTyping = true;
                    break;
            }
            index++;
        }

        StartCoroutine(TextSwap());

        if (Input.GetKey(KeyCode.F12))
            ResetLeaderboard();
    }

    void ResetLeaderboard()
    {
        PlayerPrefs.DeleteKey("leaderboard");
    }

    void BlinkText()
    {
        fadeIn = !fadeIn;

        if(!inputEndA)
            inputTextA.gameObject.SetActive(fadeIn);
        else
            inputTextA.gameObject.SetActive(true);

        if (!inputEndB)
            inputTextB.gameObject.SetActive(fadeIn);
        else
            inputTextB.gameObject.SetActive(true);

        if (!inputEndC)
            inputTextC.gameObject.SetActive(fadeIn);
        else
        {
            inputTextC.gameObject.SetActive(true);
            CancelInvoke("BlinkText");

            // persiste no lugar do valor temporario
            var leaderboard = PlayerPrefs.GetString("leaderboard");
            var name = inputTextA.text + inputTextB.text + inputTextC.text;

            leaderboard = leaderboard.Replace("---", name);
            PlayerPrefs.SetString("leaderboard", leaderboard);
        }
    }

    void EndInputBlink(ref bool inputEnd)
    {
        inputEnd = true;
    }

    IEnumerator TextSwap()
    {
        int typeIndex;

        switch (index)
        {
            case 0:
                typeIndex = typeList.Where(x => x.Value == inputTextA.text).First().Index;
                break;
            case 1:
                typeIndex = typeList.Where(x => x.Value == inputTextB.text).First().Index;
                break;
            default:
                typeIndex = typeList.Where(x => x.Value == inputTextC.text).First().Index;
                break;
        }

        var direction = Input.GetAxisRaw("Vertical");

        if (direction > 0)
        {
            yield return new WaitForSeconds(0.3f);
            if (typeIndex == 35)
                typeIndex = 0;
            else
                typeIndex++;
        }
        else if(direction < 0)
        {
            yield return new WaitForSeconds(0.3f);
            if (typeIndex == 0)
                typeIndex = 35;
            else
                typeIndex--;
        }

        switch (index)
        {
            case 0:
                inputTextA.text = typeList.Where(x => x.Index == typeIndex).First().Value;
                break;
            case 1:
                inputTextB.text = typeList.Where(x => x.Index == typeIndex).First().Value;
                break;
            default:
                inputTextC.text = typeList.Where(x => x.Index == typeIndex).First().Value;
                break;
        }
    }
}

public class TypeValue
{
    public int Index { get; set; }
    public string Value { get; set; }
}