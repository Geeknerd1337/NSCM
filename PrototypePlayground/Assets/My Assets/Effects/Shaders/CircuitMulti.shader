// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|diff-1304-RGB,emission-6235-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:32448,y:32712,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Tex2d,id:5118,x:31582,y:32858,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_5118,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:a069d44dbad921145ac466d32dd322d7,ntxv:0,isnm:False;n:type:ShaderForge.SFN_TexCoord,id:1384,x:30996,y:33298,varname:node_1384,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:8126,x:32086,y:32842,varname:node_8126,prsc:2|A-5118-R,B-4348-OUT;n:type:ShaderForge.SFN_Sin,id:4348,x:31830,y:33102,varname:node_4348,prsc:2|IN-8166-OUT;n:type:ShaderForge.SFN_Multiply,id:8166,x:31636,y:33118,varname:node_8166,prsc:2|A-5090-OUT,B-5906-OUT;n:type:ShaderForge.SFN_Slider,id:5906,x:31308,y:33264,ptovrint:False,ptlb:node_5906,ptin:_node_5906,varname:node_5906,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:68.37608,max:200;n:type:ShaderForge.SFN_Cos,id:6501,x:31857,y:33255,varname:node_6501,prsc:2|IN-2977-OUT;n:type:ShaderForge.SFN_Multiply,id:9192,x:32065,y:33059,varname:node_9192,prsc:2|A-5118-G,B-6501-OUT;n:type:ShaderForge.SFN_Add,id:3929,x:32235,y:33014,varname:node_3929,prsc:2|A-8126-OUT,B-9192-OUT,C-5118-B;n:type:ShaderForge.SFN_Add,id:5090,x:31296,y:33071,varname:node_5090,prsc:2|A-1384-V,B-9387-OUT;n:type:ShaderForge.SFN_Multiply,id:2977,x:31671,y:33299,varname:node_2977,prsc:2|A-6205-OUT,B-5906-OUT;n:type:ShaderForge.SFN_Add,id:6205,x:31223,y:33344,varname:node_6205,prsc:2|A-9387-OUT,B-1384-U;n:type:ShaderForge.SFN_Time,id:2272,x:30792,y:33029,varname:node_2272,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9387,x:31035,y:33093,varname:node_9387,prsc:2|A-2272-T,B-9848-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9848,x:30779,y:33200,ptovrint:False,ptlb:speed,ptin:_speed,varname:node_9848,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Clamp01,id:2566,x:32347,y:32815,varname:node_2566,prsc:2|IN-3929-OUT;n:type:ShaderForge.SFN_Multiply,id:6235,x:32541,y:32930,varname:node_6235,prsc:2|A-2566-OUT,B-1829-OUT,C-112-RGB;n:type:ShaderForge.SFN_Slider,id:1829,x:32428,y:33183,ptovrint:False,ptlb:Amt,ptin:_Amt,varname:node_1829,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:2;n:type:ShaderForge.SFN_Color,id:112,x:32375,y:33014,ptovrint:False,ptlb:Color_1,ptin:_Color_1,varname:node_112,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:1,c3:0.0136652,c4:1;proporder:1304-5118-5906-9848-1829-112;pass:END;sub:END;*/

Shader "Shader Forge/CircuitMulti" {
    Properties {
        _Color ("Color", Color) = (0,0,0,1)
        _Texture ("Texture", 2D) = "white" {}
        _node_5906 ("node_5906", Range(0, 200)) = 68.37608
        _speed ("speed", Float ) = 0
        _Amt ("Amt", Range(0, 2)) = 2
        _Color_1 ("Color_1", Color) = (0,1,0.0136652,1)
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
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _node_5906;
            uniform float _speed;
            uniform float _Amt;
            uniform float4 _Color_1;
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
                float3 diffuseColor = _Color.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float4 node_2272 = _Time;
                float node_9387 = (node_2272.g*_speed);
                float3 emissive = (saturate(((_Texture_var.r*sin(((i.uv0.g+node_9387)*_node_5906)))+(_Texture_var.g*cos(((node_9387+i.uv0.r)*_node_5906)))+_Texture_var.b))*_Amt*_Color_1.rgb);
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
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _node_5906;
            uniform float _speed;
            uniform float _Amt;
            uniform float4 _Color_1;
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
                float3 diffuseColor = _Color.rgb;
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
