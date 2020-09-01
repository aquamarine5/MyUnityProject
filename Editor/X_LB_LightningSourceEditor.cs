
using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Reflection;

[CustomEditor(typeof(X_LB_LightningSource), true)]

public class X_LB_LightningSourceEditor : Editor {

	public Object insertTargetToArray;

	public override void OnInspectorGUI() {
		X_LB_LightningSource ls = (X_LB_LightningSource)target;

		//Editor

		EditorGUILayout.LabelField ("AUTOPLAY");
		ls.autoplayStrikeOn = EditorGUILayout.ToggleLeft ("Autoplay Strike", ls.autoplayStrikeOn);

		EditorGUILayout.LabelField ("ACTIONS");
		if (GUILayout.Button("Strike Once")) {
			ls.StrikeOnce();
		}
		string r = "Strike";
		if (ls.strikeBool) {
			r = "✓ Strike";
		}
		if (GUILayout.Button(r)) {
			ls.Strike();
		}
		string se = "Strike Randomly";
		if (ls.strikeRandomly) {
			se = "✓ Strike Randomly";
		}
		if (GUILayout.Button(se)) {
			ls.StrikeRandomly();
		}
		if (ls.strikeRandomly == true) {
			ls.strikeRandomlyRate = 55 - EditorGUILayout.IntSlider ("Randomly rate", ls.strikeRandomlyRate, 5, 50);
		}

		EditorGUILayout.Space ();

		//TARGETS
		EditorGUILayout.LabelField ("TARGETS");

		if (ls.targets.Count == 0) {
			EditorGUILayout.HelpBox ("Lightning can not be executed: No targets assigned!", MessageType.Warning);
		} else {
			for (int i = 0; i < ls.targets.Count; i++) {
				Object currentObject = (Object)ls.targets [i];
				currentObject = EditorGUILayout.ObjectField (currentObject, typeof(Transform), true);
				ls.targets [i] = (Transform)currentObject;
				string currentMethod = (string)ls.callMethodOnImpact[i];
				if (ls.callMethodOnImpactBool[i] == false) {
					ls.callMethodOnImpactBool[i] = EditorGUILayout.ToggleLeft ("Call method on impact", ls.callMethodOnImpactBool[i]);
					if (currentMethod == "") {
						currentMethod = "(No method)";
					}
				}
				else {
					if (currentMethod == "") {
						ls.callMethodOnImpactBool[i] = false;
					}
					currentMethod =  EditorGUILayout.TextField ("Call method: ", currentMethod);
				}
				ls.callMethodOnImpact[i] = (string)currentMethod;
				EditorGUILayout.Space ();
			}
			if (GUILayout.Button ("Remove last target")) {
				if (ls.targets.Count > 0) {
					ls.targets.RemoveAt(ls.targets.Count-1);
					ls.callMethodOnImpact.RemoveAt(ls.callMethodOnImpact.Count-1);
					ls.callMethodOnImpactBool.RemoveAt(ls.callMethodOnImpactBool.Count-1);
				}
			}
		}
		if (GUILayout.Button ("Add new target")) {
			if (ls.targets.Count < 100) {
				ls.targets.Add (null);
				ls.callMethodOnImpact.Add ("");
				ls.callMethodOnImpactBool.Add(false);
			}
		}			

		EditorGUILayout.Space ();

		//PERFORMANCE
		EditorGUILayout.LabelField ("PERFORMANCE");
		ls.framerate = EditorGUILayout.IntSlider ("Framerate", ls.framerate, 10, 60);

		EditorGUILayout.Space ();

		//SOUND
		EditorGUILayout.LabelField ("SOUND");
		ls.soundOn = EditorGUILayout.ToggleLeft ("Sound On", ls.soundOn);

		EditorGUILayout.Space ();

		//STYLE
		EditorGUILayout.LabelField ("STYLE");
		ls.presets = (X_LB_LightningSource.Presets)EditorGUILayout.EnumPopup (ls.presets);

		EditorGUILayout.Space ();

		if (ls.presets == X_LB_LightningSource.Presets.CUSTOM) {
			//CUSTOMIZE
			ls.color = EditorGUILayout.ColorField ("Color", ls.color);
			ls.thinStyle = EditorGUILayout.Toggle ("Thin Style", ls.thinStyle);
			ls.darkStyle = EditorGUILayout.Toggle ("Dark Style", ls.darkStyle);
			ls.fadeEffect = EditorGUILayout.Toggle ("Fade Effect", ls.fadeEffect);
			ls.freezeShape = EditorGUILayout.Toggle ("Freeze Shape", ls.freezeShape);
			ls.lightSize = EditorGUILayout.Slider ("Light Size", ls.lightSize, 0f, 100f);
			ls.segmentSize = EditorGUILayout.Slider ("Segment Size", ls.segmentSize, 1f, 20f);
			ls.flickeringStrength = EditorGUILayout.Slider ("Flickering Strength", ls.flickeringStrength, 0, 5);
			ls.streamingSpeed = EditorGUILayout.Slider ("Streaming Speed", ls.streamingSpeed, 0, 10);
			ls.branchAmount = EditorGUILayout.Slider ("Branch Amount", ls.branchAmount, 0, 50);
			EditorGUILayout.Space ();

			//restrict impossible style combination
			if (ls.darkStyle && ls.thinStyle) {
				ls.darkStyle = false;
				ls.thinStyle = false;
			}
		}

		//INFO
		EditorGUILayout.Space ();
		if (GUILayout.Button ("Need help? Get it here quickly.")) {
			Application.OpenURL ("http://www.game-x.ch/Assets/lightningBoltTest.html");
		}
		EditorGUILayout.HelpBox ("Asset by Game Expressions! - www.game-x.ch", MessageType.None);
		EditorGUILayout.HelpBox ("You'd help us a lot if you write a review, it pushes our asset, wich pushes your game. Thank you!", MessageType.None);

		if(GUI.changed)
			EditorUtility.SetDirty(ls);    

	}

}



