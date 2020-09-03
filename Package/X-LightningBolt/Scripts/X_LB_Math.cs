using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

namespace Calculator {

	public static class X_LB_Math {
		        
        private static float _xhalf;
        private static float _normLength;
        private static FloatIntUnion _u;

        [StructLayout(LayoutKind.Explicit)]
        private struct FloatIntUnion {
            [FieldOffset(0)]
            public float f;
            [FieldOffset(0)]
            public int tmp;
        }

        public static float Sqrt(float z) {
            if (z == 0) return 0;
            _u.tmp = 0;
            _u.f = z;
            _u.tmp -= 1 << 23;
            _u.tmp >>= 1;
            _u.tmp += 1 << 29;
            return _u.f;
        }

        public static float Sqrt2(float z) {
            if (z == 0) return 0;
            _u.tmp = 0;
            _xhalf = 0.5f * z;
            _u.f = z;
            _u.tmp = 0x5f375a86 - (_u.tmp >> 1);
            _u.f = _u.f * (1.5f - _xhalf * _u.f * _u.f);
            return _u.f * z;
        }

        public static Vector3 Normalize(Vector3 vector) {
            _normLength = Sqrt2((vector.x * vector.x) + (vector.y * vector.y) + (vector.y * vector.y));
            vector.x /= _normLength;
            vector.y /= _normLength;
            vector.z /= _normLength;
            return vector;
        }

    }
}
