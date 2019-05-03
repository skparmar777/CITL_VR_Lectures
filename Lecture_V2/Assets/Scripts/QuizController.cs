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
    public Ray ray;
    public LineRenderer laser;
    public short inp;
    public bool go = false;
    public GameObject pointer;
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
        RaycastHit hit;
        Vector3 laserVector = pointer.transform.position + 1000 * pointer.transform.forward;
        Vector3[] laserArray = new Vector3[2] { pointer.transform.position, laserVector };
        laser.SetPositions(laserArray);

        go = false;
        ray = new Ray(pointer.transform.position, pointer.transform.forward);
        Physics.Raycast(pointer.transform.position, pointer.transform.forward);
        laser.enabled = true;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                if (OVRInput.GetDown(OVRInput.Button.One))
                {
                    if (hit.collider.gameObject.name == "A")
                    {
                        inp = 1;
                        go = true;
                    }
                    else if (hit.collider.gameObject.name == "B")
                    {
                        inp = 2;
                        go = true;
                    }
                    else if (hit.collider.gameObject.name == "X")
                    {
                        inp = 3;
                        go = true;
                    }
                    else if (hit.collider.gameObject.name == "Y")
                    {
                        inp = 4;
                        go = true;
                    }
                }

            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            return;
        }
        if (i <= totQuestions && go == true)
        {
            rightAnswer(inp);
        }
        if (quizOver && OVRInput.GetDown(OVRInput.Button.Four))
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
            "\nY) Ceremonial objects and rare sediment";
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
            "\n2) For 1: Ancient maps, etched into stone, have been discovered near the digsite.  These maps were likely used by nomadic civilizations to track wild game." +
            "\n3) For 2: Ancient Pamirs are known to be skilled fisherman, using intricately fashioned tools such as copper fishing hooks and stone spearheads.  Examples of these were found at the burial site, approximately 4km from the Indian Ocean." +
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
            score + "/" + totPoints + "\n Press Y to return to the menu";
                quizOver = true;
                break;
        }

        i += 1;
        StartCoroutine(waiting());

    }

    IEnumerator waiting()
    {
        yield return new WaitForSeconds(5);
    }


    void rightAnswer(short inp)
    {
        if (inp == correct)
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
        } else if (inp == correct2[0] && inp == correct2[1])
            {
                score += 1;
                nextQ();
            }
            else
            {
                nextQ();
            }

    }
}