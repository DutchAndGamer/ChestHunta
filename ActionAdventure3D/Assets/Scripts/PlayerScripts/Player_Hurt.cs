using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Hurt : MonoBehaviour 
{
    public GameObject hurtCanvas;
    private Player_Master playerMaster;
    private float secondsTillHide = 2;
    public Image image;

    void OnEnable () 
	{
        SetInitialReferences();
        playerMaster.EventPlayerHealthDeduction += TurnOnHurtEffect;

    }
	
	void OnDisable () 
	{
        playerMaster.EventPlayerHealthDeduction -= TurnOnHurtEffect;
    }
	
	void SetInitialReferences () 
	{
        playerMaster = GetComponent<Player_Master>();

    }

    void TurnOnHurtEffect(int dummy)
    {
        if(hurtCanvas != null)
        {
            StopAllCoroutines();
            hurtCanvas.SetActive(true);
            image.GetComponent<Image>().canvasRenderer.SetAlpha(1f);
            image.GetComponent<Image>().CrossFadeAlpha(0.1f, secondsTillHide, false);
            StartCoroutine(ResetHurtCanvas());
        }
    }

    IEnumerator ResetHurtCanvas()
    {
        yield return new WaitForSeconds(secondsTillHide);
    }
}
