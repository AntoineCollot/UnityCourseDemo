   Shader "Smkgames/HeatDistortion"
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
            };

            struct v2f
            {
                float4 grabPos : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
            sampler2D _Mask,_DistortionMap;
            float _Alpha,_Refraction;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.grabPos = ComputeGrabScreenPos(o.vertex);
                return o;
            }

            sampler2D _GrabTexture;
            float _Intensity;

            fixed4 frag (v2f i) : SV_Target
            {
                float mask = tex2D(_Mask,i.grabPos);
                mask = step(mask,0.5);
                //mask = smoothstep(mask,0,0.4);
                float4 distortion = tex2D(_DistortionMap,i.grabPos+_Time.y)+_Intensity;
                fixed4 col = tex2Dproj(_GrabTexture, i.grabPos*distortion);
                return float4(col.rgb,mask*_Alpha);

            }
            ENDCG
        }
    }
}