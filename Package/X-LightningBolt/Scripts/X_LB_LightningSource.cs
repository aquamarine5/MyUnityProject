

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEditor;
[System.Serializable]

public class X_LB_LightningSource : MonoBehaviour {

	public float loopRate { get; set; }

	int numberOfSegmentsInPool = 50;
	int numberOfBranchesInPool = 50;

	public Texture textureNormal { get; set; }
	public Texture textureFade { get; set; }
	public Texture textureThin { get; set; }
	public Texture textureDark { get; set; }

	public Transform pool { get; set; }
	public Transform poolBranches { get; set; }
	public Renderer gizmo {get; set;}

	public ArrayList allSegmentsInPool = new ArrayList();
	public ArrayList allBranchesInPool = new ArrayList();
	public ArrayList allBolts = new ArrayList();

	GameObject segmentPrefab;
	GameObject branchPrefab;
	GameObject boltPrefab;

	X_LB_Segment[] allSegmentsTogether;
	X_LB_Branch[] allBranchesTogether;
	X_LB_Bolt[] allBoltsInit;

	public float branchCreationMoment {get; set;}

	float minNumberOfSegments = 2;
	public float impactTimeForOne { get; set; }

	bool striking = false;

	AudioSource sound;
	X_LB_Sounds sounds;
	Light mainLight;

	//cached vars (striking loop)
	Transform startingPoint;
	int currentTargetNumber;
	Transform currentTarget;
	X_LB_Bolt currentBolt;
	float distanceToTarget;
	float numberOfSegmentsFloat;
	int numberOfSegments;
	int numberOfSegmentsActive;
	int numberOfSegmentsMissing;
	X_LB_Segment currentSegmentOutOfPool;
	X_LB_Segment currentSegmentOutOfBolt;
	Vector3 endPosition;
	X_LB_Segment currentSegment;
	X_LB_Bolt lastBoltForEndCap;
	X_LB_Segment lastSegmentForEndCap;
	Vector3 chainSpace;
	Vector3 chainPoint;
	Vector3 flickerOffset;
	float segmentCount;
	Vector3[] chainPoints;
	Vector3[] flickeringOffsets;

	public enum Presets {
		cartoonEnergyStream,
		cartoonImpactBolt,
		cartoonFeralBolt,
		realisticLightning,
		CUSTOM
	}

	//save custom before choosing presets
	Color savedColor;
	bool savedThinStyle;
	bool savedDarkStyle;
	bool savedFadeEffect;
	bool savedLightEffect;
	float savedLightSize;
	bool savedFreezeShape;
	float savedSegmentSize;
	float savedFlickeringStrength;
	float savedSteramingSpeed;
	float savedBranchAmount;
	Presets oldPreset;

	//Inspector for custom editor	
	public bool strike = false;
	public bool strikeBool = false;
	public bool strikeRandomly = false;
	public int strikeRandomlyRate;
	public List <Transform> targets;
	public List <string> callMethodOnImpact;
	public List <bool> callMethodOnImpactBool;
	public bool soundOn = false;
	public bool autoplayStrikeOn = false;
	public Presets presets;
	public Color color;
	public bool thinStyle = false;
	public bool darkStyle = false;
	public bool fadeEffect = true;
	public float lightSize;
	public float segmentSize;
	public float flickeringStrength;
	public float streamingSpeed;
	public float branchAmount;
	public bool freezeShape = false;
	public int framerate;
	//


	void OnDrawGizmos() {

		Gizmos.color = color;
		//Gizmos.DrawIcon(transform.position, "gizmo.png", true);
		Gizmos.color = color;
		Vector3 from = transform.position;
		for (int a = 0; a < targets.Count; a++) {
			if (targets [a] == null) {
				continue;
			}
			Gizmos.DrawLine (from, targets [a].position);
			from = targets [a].position;
		}
		//Gizmos.DrawWireSphere (transform.position, transform.localScale.x);

	}


