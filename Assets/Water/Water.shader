Shader "Custom/Water" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_Speed ("Wave Speed",Float) = 0.5
		_Frequency ("Wave Frequency",Float) = 0.5
		_Height ("Wave Height",Float) = 0.5
		_Foam ("Foam Line Width",Float) = 0.5
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard vertex:vert fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float4 screenPos;
		};
		
		half _Speed;
		half _Frequency;
		half _Height;
		
		void vert (inout appdata_full v,out Input o) {
			UNITY_INITIALIZE_OUTPUT(Input,o);
			v.vertex.y += sin(_Time.z * _Speed + (v.vertex.x+v.vertex.z) * _Frequency)*_Height;
			o.screenPos = ComputeScreenPos(v.vertex);
      }

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		sampler2D _CameraDepthTexture;
		half _Foam;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_CBUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_CBUFFER_END

		void surf (Input IN, inout SurfaceOutputStandard o) {	
			half depth = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture,UNITY_PROJ_COORD(IN.screenPos)));
			half4 foamLine = 1 - saturate(_Foam * (depth - IN.screenPos.w));
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			c+=foamLine;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
