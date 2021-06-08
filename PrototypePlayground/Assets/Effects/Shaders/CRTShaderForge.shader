// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|diff-1304-RGB,spec-2445-OUT,emission-7845-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:32464,y:32465,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Tex2d,id:8666,x:31891,y:32926,ptovrint:False,ptlb:tex,ptin:_tex,varname:node_8666,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:84bbf0c816d569349a18a494eb2b7d81,ntxv:0,isnm:False|UVIN-460-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:5006,x:31025,y:32864,varname:node_5006,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Fmod,id:5992,x:31734,y:33049,varname:node_5992,prsc:2|A-2457-OUT,B-9597-OUT;n:type:ShaderForge.SFN_Vector1,id:9597,x:31573,y:33083,varname:node_9597,prsc:2,v1:3;n:type:ShaderForge.SFN_ValueProperty,id:6482,x:31453,y:32657,ptovrint:False,ptlb:textureSize,ptin:_textureSize,varname:node_6482,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:256;n:type:ShaderForge.SFN_Multiply,id:3541,x:31637,y:32823,varname:node_3541,prsc:2|A-5006-U,B-6482-OUT;n:type:ShaderForge.SFN_Round,id:2457,x:31882,y:32750,varname:node_2457,prsc:2|IN-3541-OUT;n:type:ShaderForge.SFN_If,id:1311,x:32053,y:33226,varname:node_1311,prsc:2|A-3493-OUT,B-6576-OUT,GT-9616-OUT,EQ-2279-OUT,LT-9616-OUT;n:type:ShaderForge.SFN_Vector1,id:6576,x:31814,y:33202,varname:node_6576,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:2279,x:31814,y:33260,varname:node_2279,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:9616,x:31814,y:33320,varname:node_9616,prsc:2,v1:0;n:type:ShaderForge.SFN_Round,id:3493,x:31891,y:33021,varname:node_3493,prsc:2|IN-5992-OUT;n:type:ShaderForge.SFN_Vector1,id:8582,x:31814,y:33435,varname:node_8582,prsc:2,v1:1;n:type:ShaderForge.SFN_If,id:8627,x:32053,y:33401,varname:node_8627,prsc:2|A-3493-OUT,B-8582-OUT,GT-9616-OUT,EQ-2279-OUT,LT-9616-OUT;n:type:ShaderForge.SFN_If,id:2567,x:32053,y:33556,varname:node_2567,prsc:2|A-3493-OUT,B-9176-OUT,GT-9616-OUT,EQ-2279-OUT,LT-9616-OUT;n:type:ShaderForge.SFN_Vector1,id:9176,x:31814,y:33575,varname:node_9176,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:2357,x:32245,y:33173,varname:node_2357,prsc:2|A-8666-R,B-1311-OUT;n:type:ShaderForge.SFN_Multiply,id:4473,x:32298,y:33337,varname:node_4473,prsc:2|A-8666-G,B-8627-OUT;n:type:ShaderForge.SFN_Multiply,id:4988,x:32298,y:33464,varname:node_4988,prsc:2|A-8666-B,B-2567-OUT;n:type:ShaderForge.SFN_Append,id:9509,x:32532,y:33271,varname:node_9509,prsc:2|A-2357-OUT,B-4473-OUT,C-4988-OUT;n:type:ShaderForge.SFN_Lerp,id:9588,x:32293,y:32944,varname:node_9588,prsc:2|A-9509-OUT,B-9182-OUT,T-7603-OUT;n:type:ShaderForge.SFN_Slider,id:7603,x:32067,y:33090,ptovrint:False,ptlb:influence,ptin:_influence,varname:node_7603,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6637568,max:1;n:type:ShaderForge.SFN_Multiply,id:7845,x:32494,y:33013,varname:node_7845,prsc:2|A-8913-OUT,B-9588-OUT,C-6757-OUT,D-2099-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8913,x:32408,y:32403,ptovrint:False,ptlb:gamma,ptin:_gamma,varname:node_8913,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.2;n:type:ShaderForge.SFN_ValueProperty,id:3531,x:31453,y:32532,ptovrint:False,ptlb:scanLineSize,ptin:_scanLineSize,varname:node_3531,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:256;n:type:ShaderForge.SFN_Fmod,id:784,x:31882,y:32507,varname:node_784,prsc:2|A-1190-OUT,B-6424-OUT;n:type:ShaderForge.SFN_Multiply,id:1190,x:31728,y:32491,varname:node_1190,prsc:2|A-3531-OUT,B-5006-V;n:type:ShaderForge.SFN_Vector1,id:6424,x:31681,y:32631,varname:node_6424,prsc:2,v1:3;n:type:ShaderForge.SFN_Slider,id:9595,x:31698,y:32777,ptovrint:False,ptlb:scanLineBrightness,ptin:_scanLineBrightness,varname:node_9595,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6675796,max:1;n:type:ShaderForge.SFN_If,id:1351,x:32158,y:32381,varname:node_1351,prsc:2|A-4520-OUT,B-2167-OUT,GT-4411-OUT,EQ-6455-OUT,LT-4411-OUT;n:type:ShaderForge.SFN_Vector1,id:4411,x:31948,y:32681,varname:node_4411,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:6455,x:32055,y:32681,varname:node_6455,prsc:2,v1:1;n:type:ShaderForge.SFN_Round,id:4520,x:31910,y:32381,varname:node_4520,prsc:2|IN-784-OUT;n:type:ShaderForge.SFN_Clamp01,id:4652,x:32142,y:32487,varname:node_4652,prsc:2|IN-1351-OUT;n:type:ShaderForge.SFN_Add,id:4700,x:32231,y:32634,varname:node_4700,prsc:2|A-9886-OUT,B-9595-OUT;n:type:ShaderForge.SFN_OneMinus,id:9886,x:32330,y:32570,varname:node_9886,prsc:2|IN-4652-OUT;n:type:ShaderForge.SFN_Vector1,id:2167,x:31623,y:32193,varname:node_2167,prsc:2,v1:1;n:type:ShaderForge.SFN_Sin,id:4121,x:31256,y:33131,varname:node_4121,prsc:2|IN-4661-OUT;n:type:ShaderForge.SFN_Multiply,id:7520,x:31003,y:33082,varname:node_7520,prsc:2|A-5620-OUT,B-5006-V;n:type:ShaderForge.SFN_ValueProperty,id:5620,x:30723,y:33106,ptovrint:False,ptlb:largeScanSize,ptin:_largeScanSize,varname:node_5620,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:7;n:type:ShaderForge.SFN_Add,id:4661,x:31172,y:33211,varname:node_4661,prsc:2|A-7520-OUT,B-7936-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3250,x:30848,y:33239,ptovrint:False,ptlb:largeScanSpeed,ptin:_largeScanSpeed,varname:node_3250,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-1;n:type:ShaderForge.SFN_Time,id:5523,x:30827,y:33310,varname:node_5523,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7936,x:31044,y:33289,varname:node_7936,prsc:2|A-3250-OUT,B-5523-T;n:type:ShaderForge.SFN_Add,id:9529,x:31592,y:33352,varname:node_9529,prsc:2|A-2825-OUT,B-407-OUT;n:type:ShaderForge.SFN_Slider,id:2825,x:31118,y:33460,ptovrint:False,ptlb:largeScanAmt,ptin:_largeScanAmt,varname:node_2825,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.9052682,max:1;n:type:ShaderForge.SFN_RemapRange,id:5010,x:31374,y:33243,varname:node_5010,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-4121-OUT;n:type:ShaderForge.SFN_Clamp01,id:2099,x:31633,y:33202,varname:node_2099,prsc:2|IN-9529-OUT;n:type:ShaderForge.SFN_Power,id:407,x:31559,y:33628,varname:node_407,prsc:2|VAL-5010-OUT,EXP-4153-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4153,x:31221,y:33724,ptovrint:False,ptlb:largeScanFalloff,ptin:_largeScanFalloff,varname:node_4153,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;n:type:ShaderForge.SFN_Slider,id:2445,x:32321,y:32880,ptovrint:False,ptlb:monitorShiny,ptin:_monitorShiny,varname:node_2445,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Clamp01,id:6757,x:32190,y:32770,varname:node_6757,prsc:2|IN-4700-OUT;n:type:ShaderForge.SFN_Add,id:7983,x:31107,y:32496,varname:node_7983,prsc:2|A-5006-U,B-6377-OUT;n:type:ShaderForge.SFN_Slider,id:9516,x:30316,y:32995,ptovrint:False,ptlb:glitchAmt,ptin:_glitchAmt,varname:node_9516,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Sin,id:9467,x:30623,y:32750,varname:node_9467,prsc:2|IN-1347-OUT;n:type:ShaderForge.SFN_Multiply,id:7311,x:30374,y:32648,varname:node_7311,prsc:2|A-5006-V,B-7059-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7059,x:30359,y:32560,ptovrint:False,ptlb:glitchSize,ptin:_glitchSize,varname:node_7059,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:20;n:type:ShaderForge.SFN_Multiply,id:6377,x:30890,y:32723,varname:node_6377,prsc:2|A-9467-OUT,B-9516-OUT;n:type:ShaderForge.SFN_Append,id:1010,x:31354,y:32898,varname:node_1010,prsc:2|A-7983-OUT,B-5006-V;n:type:ShaderForge.SFN_Vector1,id:3385,x:31942,y:33563,varname:node_3385,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:3788,x:32006,y:33627,varname:node_3788,prsc:2,v1:1;n:type:ShaderForge.SFN_Add,id:1347,x:30445,y:32777,varname:node_1347,prsc:2|A-7311-OUT,B-4003-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8219,x:30071,y:32645,ptovrint:False,ptlb:glitchAnimSpeed,ptin:_glitchAnimSpeed,varname:node_8219,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:4003,x:30199,y:32818,varname:node_4003,prsc:2|A-8219-OUT,B-8662-T;n:type:ShaderForge.SFN_Time,id:8662,x:29997,y:32944,varname:node_8662,prsc:2;n:type:ShaderForge.SFN_Panner,id:460,x:31680,y:32893,varname:node_460,prsc:2,spu:1,spv:0|UVIN-1010-OUT,DIST-1780-OUT;n:type:ShaderForge.SFN_Time,id:8103,x:31214,y:32623,varname:node_8103,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1780,x:31495,y:32776,varname:node_1780,prsc:2|A-8103-T,B-8002-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8002,x:31275,y:32797,ptovrint:False,ptlb:scrollSpeed,ptin:_scrollSpeed,varname:node_8002,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Color,id:5195,x:31987,y:32770,ptovrint:False,ptlb:colorChange,ptin:_colorChange,varname:node_5195,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:9182,x:32090,y:32954,varname:node_9182,prsc:2|A-5195-RGB,B-8666-RGB;proporder:1304-8666-6482-7603-8913-3531-9595-5620-3250-2825-4153-2445-9516-7059-8219-8002-5195;pass:END;sub:END;*/