	// Use this for initialization
	void Awake () {

		impactTimeForOne = 0.1f;
		branchCreationMoment = 10f;

		LoadTextures ();

		pool = transform.Find ("Pool");
		poolBranches = transform.Find ("PoolBranches");
		sound = transform.Find ("Sound").GetComponent<AudioSource> ();
		sounds = transform.Find ("Sound").GetComponent<X_LB_Sounds> ();
		sounds.Init (sound);
		mainLight = transform.Find ("Light").GetComponent<Light> ();

		gizmo = transform.Find ("Gizmo").GetComponent<Renderer> ();
		gizmo.enabled = false;

		segmentPrefab = (GameObject)Resources.Load("X-LightningBolt/X_LB_LightningSegmentPrefab");
		branchPrefab = (GameObject)Resources.Load("X-LightningBolt/X_LB_LightningBranchPrefab");
		boltPrefab = (GameObject)Resources.Load("X-LightningBolt/X_LB_LightningBoltPrefab");

		//fill up pool of segments
		for (int i = 0; i < numberOfSegmentsInPool; i++) {
			GameObject newSegment = (GameObject)Instantiate(segmentPrefab, transform.position, transform.rotation);
			newSegment.transform.parent = pool;
			newSegment.transform.localScale = new Vector3(1f,1f,1f);
		}
		//fill up pool of branches
		for (int i = 0; i < numberOfBranchesInPool; i++) {
			GameObject newBranch = (GameObject)Instantiate(branchPrefab, transform.position, transform.rotation);
			newBranch.transform.parent = pool;
			newBranch.transform.localScale = new Vector3(2.4f,2.4f,2.4f);
		}
		//create bolt parts for each target
		for (int j = 0; j < targets.Count; j++) {
			GameObject newBolt = (GameObject)Instantiate(boltPrefab, transform.position, transform.rotation);
			newBolt.name = "BoltPart"+j;
			newBolt.transform.parent = transform;
			allBolts.Add(newBolt.GetComponent<X_LB_Bolt>());
			newBolt.transform.localScale = new Vector3(1,1,1);
		}

		flickeringOffsets = new Vector3[0];

		allSegmentsTogether = GetComponentsInChildren<X_LB_Segment> ();
		allBranchesTogether = GetComponentsInChildren<X_LB_Branch> ();
		allBoltsInit = GetComponentsInChildren<X_LB_Bolt> ();

		for (int s = 0; s < allSegmentsTogether.Length; s++) {	
			allSegmentsTogether[s].Initialize(this);
		}
		for (int br = 0; br < allBranchesTogether.Length; br++) {	
			allBranchesTogether[br].Initialize(this);
		}
		for (int bo = 0; bo < allBoltsInit.Length; bo++) {
			allBoltsInit[bo].Initialize(this);
		}

		GetPresetValues (presets);

		StartCoroutine (SaveCustomValues ());
		StartCoroutine (StrikeLoop ());

		//Autoplay
		if (autoplayStrikeOn == true) {
			StrikeOnce ();
		}

	}

	void LoadTextures() {
		textureNormal = (Texture)Resources.Load ("X-LightningBolt/Textures/X_LB_Segment");
		textureFade = (Texture)Resources.Load ("X-LightningBolt/Textures/X_LB_SegmentFade");
		textureThin = (Texture)Resources.Load ("X-LightningBolt/Textures/X_LB_SegmentThin");
		textureDark = (Texture)Resources.Load ("X-LightningBolt/Textures/X_LB_SegmentDark");
	}

	IEnumerator SaveCustomValues() {

		YieldInstruction loop = new WaitForSeconds(0);

		//save first
		savedColor = color;
		savedThinStyle = thinStyle;
		savedDarkStyle = darkStyle;
		savedFadeEffect = fadeEffect;
		savedLightSize = lightSize;
		savedFreezeShape = freezeShape;
		savedSegmentSize = segmentSize;
		savedFlickeringStrength = flickeringStrength;
		savedSteramingSpeed = streamingSpeed;
		savedBranchAmount = branchAmount;

		while (true) {

			loop = new WaitForSeconds (1f / (float)framerate);

			if (presets != oldPreset) {
				if (presets == Presets.CUSTOM) {
					color = savedColor;
					thinStyle = savedThinStyle;
					darkStyle = savedDarkStyle;
					fadeEffect = savedFadeEffect;
					lightSize = savedLightSize;
					freezeShape = savedFreezeShape;
					segmentSize = savedSegmentSize;
					flickeringStrength = savedFlickeringStrength;
					streamingSpeed = savedSteramingSpeed;
					branchAmount = savedBranchAmount;
				}
				else {
					if (oldPreset == Presets.CUSTOM) {
						savedColor = color;
						savedThinStyle = thinStyle;
						savedDarkStyle = darkStyle;
						savedFadeEffect = fadeEffect;
						savedLightSize = lightSize;
						savedFreezeShape = freezeShape;
						savedSegmentSize = segmentSize;
						savedFlickeringStrength = flickeringStrength;
						savedSteramingSpeed = streamingSpeed;
						savedBranchAmount = branchAmount;
					}
				}
				if (presets != Presets.CUSTOM) {
					GetPresetValues(presets);
				}
			}
			oldPreset = presets;
			yield return loop;
		}
		
	}

