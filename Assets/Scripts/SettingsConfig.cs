using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsConfig : MonoBehaviour {

	public Toggle EnableCamera;
	public Toggle EnableIndicator;

	private void Start() {
		if (PlayerPrefs.GetInt("EnableCamera") == 1) {
			EnableCamera.isOn = true;	
		} else {
			EnableCamera.isOn = false;
		}
		if (PlayerPrefs.GetInt("EnableIndicator") == 1) {
			EnableIndicator.isOn = true;	
		} else {
			EnableIndicator.isOn = false;
		}
	}
	
	private void Update() {
		if (EnableCamera.onValueChanged != null) {
			if (EnableCamera.isOn) {
				PlayerPrefs.SetInt("EnableCamera", 1);
			} else {
				PlayerPrefs.SetInt("EnableCamera", 0);
			}
		}
		if (EnableIndicator.onValueChanged != null) {
			if (EnableIndicator.isOn) {
				PlayerPrefs.SetInt("EnableIndicator", 1);
			} else {
				PlayerPrefs.SetInt("EnableIndicator", 0);
			}
		}
	}


}
