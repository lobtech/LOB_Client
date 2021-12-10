Shader "Custom/green"
{
    Properties
    {
        _MainTex("Texture images", 2D) = "white" {}
        _Strength("sway", Float) = 1
        _Speed("Swing speed", Float) = 3
        _AoColor("Based on the color", Color) = (1,1,1)
        _ShadowColor("The shadow color", Color) = (1,1,1)
        _Specular("Specular", Color) = (1,1,1)
        _Gloss("glossiness", Float) = 1
    }
        SubShader
        {
            Pass
            {
                //Specifies the light mode for the Pass
                Tags {"LightMode" = "ForwardBase"}
                Cull Off
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
            //Include Unity's built-in variables
            #include "UnityCG.cginc" 
            #include "Lighting.cginc"
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR0;
                float3 normal: NORMAL;
            };
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
                float4 color: TEXCOORD1;
                float3 worldNormal: TEXCOORD2;
                float3 worldPos : TEXCOORD3;
            };
            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed3 _AoColor;
            float _Speed;
            float _Strength;
            fixed3 _ShadowColor;
            fixed3 _Specular;
            float _Gloss;

            v2f vert(appdata v)
            {
                v2f o;
                float3 worldPos = UnityObjectToWorldDir(v.vertex);

                float stage1 = dot(v.vertex, float3(0, 1, 0)) * _Strength;
                float stage2 = sin(dot(v.vertex, float3(1, 0, 0)) * _Strength + _Time.y * _Speed);
                float3 stage3 = stage1 * stage2 * float3(0.001, 0, 0.001) * v.color.a;
                o.pos = UnityObjectToClipPos(v.vertex + stage3);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = v.color;
                o.worldNormal = normalize(mul(v.normal, (float3x3)unity_WorldToObject));
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }
            fixed4 frag(v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                clip(col.a - 0.5);
                // Normals in world space
                fixed3 worldNormal = i.worldNormal;
                // Direction of light source in world space
                fixed3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz);
                // diffuse
                fixed3 diffuse = _LightColor0.rgb * col.rgb * _AoColor
                * lerp(_ShadowColor, float3(1,1,1), i.color.rgb)
                * (dot(worldNormal, worldLightDir) * 0.5 + 0.5);
                // ambient
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * col.rgb;
                // Perspective direction in world space
                fixed3 viewDir = normalize(_WorldSpaceCameraPos.xyz - i.worldPos.xyz);
                // Half direction in world space
                fixed3 halfDir = normalize(worldLightDir + viewDir);
                // specular
                fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow(saturate(dot(halfDir, worldNormal)), _Gloss);

                return fixed4(diffuse + ambient + specular, col.a);
            }
            ENDCG
            }
        }
}
