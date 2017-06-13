using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class panelControl : MonoBehaviour {
	public Button exitPanel;
	public GameObject panel;
	public float timePanel;
	public Vector3 panelOrigin;
	public Image exitImage;
	private managerMenu menu;
	// Use this for initialization
	void Start () {
		panelOrigin = panel.transform.localPosition;
		exitImage = exitPanel.gameObject.GetComponent<Image>();
		menu=GameObject.FindObjectOfType<managerMenu>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void enablePanel(){

		panel.transform.DOLocalMove(Vector3.zero,timePanel);
		menu.clickSFX();
		exitImage.gameObject.SetActive(true);
		exitImage.DOFade(0.4f,timePanel).OnComplete(() => {
			exitPanel.interactable=true;
		}	
		);
	}

	public void disablePanel(){
		menu.clickSFX();
		panel.transform.DOLocalMove(panelOrigin,timePanel);
		exitImage.DOFade(0,timePanel).OnComplete(() => {
			exitPanel.interactable=false;
			exitImage.gameObject.SetActive(false);
		}	
		);
	}
}
