using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OurLaserPointer : MonoBehaviour {
    public Ray ray;
    public LineRenderer laser;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Vector3 laserVector = this.transform.position + 1000 * this.transform.forward;
        Vector3[] laserArray = new Vector3[2] { transform.position, laserVector };
        laser.SetPositions(laserArray);

        
            ray = new Ray(this.transform.position, this.transform.forward);
            Physics.Raycast(transform.position, transform.forward);
            laser.enabled = true;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider != null)
                {
                    Debug.Log(hit.collider.gameObject.name);
                    if (OVRInput.Get(OVRInput.Button.One))
                { 
                    if (hit.collider.gameObject.name == "start")
                    {
                        SceneManager.LoadScene("intro");
                    } else if (hit.collider.gameObject.name == "quit")
                    {

#if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
                        }
                    }

                }
            }
        }           
}
