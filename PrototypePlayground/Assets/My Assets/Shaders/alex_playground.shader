// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32899,y:32578,varname:node_4013,prsc:2|diff-1304-RGB,voffset-8090-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:32244,y:32559,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Sin,id:9728,x:31567,y:32920,varname:node_9728,prsc:2|IN-8306-TDB;n:type:ShaderForge.SFN_Time,id:8306,x:31322,y:32851,varname:node_8306,prsc:2;n:type:ShaderForge.SFN_Vector1,id:9259,x:32053,y:33580,varname:node_9259,prsc:2,v1:1;n:type:ShaderForge.SFN_Slider,id:967,x:31552,y:32625,ptovrint:False,ptlb:node_967,ptin:_node_967,varname:node_967,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_NormalVector,id:6925,x:31438,y:33168,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:8110,x:31992,y:32912,varname:node_8110,prsc:2|A-967-OUT,B-9728-OUT;n:type:ShaderForge.SFN_Noise,id:2143,x:32302,y:33546,varname:node_2143,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8090,x:32214,y:33107,varname:node_8090,prsc:2|A-8110-OUT,B-2666-OUT,C-674-OUT;n:type:ShaderForge.SFN_Noise,id:674,x:31893,y:33355,varname:node_674,prsc:2|XY-7367-OUT;n:type:ShaderForge.SFN_Noise,id:2666,x:31893,y:33102,varname:node_2666,prsc:2|XY-3060-OUT;n:type:ShaderForge.SFN_ComponentMask,id:3060,x:31639,y:33168,varname:node_3060,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-6925-OUT;n:type:ShaderForge.SFN_ComponentMask,id:7082,x:32393,y:33381,varname:node_7082,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1;n:type:ShaderForge.SFN_ComponentMask,id:7367,x:31661,y:33355,varname:node_7367,prsc:2,cc1:1,cc2:2,cc3:-1,cc4:-1|IN-6925-OUT;proporder:1304-967;pass:END;sub:END;*/

Shader "Shader Forge/alex_playground" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _node_967 ("node_967", Range(0, 10)) = 0
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform float _node_967;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_8306 = _Time;
                float2 node_3060 = v.normal.rg;
                float2 node_2666_skew = node_3060 + 0.2127+node_3060.x*0.3713*node_3060.y;
                float2 node_2666_rnd = 4.789*sin(489.123*(node_2666_skew));
                float node_2666 = frac(node_2666_rnd.x*node_2666_rnd.y*(1+node_2666_skew.x));
                float2 node_7367 = v.normal.gb;
                float2 node_674_skew = node_7367 + 0.2127+node_7367.x*0.3713*node_7367.y;
                float2 node_674_rnd = 4.789*sin(489.123*(node_674_skew));
                float node_674 = frac(node_674_rnd.x*node_674_rnd.y*(1+node_674_skew.x));
                float node_8090 = ((_node_967*sin(node_8306.b))*node_2666*node_674);
                v.vertex.xyz += float3(node_8090,node_8090,node_8090);
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
/// Final Color:
                float3 finalColor = diffuse;
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform float _node_967;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_8306 = _Time;
                float2 node_3060 = v.normal.rg;
                float2 node_2666_skew = node_3060 + 0.2127+node_3060.x*0.3713*node_3060.y;
                float2 node_2666_rnd = 4.789*sin(489.123*(node_2666_skew));
                float node_2666 = frac(node_2666_rnd.x*node_2666_rnd.y*(1+node_2666_skew.x));
                float2 node_7367 = v.normal.gb;
                float2 node_674_skew = node_7367 + 0.2127+node_7367.x*0.3713*node_7367.y;
                float2 node_674_rnd = 4.789*sin(489.123*(node_674_skew));
                float node_674 = frac(node_674_rnd.x*node_674_rnd.y*(1+node_674_skew.x));
                float node_8090 = ((_node_967*sin(node_8306.b))*node_2666*node_674);
                v.vertex.xyz += float3(node_8090,node_8090,node_8090);
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
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform float _node_967;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float3 normalDir : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_8306 = _Time;
                float2 node_3060 = v.normal.rg;
                float2 node_2666_skew = node_3060 + 0.2127+node_3060.x*0.3713*node_3060.y;
                float2 node_2666_rnd = 4.789*sin(489.123*(node_2666_skew));
                float node_2666 = frac(node_2666_rnd.x*node_2666_rnd.y*(1+node_2666_skew.x));
                float2 node_7367 = v.normal.gb;
                float2 node_674_skew = node_7367 + 0.2127+node_7367.x*0.3713*node_7367.y;
                float2 node_674_rnd = 4.789*sin(489.123*(node_674_skew));
                float node_674 = frac(node_674_rnd.x*node_674_rnd.y*(1+node_674_skew.x));
                float node_8090 = ((_node_967*sin(node_8306.b))*node_2666*node_674);
                v.vertex.xyz += float3(node_8090,node_8090,node_8090);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