	void GetPresetValues(Presets preset) {
		X_LB_SavedPresets.GetPresetValues (this, "color", preset.ToString());
		X_LB_SavedPresets.GetPresetValues (this, "thinStyle", preset.ToString());
		X_LB_SavedPresets.GetPresetValues (this, "darkStyle", preset.ToString());
		X_LB_SavedPresets.GetPresetValues (this, "fadeEffect", preset.ToString());
		X_LB_SavedPresets.GetPresetValues (this, "lightSize", preset.ToString());
		X_LB_SavedPresets.GetPresetValues (this, "freezeShape", preset.ToString());
		X_LB_SavedPresets.GetPresetValues (this, "segmentSize", preset.ToString());
		X_LB_SavedPresets.GetPresetValues (this, "flickeringStrength", preset.ToString());
		X_LB_SavedPresets.GetPresetValues (this, "streamingSpeed", preset.ToString());
		X_LB_SavedPresets.GetPresetValues (this, "branchAmount", preset.ToString());
	}

	public void UpdateTargetsList() {

		//update bolts for each target list, fill up for missing
		int boltsMissing = targets.Count - allBolts.Count;
		if (boltsMissing > 0) {
			for (int j = 0; j < boltsMissing; j++) {
				GameObject newBolt = (GameObject)Instantiate (boltPrefab, transform.position, transform.rotation);
				newBolt.name = "BoltPart" + j;
				newBolt.transform.parent = transform;
				allBolts.Add (newBolt.GetComponent<X_LB_Bolt> ());
				newBolt.GetComponent<X_LB_Bolt>().Initialize (this);
			}
		}
		//clear segments from redundant bolts
		if (boltsMissing < 0) {
			for (int e = allBolts.Count-1; e > targets.Count-1; e--) {
				X_LB_Bolt current = (X_LB_Bolt)allBolts[e];
				current.ClearSegments();
			}
		}

	}

	public void StrikeOnce() {
		if (Application.isPlaying) {
			strike = true;
			StartCoroutine (EndStrike (impactTimeForOne));
			if (soundOn == true) {
				if (strikeRandomly == false) {
					sounds.PlaySound(sounds.soundImpact);
				}
				else {
					sounds.PlayRandomSound(sounds.soundsFlicker);
				}
			}
		} else {
			Debug.Log ("Use lightning source only in play mode");
		}

	}
	public void Strike() {
		if (Application.isPlaying) {
			strike = !strike;
			if (strike == true && soundOn) {
				sounds.PlayStreamSound();
			} 
		} else {
			Debug.Log ("Use lightning source only in play mode");
		}
		strikeBool = strike;
	}
	public void StrikeRandomly() {
		if (Application.isPlaying) {
			strikeRandomly = !strikeRandomly;
		} else {
			Debug.Log ("Use lightning source only in play mode");
		}
	}

	IEnumerator EndStrike(float after) {
		yield return new WaitForSeconds(after);
		striking = false;
		strike = false;
		strikeBool = false;
		sounds.StopStreamSound();
		mainLight.enabled = false;
		flickeringOffsets = new Vector3[0];
		for (int i = 0; i < allBolts.Count; i++) {
			X_LB_Bolt currentBolt = (X_LB_Bolt)allBolts[i];
			X_LB_Segment[] segmentsToClean = currentBolt.transform.GetComponentsInChildren<X_LB_Segment>();
			for (int j = 0; j < segmentsToClean.Length; j++) {
				segmentsToClean[j].Disappear(currentBolt, fadeEffect);
			}
		}
	}

	IEnumerator StrikeLoop() {

		YieldInstruction loop = new WaitForSeconds(0);

		while (true) {

			loop = new WaitForSeconds (1f / (float) framerate);

			//Strike normally
			if (strike) {
				StrikeAction ();
				sounds.BalanceStreamSound(branchAmount);
				sounds.PitchStreamSound(flickeringStrength);
			} else {
				if (striking == true) {
					StartCoroutine (EndStrike (0));								
				}
			}
			//Strike randomly
			if (strikeRandomly) {
				if (Random.Range (0, strikeRandomlyRate) == 0) {
					if (soundOn == true) {
						sounds.PlayRandomSound(sounds.soundsFlicker);
					}
					StrikeOnce ();
				}
			}

			//Segments Loop
			for (int i = 0; i < allSegmentsTogether.Length; i++) {
				if (allSegmentsTogether[i].gameObject.activeInHierarchy == true) {
					allSegmentsTogether[i].LateLoop();
				}
			}

			//Branches Loop
			for (int i = 0; i < allBranchesTogether.Length; i++) {
				if (allBranchesTogether[i].gameObject.activeInHierarchy == true) {
					allBranchesTogether[i].LateLoop();
				}
			}

			yield return loop;

		}
	}

