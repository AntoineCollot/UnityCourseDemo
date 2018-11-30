    Shader "Smkgames/HeatDistortionParticle"
{
    Properties{
        _DistortionMap("DistortionMap",2D) = "white"{}
        _Intensity("Intensity",Float) = 50
        _Mask("Mask",2D) = "white"{}
        _Alpha("Alpha",Range(0,1)) = 1
    }
    SubShader
    {
Tags {"Queue"="Transparent" "RenderType"="Transparent"}

        GrabPass
        {
            "_GrabTexture"
        }

        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
            };

            struct v2f
            {
				float2 uv : TEXCOORD0;
                float4 grabPos : TEXCOORD1;
                float4 vertex : SV_POSITION;
            };
            sampler2D _Mask;
			float4 _Mask_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.grabPos = ComputeGrabScreenPos(o.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _Mask);
                return o;
            }

            sampler2D _GrabTexture,_DistortionMap;;
            float _Intensity;
			float _Alpha,_Refraction;

            fixed4 frag (v2f i) : SV_Target
            {
                float mask = tex2D(_Mask,i.uv);
                //mask = step(mask,0.5);
                //mask = smoothstep(mask,0,0.4);
                float4 distortion = tex2D(_DistortionMap,i.grabPos+_Time.y)+_Intensity;
                fixed4 col = tex2Dproj(_GrabTexture, i.grabPos*distortion);
                return float4(col.rgb,mask*_Alpha);

            }
            ENDCG
        }
    }
}