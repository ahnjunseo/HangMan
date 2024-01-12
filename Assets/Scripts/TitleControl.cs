using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleControl : MonoBehaviour
{
    [SerializeField] private TMP_Text titleTmp;
    [SerializeField] private TMP_Text pressTmp;
    [SerializeField] private GameObject image;
    private bool canMove = false;

    void Start()
    {
        StartCoroutine(TitleType());
    }

    private IEnumerator TitleType()
    {
        yield return new WaitForSeconds(0.6f);
        titleTmp.text = "____ ___";
        yield return new WaitForSeconds(0.3f);
        titleTmp.text = "_A__ _A_";
        yield return new WaitForSeconds(0.3f);
        titleTmp.text = "HA__ _A_";
        yield return new WaitForSeconds(0.3f);
        titleTmp.text = "HAN_ _AN";
        yield return new WaitForSeconds(0.3f);
        titleTmp.text = "HAN_ MAN";
        yield return new WaitForSeconds(0.3f);
        titleTmp.text = "HANG MAN";
        yield return new WaitForSeconds(0.3f);
        image.SetActive(true);
        pressTmp.gameObject.SetActive(true);
        canMove = true;
        while (true)
        {
            pressTmp.color = new Color(0, 0, 0, (1 - 0.8f * Mathf.Sin(3f * Time.time)) / 1.8f);
            yield return new WaitForSeconds(0.02f);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canMove) 
        {
            SceneManager.LoadScene("Game");
        }
    }



}