	public void StrikeAction() {

		//first: update targets
		//it's a realtime parameter!
		UpdateTargetsList ();

		//The action
		striking = true;

		if (lightSize > 0) {
			mainLight.enabled = true;
			mainLight.color = color;
			mainLight.range = lightSize;
		} else {
			mainLight.enabled = false;
		}

		if (targets.Count == 0) {
			return;
		}

		startingPoint = transform;

		for (int h = 0; h < targets.Count; h++) {

			//create one bolt with several segments from one target	to another
			currentTarget = targets[h];
			currentBolt = (X_LB_Bolt)allBolts[h];

			if (currentTarget == null) {
				currentBolt.ClearSegments();
				continue;
			}

			//Call method on impact, that's what a lightning is for
			if (callMethodOnImpactBool[h] == true) {
				targets[h].gameObject.SendMessage(callMethodOnImpact[h], SendMessageOptions.DontRequireReceiver);
			}

			//get number of segments for bolt part
			distanceToTarget = Calculator.X_LB_Math.Sqrt2((startingPoint.position - currentTarget.position).sqrMagnitude);

			numberOfSegmentsFloat = distanceToTarget / segmentSize;
			//catch no segment case
			if (numberOfSegmentsFloat < minNumberOfSegments) {
				numberOfSegmentsFloat = minNumberOfSegments;
			}
			numberOfSegments = (int)Mathf.Round (numberOfSegmentsFloat);

			numberOfSegmentsActive = currentBolt.allSegmentsInBolt.Count;
			numberOfSegmentsMissing = numberOfSegments - numberOfSegmentsActive;

			if (numberOfSegmentsMissing > 0) {
				for (int i = 0; i < numberOfSegmentsMissing; i++) {
					//too little segments active, put some into the bolt
					if (allSegmentsInPool.Count > 0) {
						currentSegmentOutOfPool = (X_LB_Segment)allSegmentsInPool [0];
						currentSegmentOutOfPool.FromPoolInBolt (currentBolt);
					}
				}
			}
			if (numberOfSegmentsMissing < 0) {
				for (int j = 0; j < -numberOfSegmentsMissing; j++) {
					//too many segments active, put them back in pool
					currentSegmentOutOfBolt = (X_LB_Segment)currentBolt.allSegmentsInBolt [0];
					currentSegmentOutOfBolt.FromBoltInPool (currentBolt);
				}
			}

			//before positioning the segments: set an array of chain points for this bolt and flickering offsets
			chainPoints = new Vector3[currentBolt.allSegmentsInBolt.Count+1]; // +1 because is has 5 chain points per bolt with 4 segments
			for (int e = 0; e < chainPoints.Length; e++) {
				segmentCount = currentBolt.allSegmentsInBolt.Count;
				chainSpace = (currentTarget.position - startingPoint.position) / segmentCount;
				chainPoint = startingPoint.position + e * chainSpace;
				chainPoints[e] = chainPoint;
			}
			if ((flickeringOffsets.Length == 0 && freezeShape == true) || freezeShape == false) {
				flickeringOffsets = new Vector3[currentBolt.allSegmentsInBolt.Count+1];
				for (int f = 0; f < flickeringOffsets.Length; f++) {
					flickerOffset = GetFlickerOffset();
					if (f == 0 || f == chainPoints.Length - 1) {
						flickerOffset = Vector3.zero;
					}
					flickeringOffsets[f] = flickerOffset;
				}
			}
			//now positioning all segments of one bolt regarding the chain points
			for (int k = 0; k < currentBolt.allSegmentsInBolt.Count; k++) {
				currentSegment = (X_LB_Segment)currentBolt.allSegmentsInBolt [k];
				//position start
				currentSegment.SetChainPositioner (chainPoints[k] + flickeringOffsets[k]);
				//position end
				currentSegment.SetEndingPoint (chainPoints[k+1] + flickeringOffsets[k+1]);
				currentSegment.target = currentTarget;
				currentSegment.point2.localScale = Vector3.one;
			}
			//end point is starting point for next bolt/target
			startingPoint = currentTarget;
		}

		//end cap of the whole lightning
		if (allBolts.Count > 0) {
			lastBoltForEndCap = (X_LB_Bolt)allBolts [allBolts.Count - 1];
			if (lastBoltForEndCap.allSegmentsInBolt.Count > 0) {
				lastSegmentForEndCap = (X_LB_Segment)lastBoltForEndCap.allSegmentsInBolt [lastBoltForEndCap.allSegmentsInBolt.Count - 1];
				lastSegmentForEndCap.point2.transform.localScale = new Vector3 (.5f, .5f, .5f);
			}
		}

	}

	Vector3 GetFlickerOffset() {
		Vector3 newFlickerOffset;
		float fs = flickeringStrength;
		float flickerOffset1 = Random.Range (-fs, fs);
		float flickerOffset2 = Random.Range (-fs, fs);
		float flickerOffset3 = Random.Range (-fs, fs);
		newFlickerOffset = new Vector3 (flickerOffset1, flickerOffset2, flickerOffset3);
		return newFlickerOffset;
	}

}


