using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizController : MonoBehaviour
{
    public TextMeshPro t;
    private int i = 1;
    private short correct = 1;
    private short[] correct2 = { 1, 2 };
    private bool twoCorrect = false;
    private int score = 0;
    private const int totQuestions = 5;//+ 1;
    private const int totPoints = 9;
    public bool quizOver = false;

    // Start is called before the first frame update
    void Start()
    {
        t.text = "Question One: Where is the current location of the pre-Bactrian archaeological site called Padjart Alkmy/Sahri Murdagon?" +
            "\nA) Tajikistan" +
            "\nB) Egypt" +
            "\nC) Pakistan" +
            "\nD) Turkey";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return;
        }
        if(i <= totQuestions)
        {
            rightAnswer();
        }
        if (quizOver && OVRInput.GetDown(OVRInput.Button.Three))
        {
            SceneManager.LoadScene("menu");
        }

    }

    void nextQ()
    {
        switch (i)
        {
            case 1:
                t.fontSize = 3;
                t.text = " Question Two: In one sentence, can you explain how and when the Sahri Murdagon archaeological artifacts were initially found?" +
            "\nA) In 1970, French researchers finished their search for Sahri Murdagon" +
            "\nB) In 1967, French researchers finished their search for Sahri Murdagon" +
            "\nX) In 1970, rock climbers initially found archaelogical artifacts of Sahri Murdagon" +
            "\nY) In 1967, rock climbers initially found archaelogical artifacts of Sahri Murdagon";
                correct = 3;
                correct2[0] = 1;
                correct2[1] = 4;
                twoCorrect = true;
                break;
            case 2:
                t.fontSize = 3;

                t.text = "Question Three: Aside from bones, name two things that were found in the Sahri Murdagon urns." +
            "\nA) Petrified fruit and mummified field mice" +
            "\nB) Balls of clay and stone cutting tools" +
            "\nX) Votive figurines and stone cutting tools" +
            "\nY) Wax and stone cutting tools";
                correct = 3;
                correct2[0] = 2;
                correct2[1] = 4;
                twoCorrect = true;
                break;
            case 3:
                t.fontSize = 3;

                t.text = " Question Four: What competing theories do archaeologists have for who created the urns?" +
            "\n1) A nomadic civilization, possibly proto-Hittite, from a distant settlement buried the deceased, then disinterred and reinterred their remains in urns and carried the urns to Padkart Alkmy." +
            "\n2) The urns were created by the Ancient Pamirs or non-nomadic cultures." +
            "\n3) Ancient merchants packed handmade clay urns with tools, herbs, and other supplies as a symbol of wealth, which were found at the ruins of a long-forgotten caravansary" +
            "\n4) They were natural formations created by decades of dripping water" +
            "\n\nA) 1 and 2" +
            "\nB) 1 and 3" +
            "\nX) 3 and 4" +
            "\nY) 2 and 3";
                correct = 1;
                correct2[0] = 2;
                correct2[1] = 4;
                twoCorrect = true;
                break;
            case 4:
                t.fontSize = 2;
                t.text = "Question Five: What is the evidence in support of the theories below?" +
            "\nTheory 1) A nomadic civilization, possibly proto-Hittite, from a distant settlement buried the deceased, then disinterred and reinterred their remains in urns and carried the urns to Padkart Alkmy." +
            "\nTheory 2) The urns were created by the Ancient Pamirs or non-nomadic cultures." +
            "\n1) For 1: Evidence of settlements in the immediate area around Padjart Alkmy, and petroglyphs in the region resemble early representations of the Hazzi mountain God, associated with the proto-Hittite cultures." +
            "\n2) For 1: Zeus told us its true, and as the king of Olympus, we must listen." +
            "\n3) For 2: Perry the Platypus foiled the plans of Dr. Doofenshmirtz, extinguishing the last shred of hope the man had to find happiness." +
            "\n4) For 2: Petroglyphs are still undated, so connection with Hittite cultures is unproven. Ancient Pamirs are believed to have used stone cutting tools, which were found in the urns, and practiced cave painting. These burial practices are not limited to nomadic groups." +
            "\n\nA) 1 and 3" +
            "\nB) 2 and 3" +
            "\nX) 1 and 4" +
            "\nY) 2 and 4";
                correct = 3;
                correct2[0] = 1;
                correct2[1] = 4;
                twoCorrect = true;
                break;
            case (totQuestions):
                t.fontSize = 5;

                t.text = " Congratulations! you scored: " +
            score + "/" + totPoints + "\n Press A to return to the menu";
                quizOver = true;
                break;
        }

        i += 1;

    }


    void rightAnswer()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) && correct == 1 ||
            OVRInput.GetDown(OVRInput.Button.Two) && correct == 2 ||
            OVRInput.GetDown(OVRInput.Button.Three) && correct == 3 ||
            OVRInput.GetDown(OVRInput.Button.Four) && correct == 4)
        {
            if (twoCorrect == true)
            {
                score += 1;
            }
            else
            {
                score += 2;
            }
            nextQ();
        } else if (twoCorrect && (OVRInput.GetDown(OVRInput.Button.One) && (correct2[0] == 1 || correct2[1] == 1)) ||
             (OVRInput.GetDown(OVRInput.Button.Two) && (correct2[0] == 2 || correct2[1] == 2)) ||
             (OVRInput.GetDown(OVRInput.Button.Three) && (correct2[0] == 3 || correct2[1] == 3)) ||
             (OVRInput.GetDown(OVRInput.Button.Four) && (correct2[0] == 4 || correct2[1] == 4)) )
            {
                score += 1;
                nextQ();
            }
            else if (OVRInput.GetDown(OVRInput.Button.One) || OVRInput.GetDown(OVRInput.Button.Two) ||
            OVRInput.GetDown(OVRInput.Button.Three) || OVRInput.GetDown(OVRInput.Button.Four))
            {
                nextQ();
            }

    }
}