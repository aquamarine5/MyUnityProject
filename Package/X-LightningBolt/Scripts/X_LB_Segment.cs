using UnityEngine;
using System.Collections;

public class X_LB_Segment : MonoBehaviour {

	public Transform point1 { get; set; }
	public Transform point2 { get; set; }

	Light lamp;

	X_LB_LightningSource lightningSource;

	Vector3 chainPositioner;
	public Vector3 endingPoint { get; set; }
	public Transform target { get; set; }

	public bool flickeringOk { get; set; }

	bool fading = false;

	Material material;
	Texture textureStyle;

	float fadeLengthMultiplier = 3f;

	public ArrayList allBranchesInSegment = new ArrayList();
	float branchCreationCounter;

	Vector3 flickerOffset = Vector3.zero;

	//cached vars
	float fs;
	float flickerOffset1;
	float flickerOffset2;
	float flickerOffset3;
	float segmentLength;
	float randomPointBranch;
	Vector3 randomPositionBranch;
	float fadeTime;
	X_LB_Branch currentBranchOutOfPool;
	Color oldColor;
	bool oldThinStyle;
	float oldLightSize;
	bool oldDarkStyle;

	// Use this for initialization
	public void Initialize (X_LB_LightningSource lightningSource) {

		this.lightningSource = lightningSource;

		point1 = transform.Find ("point1");
		point2 = transform.Find ("point1/point2");
		material = GetComponentInChildren<Renderer> ().material;
		lamp = transform.GetComponentInChildren<Light> ();

		branchCreationCounter = Random.Range (0, lightningSource.branchCreationMoment);

		Coloring ();
		Drawing ();

		InPool ();

	}

	public void LateLoop() {
		if (fading == false) {
			Positioning();
			CheckColoring();
			CheckDrawing();
			Streaming();
			Branching();
		}
	}

	void CheckColoring() {
		if ((oldColor != lightningSource.color) || oldLightSize != lightningSource.lightSize) {
			Coloring ();
		}
		oldColor = lightningSource.color;
		oldLightSize = lightningSource.lightSize;
	}

	void CheckDrawing() {
		if (oldThinStyle != lightningSource.thinStyle || oldDarkStyle != lightningSource.darkStyle) {
			Drawing ();
		}
		oldThinStyle = lightningSource.thinStyle;
		oldDarkStyle = lightningSource.darkStyle;
	}

	void Coloring() {
		material.color = new Color (lightningSource.color.r, lightningSource.color.g, lightningSource.color.b, 1);
		if (lightningSource.lightSize > 0) {
			lamp.enabled = true;
			lamp.range = lightningSource.lightSize;
			lamp.color = lightningSource.color;
		} else {
			lamp.enabled = false;
		}
	}

	void Drawing() {
		if (lightningSource.thinStyle == true) {
			textureStyle = lightningSource.textureThin;
		} else {
			textureStyle = lightningSource.textureNormal;
		}
		if (lightningSource.darkStyle) {
			textureStyle = lightningSource.textureDark;
		} 
		material.mainTexture = textureStyle;
	}

	void InPool() {
		transform.parent = lightningSource.pool;
		lightningSource.allSegmentsInPool.Add (this);
		gameObject.SetActive (false);
	}

	public void FromPoolInBolt(X_LB_Bolt currentBolt) {

		transform.parent = currentBolt.transform;
		if (lightningSource.allSegmentsInPool.Contains(this)) {
			lightningSource.allSegmentsInPool.Remove (this);
		}
		currentBolt.allSegmentsInBolt.Add (this);
		gameObject.SetActive (true);
		Prepare();
	}

	public void FromBoltInPool(X_LB_Bolt currentBolt) {
		transform.parent = lightningSource.pool;
		if (currentBolt.allSegmentsInBolt.Contains(this)) {
			currentBolt.allSegmentsInBolt.Remove (this);
		}
		lightningSource.allSegmentsInPool.Add (this);
		gameObject.SetActive (false);

	}

	public void SetEndingPoint(Vector3 endingPoint) {
		this.endingPoint = endingPoint;
	}

	public void SetChainPositioner(Vector3 chainPositioner) {
		this.chainPositioner = chainPositioner;
	}

	void Prepare() {
		Coloring();
		Drawing();
		Positioning ();
	}

	public void Positioning() {
		if (chainPositioner != null) {
			transform.position = chainPositioner;
		}
		if (endingPoint != null && target) {
			transform.LookAt(target.position);
			transform.rotation *= Quaternion.Euler(0,90,0);
			point2.transform.position = endingPoint;
			point2.transform.localEulerAngles = Vector3.zero;
		}
	}

	void Streaming() {
		material.mainTextureOffset += new Vector2 (lightningSource.streamingSpeed /100f * Time.deltaTime * 100f, 0);
	}
	
	void Branching() {
		//counter: more bolts in settings and longer line increase spawing speed (visually balanced)
		segmentLength = Vector3.Distance (point1.position, point2.position);
		branchCreationCounter += Time.deltaTime * lightningSource.branchAmount * segmentLength;		
		if (branchCreationCounter > lightningSource.branchCreationMoment) {
			branchCreationCounter = 0;
			if (lightningSource.allBranchesInPool.Count > 0) {
				CreateBranch();
			}
		}
	}
	
	void CreateBranch() {		
		//Choose Position randomly on segments line
		randomPointBranch = Random.Range (0f, 1f);
		randomPositionBranch = point1.position + (point2.position - point1.position) * randomPointBranch;
		//take branch out of Pool
		currentBranchOutOfPool = (X_LB_Branch)lightningSource.allBranchesInPool [0];
		currentBranchOutOfPool.FromPoolInSegment (this);
		currentBranchOutOfPool.transform.position = randomPositionBranch;
		currentBranchOutOfPool.transform.LookAt (point2);		
		currentBranchOutOfPool.transform.rotation *= Quaternion.Euler (0, 90, 0);
		currentBranchOutOfPool.transform.Rotate (Random.Range (-10f, 10f), Random.Range (-10f, 10f), Random.Range (-10f, 10f));
	}

	public void Disappear(X_LB_Bolt currentBolt, bool fadeEffect) {
		fadeTime = 0;
		if (fadeEffect == true) {
			fadeTime = lightningSource.impactTimeForOne*fadeLengthMultiplier;	
		}
		StartCoroutine (Fade (currentBolt, fadeTime));
	}

	IEnumerator Fade(X_LB_Bolt currentBolt, float fadeTime) {
		if (fadeTime > 0) {
			GoFading ();
			while (fadeTime > 0) {
				fadeTime -= Time.deltaTime;
				material.color = new Color(material.color.r,material.color.g,material.color.b,fadeTime/(lightningSource.impactTimeForOne*fadeLengthMultiplier));
				yield return 0;
			}
			EndFading ();
		}			
		FromBoltInPool (currentBolt);
	}

	void GoFading() {
		fading = true;
		lamp.enabled = false;
		StartCoroutine (FadeTextureAfter1Frame ());
	}

	void EndFading() {
		fading = false;
		lamp.enabled = true;
		flickerOffset = Vector3.zero;
		material.mainTexture = textureStyle;
		material.color = new Color(material.color.r,material.color.g,material.color.b,1f);
	}

	IEnumerator FadeTextureAfter1Frame() {
		yield return 0;
		material.mainTexture = lightningSource.textureFade;
	}

	
}
