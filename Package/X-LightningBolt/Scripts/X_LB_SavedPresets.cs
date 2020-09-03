using UnityEngine;
using System.Collections;

public static class X_LB_SavedPresets {

	public static void GetPresetValues(X_LB_LightningSource ls, string value, string preset) {

		if (preset == "cartoonEnergyStream") {
			if (value == "color") {
				ls.color = Color.magenta;
			}
			if (value == "thinStyle") {
				ls.thinStyle = false;
			}
			if (value == "darkStyle") {
				ls.darkStyle = false;
			}
			if (value == "fadeEffect") {
				ls.fadeEffect = true;
			}
			if (value == "lightSize") {
				ls.lightSize = 60;
			}
			if (value == "freezeShape") {
				ls.freezeShape = false;
			}
			if (value == "segmentSize") {
				ls.segmentSize = 10;
			}
			if (value == "flickeringStrength") {
				ls.flickeringStrength = 1;
			}
			if (value == "streamingSpeed") {
				ls.streamingSpeed = 2;
			}
			if (value == "branchAmount") {
				ls.branchAmount = 10;
			}
		}

		if (preset == "cartoonImpactBolt") {
			if (value == "color") {
				ls.color = Color.white;
			}
			if (value == "thinStyle") {
				ls.thinStyle = false;
			}
			if (value == "darkStyle") {
				ls.darkStyle = false;
			}
			if (value == "fadeEffect") {
				ls.fadeEffect = true;
			}
			if (value == "lightSize") {
				ls.lightSize = 30;
			}
			if (value == "freezeShape") {
				ls.freezeShape = false;
			}
			if (value == "segmentSize") {
				ls.segmentSize = 7;
			}
			if (value == "flickeringStrength") {
				ls.flickeringStrength = 1;
			}
			if (value == "streamingSpeed") {
				ls.streamingSpeed = 0;
			}
			if (value == "branchAmount") {
				ls.branchAmount = 10;
			}
		}
		
		if (preset == "cartoonFeralBolt") {
			if (value == "color") {
				ls.color = Color.cyan;
			}
			if (value == "thinStyle") {
				ls.thinStyle = false;
			}
			if (value == "darkStyle") {
				ls.darkStyle = true;
			}
			if (value == "fadeEffect") {
				ls.fadeEffect = true;
			}
			if (value == "lightSize") {
				ls.lightSize = 50;
			}
			if (value == "freezeShape") {
				ls.freezeShape = false;
			}
			if (value == "segmentSize") {
				ls.segmentSize = 12f;
			}
			if (value == "flickeringStrength") {
				ls.flickeringStrength = 1.5f;
			}
			if (value == "streamingSpeed") {
				ls.streamingSpeed = 10;
			}
			if (value == "branchAmount") {
				ls.branchAmount = 50;
			}
		}

		if (preset == "realisticLightning") {
			if (value == "color") {
				ls.color = Color.white;
			}
			if (value == "thinStyle") {
				ls.thinStyle = true;
			}
			if (value == "darkStyle") {
				ls.darkStyle = false;
			}
			if (value == "fadeEffect") {
				ls.fadeEffect = true;
			}
			if (value == "lightSize") {
				ls.lightSize = 60;
			}
			if (value == "freezeShape") {
				ls.freezeShape = true;
			}
			if (value == "segmentSize") {
				ls.segmentSize = 8;
			}
			if (value == "flickeringStrength") {
				ls.flickeringStrength = 1.2f;
			}
			if (value == "streamingSpeed") {
				ls.streamingSpeed = 1;
			}
			if (value == "branchAmount") {
				ls.branchAmount = 30;
			}
		}

	}
}
