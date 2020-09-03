
// Simplified Alpha Blended Particle shader with a tint color. Differences from regular Alpha Blended Particle one:
// - no Smooth particle support
// - no AlphaTest
// - no ColorMask

Shader "Custom/Mobile/Particles/Alpha Blended With Color" {
Properties {
_Color ("Color", Color) = (0.5,0.5,0.5,0.5)
_MainTex ("Particle Texture", 2D) = "white" {}
}

Category {
Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
Blend SrcAlpha OneMinusSrcAlpha
Cull Off Lighting Off ZWrite Off Fog { Color (0,0,0,0) }
 
BindChannels {
Bind "Color", Color
Bind "Vertex", vertex
Bind "TexCoord", texcoord
}
 
SubShader {
Pass {
SetTexture [_MainTex] {
combine texture * primary
}

SetTexture [_MainTex] {
constantColor [_Color]
Combine previous * constant DOUBLE, previous * constant
} 
}
}
}
}
