// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-4623-OUT,voffset-7530-OUT,tess-7392-OUT;n:type:ShaderForge.SFN_Fresnel,id:9685,x:32234,y:32812,varname:node_9685,prsc:2|NRM-7454-OUT,EXP-6025-OUT;n:type:ShaderForge.SFN_NormalVector,id:7454,x:31934,y:32780,prsc:2,pt:True;n:type:ShaderForge.SFN_Slider,id:6025,x:31777,y:32947,ptovrint:False,ptlb:fresnel,ptin:_fresnel,varname:node_6025,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2.367522,max:20;n:type:ShaderForge.SFN_FragmentPosition,id:574,x:31158,y:33047,varname:node_574,prsc:2;n:type:ShaderForge.SFN_Append,id:2522,x:31347,y:33047,varname:node_2522,prsc:2|A-574-X,B-574-Z;n:type:ShaderForge.SFN_Tex2d,id:1041,x:31518,y:33047,ptovrint:False,ptlb:noise,ptin:_noise,varname:node_1041,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:87412b021f67f5e439dbc652dd3c2025,ntxv:0,isnm:False|UVIN-2522-OUT;n:type:ShaderForge.SFN_Vector3,id:8547,x:31518,y:33218,varname:node_8547,prsc:2,v1:0,v2:1,v3:0;n:type:ShaderForge.SFN_ValueProperty,id:4784,x:31518,y:33329,ptovrint:False,ptlb:height,ptin:_height,varname:node_4784,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:10;n:type:ShaderForge.SFN_Slider,id:6616,x:31361,y:33413,ptovrint:False,ptlb:upwardDisp,ptin:_upwardDisp,varname:node_6616,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:-0.8461549,max:1;n:type:ShaderForge.SFN_Add,id:7633,x:31891,y:33107,varname:node_7633,prsc:2|A-1041-R,B-5389-OUT;n:type:ShaderForge.SFN_Clamp01,id:240,x:32070,y:33128,varname:node_240,prsc:2|IN-7633-OUT;n:type:ShaderForge.SFN_Slider,id:5711,x:31361,y:33513,ptovrint:False,ptlb:size,ptin:_size,varname:node_5711,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-0.5,cur:0,max:1;n:type:ShaderForge.SFN_ValueProperty,id:2026,x:31518,y:33605,ptovrint:False,ptlb:scale,ptin:_scale,varname:node_2026,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_NormalVector,id:9956,x:31518,y:33672,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:7137,x:32344,y:33524,varname:node_7137,prsc:2|A-2026-OUT,B-9956-OUT,C-5711-OUT;n:type:ShaderForge.SFN_Add,id:7530,x:32406,y:33388,varname:node_7530,prsc:2|A-613-OUT,B-7137-OUT;n:type:ShaderForge.SFN_Multiply,id:613,x:32265,y:33224,varname:node_613,prsc:2|A-240-OUT,B-8547-OUT,C-4784-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7392,x:32467,y:33081,ptovrint:False,ptlb:tess,ptin:_tess,varname:node_7392,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Color,id:34,x:32080,y:32758,ptovrint:False,ptlb:col,ptin:_col,varname:node_34,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:582,x:32458,y:32790,varname:node_582,prsc:2|A-34-RGB,B-9685-OUT;n:type:ShaderForge.SFN_Tex2d,id:3546,x:31636,y:32502,ptovrint:False,ptlb:binary,ptin:_binary,varname:node_3546,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:54ac70b5a2b4a9f48b34f5ea03e3031b,ntxv:0,isnm:False|UVIN-7400-UVOUT;n:type:ShaderForge.SFN_Lerp,id:4623,x:32536,y:32617,varname:node_4623,prsc:2|A-1599-RGB,B-582-OUT,T-9685-OUT;n:type:ShaderForge.SFN_Color,id:4806,x:31636,y:32694,ptovrint:False,ptlb:binaryColor,ptin:_binaryColor,varname:node_4806,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:6919,x:31898,y:32562,varname:node_6919,prsc:2|A-3546-RGB,B-4806-RGB;n:type:ShaderForge.SFN_ScreenPos,id:7400,x:31366,y:32563,varname:node_7400,prsc:2,sctp:1;n:type:ShaderForge.SFN_Cubemap,id:1599,x:31788,y:32380,ptovrint:False,ptlb:node_1599,ptin:_node_1599,varname:node_1599,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,cube:204e8a1f6a8149443929f0b180485607,pvfc:4|DIR-4223-OUT;n:type:ShaderForge.SFN_ViewVector,id:4223,x:31433,y:32362,varname:node_4223,prsc:2;n:type:ShaderForge.SFN_ViewReflectionVector,id:6055,x:31554,y:32335,varname:node_6055,prsc:2;n:type:ShaderForge.SFN_Negate,id:5389,x:31749,y:33268,varname:node_5389,prsc:2|IN-6616-OUT;proporder:6025-1041-4784-6616-5711-2026-7392-34-3546-4806-1599;pass:END;sub:END;*/

Shader "Shader Forge/SpawnSphere" {
    Properties {
        _fresnel ("fresnel", Range(0, 20)) = 2.367522
        _noise ("noise", 2D) = "white" {}
        _height ("height", Float ) = 10
        _upwardDisp ("upwardDisp", Range(-1, 1)) = -0.8461549
        _size ("size", Range(-0.5, 1)) = 0
        _scale ("scale", Float ) = 1
        _tess ("tess", Float ) = 0
        _col ("col", Color) = (0.5,0.5,0.5,1)
        _binary ("binary", 2D) = "white" {}
        _binaryColor ("binaryColor", Color) = (0.5,0.5,0.5,1)
        _node_1599 ("node_1599", Cube) = "_Skybox" {}
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
            Cull Off
            
            
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "Tessellation.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 5.0
            uniform float _fresnel;
            uniform sampler2D _noise; uniform float4 _noise_ST;
            uniform float _height;
            uniform float _upwardDisp;
            uniform float _size;
            uniform float _scale;
            uniform float _tess;
            uniform float4 _col;
            uniform samplerCUBE _node_1599;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float2 node_2522 = float2(mul(unity_ObjectToWorld, v.vertex).r,mul(unity_ObjectToWorld, v.vertex).b);
                float4 _noise_var = tex2Dlod(_noise,float4(TRANSFORM_TEX(node_2522, _noise),0.0,0));
                v.vertex.xyz += ((saturate((_noise_var.r+(-1*_upwardDisp)))*float3(0,1,0)*_height)+(_scale*v.normal*_size));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    return o;
                }
                float Tessellation(TessVertex v){
                    return _tess;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float node_9685 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_fresnel);
                float3 emissive = lerp(texCUBE(_node_1599,viewDirection).rgb,(_col.rgb*node_9685),node_9685);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "Tessellation.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 5.0
            uniform sampler2D _noise; uniform float4 _noise_ST;
            uniform float _height;
            uniform float _upwardDisp;
            uniform float _size;
            uniform float _scale;
            uniform float _tess;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float2 node_2522 = float2(mul(unity_ObjectToWorld, v.vertex).r,mul(unity_ObjectToWorld, v.vertex).b);
                float4 _noise_var = tex2Dlod(_noise,float4(TRANSFORM_TEX(node_2522, _noise),0.0,0));
                v.vertex.xyz += ((saturate((_noise_var.r+(-1*_upwardDisp)))*float3(0,1,0)*_height)+(_scale*v.normal*_size));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    return o;
                }
                float Tessellation(TessVertex v){
                    return _tess;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
