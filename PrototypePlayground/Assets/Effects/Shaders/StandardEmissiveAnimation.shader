// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|diff-3441-OUT,emission-7903-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:32192,y:32505,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:4099,x:32192,y:32689,ptovrint:False,ptlb:maintex,ptin:_maintex,varname:node_4099,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:3441,x:32504,y:32648,varname:node_3441,prsc:2|A-1304-RGB,B-4099-RGB,C-7081-OUT;n:type:ShaderForge.SFN_Tex2d,id:2084,x:31658,y:32879,ptovrint:False,ptlb:emiss,ptin:_emiss,varname:node_2084,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False|UVIN-1771-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:2848,x:31214,y:32826,varname:node_2848,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:1771,x:31472,y:32848,varname:node_1771,prsc:2,spu:0,spv:1|UVIN-2848-UVOUT,DIST-570-OUT;n:type:ShaderForge.SFN_Multiply,id:570,x:31354,y:32998,varname:node_570,prsc:2|A-1508-OUT,B-2594-T;n:type:ShaderForge.SFN_Time,id:2594,x:31058,y:33091,varname:node_2594,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:1508,x:31058,y:33022,ptovrint:False,ptlb:speed,ptin:_speed,varname:node_1508,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Tex2d,id:7516,x:31658,y:33071,ptovrint:False,ptlb:emiss2,ptin:_emiss2,varname:node_7516,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False|UVIN-2132-UVOUT;n:type:ShaderForge.SFN_Multiply,id:5526,x:31403,y:33152,varname:node_5526,prsc:2|A-570-OUT,B-9450-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9450,x:31227,y:33206,ptovrint:False,ptlb:speed2,ptin:_speed2,varname:node_9450,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Panner,id:2132,x:31508,y:33078,varname:node_2132,prsc:2,spu:0,spv:1|UVIN-2848-UVOUT,DIST-5526-OUT;n:type:ShaderForge.SFN_Multiply,id:8444,x:32012,y:33068,varname:node_8444,prsc:2|A-7516-RGB,B-4980-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4980,x:31784,y:33212,ptovrint:False,ptlb:second,ptin:_second,varname:node_4980,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Add,id:1173,x:32263,y:33000,varname:node_1173,prsc:2|A-2084-RGB,B-8444-OUT;n:type:ShaderForge.SFN_Multiply,id:1844,x:32450,y:33039,varname:node_1844,prsc:2|A-1173-OUT,B-6625-OUT,C-7909-RGB;n:type:ShaderForge.SFN_ValueProperty,id:6625,x:32263,y:33144,ptovrint:False,ptlb:power,ptin:_power,varname:node_6625,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Color,id:7909,x:32244,y:33224,ptovrint:False,ptlb:emissCol,ptin:_emissCol,varname:node_7909,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Clamp01,id:7903,x:32547,y:32837,varname:node_7903,prsc:2|IN-1844-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7081,x:32300,y:32871,ptovrint:False,ptlb:bright,ptin:_bright,varname:node_7081,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;proporder:1304-4099-2084-1508-7516-9450-4980-6625-7909-7081;pass:END;sub:END;*/

Shader "Shader Forge/StandardEmissiveAnimation" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _maintex ("maintex", 2D) = "white" {}
        _emiss ("emiss", 2D) = "black" {}
        _speed ("speed", Float ) = 0
        _emiss2 ("emiss2", 2D) = "black" {}
        _speed2 ("speed2", Float ) = 0
        _second ("second", Float ) = 0
        _power ("power", Float ) = 0
        _emissCol ("emissCol", Color) = (0.5,0.5,0.5,1)
        _bright ("bright", Float ) = 0
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
            uniform sampler2D _maintex; uniform float4 _maintex_ST;
            uniform sampler2D _emiss; uniform float4 _emiss_ST;
            uniform float _speed;
            uniform sampler2D _emiss2; uniform float4 _emiss2_ST;
            uniform float _speed2;
            uniform float _second;
            uniform float _power;
            uniform float4 _emissCol;
            uniform float _bright;
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
                float4 _maintex_var = tex2D(_maintex,TRANSFORM_TEX(i.uv0, _maintex));
                float3 diffuseColor = (_Color.rgb*_maintex_var.rgb*_bright);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 node_2594 = _Time;
                float node_570 = (_speed*node_2594.g);
                float2 node_1771 = (i.uv0+node_570*float2(0,1));
                float4 _emiss_var = tex2D(_emiss,TRANSFORM_TEX(node_1771, _emiss));
                float2 node_2132 = (i.uv0+(node_570*_speed2)*float2(0,1));
                float4 _emiss2_var = tex2D(_emiss2,TRANSFORM_TEX(node_2132, _emiss2));
                float3 emissive = saturate(((_emiss_var.rgb+(_emiss2_var.rgb*_second))*_power*_emissCol.rgb));
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
            uniform sampler2D _maintex; uniform float4 _maintex_ST;
            uniform sampler2D _emiss; uniform float4 _emiss_ST;
            uniform float _speed;
            uniform sampler2D _emiss2; uniform float4 _emiss2_ST;
            uniform float _speed2;
            uniform float _second;
            uniform float _power;
            uniform float4 _emissCol;
            uniform float _bright;
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
                float4 _maintex_var = tex2D(_maintex,TRANSFORM_TEX(i.uv0, _maintex));
                float3 diffuseColor = (_Color.rgb*_maintex_var.rgb*_bright);
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
