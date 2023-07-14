using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroCanvas : MonoBehaviour
{
    public Animator animator1;
    public Animator animator2;
    private GameObject m2w;
    private GameObject jump;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ahihi1");
        m2w = transform.Find("m2wStudio").gameObject;
        m2w.SetActive(true);

        Debug.Log("ahihi");
        jump = transform.Find("Jump4YourLife").gameObject;
        jump.SetActive(true);

        
        animator1 = m2w.GetComponent<Animator>();
        animator2 = jump.GetComponent<Animator>();

        StartCoroutine(Show());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Show()
    {
        Debug.Log("SHOW");
        yield return new WaitForSeconds(0.8f);
        jump.SetActive(true);
        animator2.SetBool("isStarted", true);

        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene("MenuScene");

    }
}
