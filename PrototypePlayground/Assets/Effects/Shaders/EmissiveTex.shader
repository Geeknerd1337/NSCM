// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|diff-1836-OUT,emission-2371-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:32002,y:32631,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:3018,x:32002,y:32804,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_3018,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:620b4214a9df5cf47ace229122ebf12e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1836,x:32328,y:32706,varname:node_1836,prsc:2|A-1304-RGB,B-3018-RGB;n:type:ShaderForge.SFN_Tex2d,id:6938,x:31723,y:33007,ptovrint:False,ptlb:emiss,ptin:_emiss,varname:node_6938,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c4680a72bc531c44dbf1207b94504f48,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:8388,x:31723,y:33206,ptovrint:False,ptlb:emissColor,ptin:_emissColor,varname:node_8388,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:7878,x:32197,y:33019,varname:node_7878,prsc:2|A-6938-RGB,B-8388-RGB,C-4950-OUT;n:type:ShaderForge.SFN_TexCoord,id:32,x:31478,y:33206,varname:node_32,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Sin,id:9785,x:32048,y:33171,varname:node_9785,prsc:2|IN-3632-OUT;n:type:ShaderForge.SFN_Multiply,id:3632,x:31723,y:33515,varname:node_3632,prsc:2|A-8519-OUT,B-2505-OUT;n:type:ShaderForge.SFN_Slider,id:2505,x:31357,y:33536,ptovrint:False,ptlb:amp,ptin:_amp,varname:node_2505,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:13.23077,max:40;n:type:ShaderForge.SFN_Clamp01,id:2371,x:32412,y:33019,varname:node_2371,prsc:2|IN-7878-OUT;n:type:ShaderForge.SFN_Power,id:4950,x:32268,y:33217,varname:node_4950,prsc:2|VAL-9785-OUT,EXP-8870-OUT;n:type:ShaderForge.SFN_Slider,id:8870,x:32061,y:33486,ptovrint:False,ptlb:power,ptin:_power,varname:node_8870,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3589744,max:1;n:type:ShaderForge.SFN_Add,id:8519,x:31503,y:33385,varname:node_8519,prsc:2|A-32-V,B-8197-OUT,C-6773-OUT;n:type:ShaderForge.SFN_Multiply,id:8197,x:31179,y:33410,varname:node_8197,prsc:2|A-6830-T,B-7216-OUT;n:type:ShaderForge.SFN_Time,id:6830,x:30844,y:33445,varname:node_6830,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:7216,x:30967,y:33619,ptovrint:False,ptlb:speed,ptin:_speed,varname:node_7216,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:6773,x:31138,y:33614,ptovrint:False,ptlb:offset,ptin:_offset,varname:node_6773,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;proporder:1304-3018-6938-8388-2505-8870-7216-6773;pass:END;sub:END;*/

Shader "Shader Forge/EmissiveTex" {
    Properties {
        [HDR]_Color ("Color", Color) = (1,1,1,1)
        _MainTex ("MainTex", 2D) = "white" {}
        _emiss ("emiss", 2D) = "white" {}
        [HDR]_emissColor ("emissColor", Color) = (1,1,1,1)
        _amp ("amp", Range(0, 40)) = 13.23077
        _power ("power", Range(0, 1)) = 0.3589744
        _speed ("speed", Float ) = 0
        _offset ("offset", Float ) = 0
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _emiss; uniform float4 _emiss_ST;
            uniform float4 _emissColor;
            uniform float _amp;
            uniform float _power;
            uniform float _speed;
            uniform float _offset;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 diffuseColor = (_Color.rgb*_MainTex_var.rgb);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 _emiss_var = tex2D(_emiss,TRANSFORM_TEX(i.uv0, _emiss));
                float4 node_6830 = _Time;
                float3 emissive = saturate((_emiss_var.rgb*_emissColor.rgb*pow(sin(((i.uv0.g+(node_6830.g*_speed)+_offset)*_amp)),_power)));
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _emiss; uniform float4 _emiss_ST;
            uniform float4 _emissColor;
            uniform float _amp;
            uniform float _power;
            uniform float _speed;
            uniform float _offset;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 diffuseColor = (_Color.rgb*_MainTex_var.rgb);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
