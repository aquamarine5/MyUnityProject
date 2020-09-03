using UnityEngine;
using System.Collections;

public class X_LB_Branch : MonoBehaviour {

	Material material;
	float fadeTime = 0.2f;
	float fadeTimeMax = 0.2f;
	Transform sceleton;
	Transform[] points;

	X_LB_LightningSource lightningSource;

	X_LB_Segment segment;

	float startOffsetY;

	//cached vars 
	float w = 0.03f;

	// Use this for initialization
	public void Initialize (X_LB_LightningSource lightningSource) {

		this.lightningSource = lightningSource;

		material = GetComponentInChildren<Renderer> ().material;
		sceleton = transform.Find ("BranchModel/joint1/joint2");
		points = sceleton.GetComponentsInChildren<Transform> ();
		SceletonSetup ();

		startOffsetY = material.mainTextureOffset.y;

		InPool ();

	}

	void InPool() {
		transform.parent = lightningSource.poolBranches;
		lightningSource.allBranchesInPool.Add (this);
		gameObject.SetActive (false);
	}

	void SceletonSetup() {
		for (int i = 0; i < points.Length; i++) {
			points[i].transform.localPosition += new Vector3(Random.Range (-w,w),Random.Range (-w,w),Random.Range (-w,w));
		}
	}

	public void LateLoop () {
		Whizz ();
	}

	void Whizz() {
		fadeTime -= Time.deltaTime*2f;
		if (lightningSource.freezeShape == false) {
			material.mainTextureOffset -= new Vector2 ((Time.deltaTime) / fadeTimeMax, 0);
		}
		if (lightningSource.freezeShape == true) {
			if (fadeTime < fadeTimeMax / 2) {
				material.mainTextureOffset -= new Vector2 ((Time.deltaTime) / fadeTimeMax, 0);
			}
		}
		if (fadeTime < 0) {
			fadeTime = fadeTimeMax;
			Disappear ();
		}
	}

	public void FromPoolInSegment(X_LB_Segment segment) {
		Prepare ();
		this.segment = segment;
		if (lightningSource.allBranchesInPool.Contains(this)) {
			lightningSource.allBranchesInPool.Remove (this);
		}
		segment.allBranchesInSegment.Add (this);
		gameObject.SetActive (true);
	}

	public void FromSegmentInPool(X_LB_Segment segment) {
		if (segment.allBranchesInSegment.Contains(this)) {
			segment.allBranchesInSegment.Remove (this);
		}
		lightningSource.allBranchesInPool.Add (this);
		gameObject.SetActive (false);		
	}

	void Prepare() {
		material.mainTextureOffset = new Vector2 (0.5f, startOffsetY);
		if (lightningSource.freezeShape == true) {
			material.mainTextureOffset = new Vector2 (1f, startOffsetY);
		}
		material.color = lightningSource.color;
	}

	void Disappear() {
		FromSegmentInPool (segment);
	}

}
