using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class X_LB_Bolt : MonoBehaviour {

	X_LB_LightningSource lightningSource;

	public List<X_LB_Segment> allSegmentsInBolt;

	public void Initialize (X_LB_LightningSource lightningSource) {
		this.lightningSource = lightningSource;		
	}

	public void ClearSegments() {
		for (int i = 0; i < allSegmentsInBolt.Count; i++) {
			X_LB_Segment current = (X_LB_Segment)allSegmentsInBolt[i];
			current.FromBoltInPool(this);
		}
	}

}
