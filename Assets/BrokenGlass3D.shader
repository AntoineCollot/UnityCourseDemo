 Shader "Smkgames/BrokenGlass3D"
{
    Properties{
        _Alpha("Alpha",Float) = 1
    }
    SubShader
    {
Tags {"Queue"="Transparent" "RenderType"="Transparent"}
 Blend SrcAlpha OneMinusSrcAlpha 


        GrabPass
        {
            "_GrabTexture"
        }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 grabPos : TEXCOORD0;
                float3 normal :NORMAL;
            };

            struct v2f
            {
                float4 grabPos : TEXCOORD0;
                float4 vertex : SV_POSITION;
                half3 worldNormal :TEXCOORD1;

            };
			
            float _Alpha;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.grabPos = ComputeGrabScreenPos(o.vertex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            sampler2D _GrabTexture;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 c = 0;
                c.rgb = i.worldNormal*0.5+0.5;
                fixed4 col = tex2Dproj(_GrabTexture, i.grabPos+c.r);
                return float4(col.rgb,_Alpha);
            }
            ENDCG
        }
    }
}