Shader "Shader Forge/CRTShaderForge" {
    Properties {
        _Color ("Color", Color) = (0,0,0,1)
        _tex ("tex", 2D) = "white" {}
        _textureSize ("textureSize", Float ) = 256
        _influence ("influence", Range(0, 1)) = 0.6637568
        _gamma ("gamma", Float ) = 1.2
        _scanLineSize ("scanLineSize", Float ) = 256
        _scanLineBrightness ("scanLineBrightness", Range(0, 1)) = 0.6675796
        _largeScanSize ("largeScanSize", Float ) = 7
        _largeScanSpeed ("largeScanSpeed", Float ) = -1
        _largeScanAmt ("largeScanAmt", Range(0, 1)) = 0.9052682
        _largeScanFalloff ("largeScanFalloff", Float ) = 4
        _monitorShiny ("monitorShiny", Range(0, 1)) = 0
        _glitchAmt ("glitchAmt", Range(0, 1)) = 0
        _glitchSize ("glitchSize", Float ) = 20
        _glitchAnimSpeed ("glitchAnimSpeed", Float ) = 0
        _scrollSpeed ("scrollSpeed", Float ) = 0
        _colorChange ("colorChange", Color) = (1,1,1,1)
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
            uniform sampler2D _tex; uniform float4 _tex_ST;
            uniform float _textureSize;
            uniform float _influence;
            uniform float _gamma;
            uniform float _scanLineSize;
            uniform float _scanLineBrightness;
            uniform float _largeScanSize;
            uniform float _largeScanSpeed;
            uniform float _largeScanAmt;
            uniform float _largeScanFalloff;
            uniform float _monitorShiny;
            uniform float _glitchAmt;
            uniform float _glitchSize;
            uniform float _glitchAnimSpeed;
            uniform float _scrollSpeed;
            uniform float4 _colorChange;
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
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_monitorShiny,_monitorShiny,_monitorShiny);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = _Color.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 node_8103 = _Time;
                float4 node_8662 = _Time;
                float2 node_460 = (float2((i.uv0.r+(sin(((i.uv0.g*_glitchSize)+(_glitchAnimSpeed*node_8662.g)))*_glitchAmt)),i.uv0.g)+(node_8103.g*_scrollSpeed)*float2(1,0));
                float4 _tex_var = tex2D(_tex,TRANSFORM_TEX(node_460, _tex));
                float node_3493 = round(fmod(round((i.uv0.r*_textureSize)),3.0));
                float node_1311_if_leA = step(node_3493,0.0);
                float node_1311_if_leB = step(0.0,node_3493);
                float node_9616 = 0.0;
                float node_2279 = 1.0;
                float node_8627_if_leA = step(node_3493,1.0);
                float node_8627_if_leB = step(1.0,node_3493);
                float node_2567_if_leA = step(node_3493,2.0);
                float node_2567_if_leB = step(2.0,node_3493);
                float node_1351_if_leA = step(round(fmod((_scanLineSize*i.uv0.g),3.0)),1.0);
                float node_1351_if_leB = step(1.0,round(fmod((_scanLineSize*i.uv0.g),3.0)));
                float node_4411 = 0.0;
                float4 node_5523 = _Time;
                float3 emissive = (_gamma*lerp(float3((_tex_var.r*lerp((node_1311_if_leA*node_9616)+(node_1311_if_leB*node_9616),node_2279,node_1311_if_leA*node_1311_if_leB)),(_tex_var.g*lerp((node_8627_if_leA*node_9616)+(node_8627_if_leB*node_9616),node_2279,node_8627_if_leA*node_8627_if_leB)),(_tex_var.b*lerp((node_2567_if_leA*node_9616)+(node_2567_if_leB*node_9616),node_2279,node_2567_if_leA*node_2567_if_leB))),(_colorChange.rgb*_tex_var.rgb),_influence)*saturate(((1.0 - saturate(lerp((node_1351_if_leA*node_4411)+(node_1351_if_leB*node_4411),1.0,node_1351_if_leA*node_1351_if_leB)))+_scanLineBrightness))*saturate((_largeScanAmt+pow((sin(((_largeScanSize*i.uv0.g)+(_largeScanSpeed*node_5523.g)))*0.5+0.5),_largeScanFalloff))));
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
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
            uniform sampler2D _tex; uniform float4 _tex_ST;
            uniform float _textureSize;
            uniform float _influence;
            uniform float _gamma;
            uniform float _scanLineSize;
            uniform float _scanLineBrightness;
            uniform float _largeScanSize;
            uniform float _largeScanSpeed;
            uniform float _largeScanAmt;
            uniform float _largeScanFalloff;
            uniform float _monitorShiny;
            uniform float _glitchAmt;
            uniform float _glitchSize;
            uniform float _glitchAnimSpeed;
            uniform float _scrollSpeed;
            uniform float4 _colorChange;
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
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_monitorShiny,_monitorShiny,_monitorShiny);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = _Color.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
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
