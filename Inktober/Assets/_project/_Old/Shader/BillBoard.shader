Shader "Unlit/BillBoard"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;

            v2f vert (appdata_t v)
            {
                v2f o;
                float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                float3 cameraPos = _WorldSpaceCameraPos;
                float3 direction = normalize(- cameraPos + worldPos);
                float3 up = float3(0, 1, 0);
                float3 right = cross(up, direction);
                float3 forward = cross(right, up);

                float4x4 rotationMatrix = float4x4(
                    float4(right, 0),
                    float4(up, 0),
                    float4(forward, 0),
                    float4(0, 0, 0, 1)
                );

                float4 rotatedPos = mul(rotationMatrix, v.vertex);
                o.vertex = UnityObjectToClipPos(rotatedPos);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return tex2D(_MainTex, i.uv);
            }
            ENDCG
        }
    }
}