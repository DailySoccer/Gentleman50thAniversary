Shader "Unlit/TextureTint"
{
	Properties
	{
		_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex ("Texture", 2D) = "white" {}
		_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
		_Greyscale ("Grayscale", Range(0,1)) = 0
	}
	SubShader
	{
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" }
		Blend SrcAlpha OneMinusSrcAlpha
		Lighting Off ZWrite On
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 2.0
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
				UNITY_VERTEX_OUTPUT_STEREO
			};

			sampler2D _MainTex;
			fixed4 _TintColor;
			float4 _MainTex_ST;
			fixed _Cutoff;
			fixed _Greyscale;
			
			v2f vert (appdata v)
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				clip(col.a - _Cutoff);
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				col *= _TintColor;
				if (_Greyscale > 0) {
					fixed grey = ((col.r + col.g + col.b) * _Greyscale) / 3;
					fixed _invGreyscale = 1 - _Greyscale;
					fixed alpha = col.a;
					col = col * _invGreyscale + grey;
					col.a = alpha;
				}

				return col;
			}
			ENDCG
		}
	}
}
