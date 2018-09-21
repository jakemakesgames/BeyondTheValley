using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {

	[Header("Audio Components")]
	// Master Volume Audio Mixer
	public AudioMixer audioMixer;

	[Header("Resolution Components")]
	public Dropdown resolutionsDropdown;
	// Resolutions Array
	private Resolution[] resolutions;

	void Start(){
		
		resolutions = Screen.resolutions;
		// Clear all of the possible resolution options from the dropdown
		resolutionsDropdown.ClearOptions();

		// Turn the array of resolutions into a list of strings
		List<string> resOptions = new List<string>();

		// Set a current resolution int
		int currentResolutionIndex = 0;
		for (int i = 0; i < resolutions.Length; i++) {
			// for every resolution in the list, create a string with that resolution's width X height
			string resOption = resolutions[i].width + " x " + resolutions[i].height;
			// Add the string to the resOptions list
			resOptions.Add(resOption);

			// if the Ith element of resolutions is equal to the screen's current resolution
			if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) {
				//Set the current resolution index to this
				currentResolutionIndex = i;
			}
		}

		// Add the resolutions from the array into the dropdown field
		resolutionsDropdown.AddOptions(resOptions);
		// Set the resolutionDropdown's value
		resolutionsDropdown.value = currentResolutionIndex;
		// Refresh the shown value
		resolutionsDropdown.RefreshShownValue();

	}

	// SET VOLUME
	public void SetVolume(float mainVolume){
		// Set the main game's volume
		audioMixer.SetFloat("MainVol", mainVolume);
		//Debug.Log("Volume: " + volume);
	}

	// SET THE QUALITY SETTINGS
	public void SetQualitySettings(int qualityIndex){
		// Set the game's quality settings
		QualitySettings.SetQualityLevel(qualityIndex);
	}

	// TOGGLE FULLSCREEN
	public void SetFullscreen (bool isFullscreen){
		Screen.fullScreen = isFullscreen;
	}

	// SET THE WINDOW RESOLUTION
	public void SetResolution(int resolutionIndex){
		Resolution resolution = resolutions [resolutionIndex];
		Screen.SetResolution (resolution.width, resolution.height, Screen.fullScreen);
	}
}
