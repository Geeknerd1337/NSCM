// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-7348-OUT,alpha-399-OUT,clip-516-OUT;n:type:ShaderForge.SFN_Slider,id:3627,x:31288,y:33034,ptovrint:False,ptlb:amount,ptin:_amount,varname:node_3627,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3779198,max:1;n:type:ShaderForge.SFN_TexCoord,id:1448,x:31445,y:32846,varname:node_1448,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Step,id:399,x:32131,y:33123,varname:node_399,prsc:2|A-3627-OUT,B-1629-OUT;n:type:ShaderForge.SFN_Append,id:5831,x:32101,y:32811,varname:node_5831,prsc:2|A-1448-U,B-818-OUT;n:type:ShaderForge.SFN_Tex2d,id:3073,x:32290,y:32811,ptovrint:False,ptlb:tex,ptin:_tex,varname:node_3073,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:87412b021f67f5e439dbc652dd3c2025,ntxv:0,isnm:False|UVIN-5831-OUT;n:type:ShaderForge.SFN_Subtract,id:818,x:31677,y:32886,varname:node_818,prsc:2|A-1448-V,B-3627-OUT;n:type:ShaderForge.SFN_Tex2d,id:3832,x:31317,y:32471,ptovrint:False,ptlb:noise,ptin:_noise,varname:node_3832,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:87412b021f67f5e439dbc652dd3c2025,ntxv:0,isnm:False|UVIN-610-OUT;n:type:ShaderForge.SFN_Slider,id:4194,x:31716,y:32275,ptovrint:False,ptlb:noiseSlide,ptin:_noiseSlide,varname:node_4194,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8456076,max:1;n:type:ShaderForge.SFN_Multiply,id:1368,x:31677,y:32676,varname:node_1368,prsc:2|A-4194-OUT,B-1670-OUT;n:type:ShaderForge.SFN_TexCoord,id:5612,x:30511,y:32514,varname:node_5612,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Vector1,id:6629,x:30942,y:32777,varname:node_6629,prsc:2,v1:0;n:type:ShaderForge.SFN_Append,id:610,x:31157,y:32675,varname:node_610,prsc:2|A-8424-R,B-6629-OUT;n:type:ShaderForge.SFN_TexCoord,id:5631,x:31987,y:32226,varname:node_5631,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:1629,x:31869,y:33023,varname:node_1629,prsc:2|A-1368-OUT,B-818-OUT;n:type:ShaderForge.SFN_Panner,id:5495,x:30901,y:32527,varname:node_5495,prsc:2,spu:1,spv:1|UVIN-5612-UVOUT,DIST-6254-OUT;n:type:ShaderForge.SFN_ComponentMask,id:8424,x:30967,y:32309,varname:node_8424,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-5495-UVOUT;n:type:ShaderForge.SFN_ValueProperty,id:1774,x:30511,y:32683,ptovrint:False,ptlb:spawnerNoiseSpeed,ptin:_spawnerNoiseSpeed,varname:node_1774,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:6254,x:30720,y:32683,varname:node_6254,prsc:2|A-1774-OUT,B-8631-T;n:type:ShaderForge.SFN_Time,id:8631,x:30511,y:32811,varname:node_8631,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:8479,x:31317,y:32277,ptovrint:False,ptlb:secondNoise,ptin:_secondNoise,varname:node_8479,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:87412b021f67f5e439dbc652dd3c2025,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:2555,x:31558,y:32460,varname:node_2555,prsc:2|A-8479-R,B-3832-R;n:type:ShaderForge.SFN_Divide,id:1670,x:31909,y:32488,varname:node_1670,prsc:2|A-2555-OUT,B-4493-OUT;n:type:ShaderForge.SFN_Vector1,id:4493,x:31701,y:32522,varname:node_4493,prsc:2,v1:2;n:type:ShaderForge.SFN_Color,id:2106,x:32200,y:32608,ptovrint:False,ptlb:textureColsnm,ptin:_textureColsnm,varname:node_2106,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Add,id:4391,x:32409,y:32645,varname:node_4391,prsc:2|A-2106-RGB,B-3073-RGB;n:type:ShaderForge.SFN_Multiply,id:1468,x:32628,y:32645,varname:node_1468,prsc:2|A-6430-OUT,B-4391-OUT;n:type:ShaderForge.SFN_Slider,id:6430,x:32386,y:32558,ptovrint:False,ptlb:TextureAmt,ptin:_TextureAmt,varname:node_6430,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Color,id:4542,x:32168,y:32977,ptovrint:False,ptlb:emissColor,ptin:_emissColor,varname:node_4542,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Add,id:9129,x:32445,y:33113,varname:node_9129,prsc:2|A-1468-OUT,B-4542-RGB;n:type:ShaderForge.SFN_Color,id:3268,x:32131,y:33277,ptovrint:False,ptlb:edgeColor,ptin:_edgeColor,varname:node_3268,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Slider,id:6820,x:31974,y:33452,ptovrint:False,ptlb:edgeWidth,ptin:_edgeWidth,varname:node_6820,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6375977,max:1;n:type:ShaderForge.SFN_Tex2d,id:8008,x:32131,y:33552,ptovrint:False,ptlb:dissolveTex,ptin:_dissolveTex,varname:node_8008,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:87412b021f67f5e439dbc652dd3c2025,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:2639,x:31859,y:33733,ptovrint:False,ptlb:dissolveAmt,ptin:_dissolveAmt,varname:node_2639,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_RemapRange,id:613,x:32301,y:33751,varname:node_613,prsc:2,frmn:0,frmx:1,tomn:-0.6910348,tomx:0.2545918|IN-2639-OUT;n:type:ShaderForge.SFN_Subtract,id:516,x:32437,y:33521,varname:node_516,prsc:2|A-8008-R,B-613-OUT;n:type:ShaderForge.SFN_Multiply,id:3797,x:32474,y:33304,varname:node_3797,prsc:2|A-3268-R,B-644-OUT;n:type:ShaderForge.SFN_Step,id:4252,x:32649,y:33670,varname:node_4252,prsc:2|A-516-OUT,B-6820-OUT;n:type:ShaderForge.SFN_Lerp,id:7348,x:32701,y:33205,varname:node_7348,prsc:2|A-9129-OUT,B-3268-RGB,T-4252-OUT;n:type:ShaderForge.SFN_OneMinus,id:644,x:32850,y:33670,varname:node_644,prsc:2|IN-4252-OUT;proporder:3627-3073-3832-4194-1774-8479-2106-6430-4542-8008-2639-3268-6820;pass:END;sub:END;*/

Shader "Shader Forge/SpawnCylinderShader" {
    Properties {
        _amount ("amount", Range(0, 1)) = 0.3779198
        _tex ("tex", 2D) = "white" {}
        _noise ("noise", 2D) = "white" {}
        _noiseSlide ("noiseSlide", Range(0, 1)) = 0.8456076
        _spawnerNoiseSpeed ("spawnerNoiseSpeed", Float ) = 0
        _secondNoise ("secondNoise", 2D) = "white" {}
        _textureColsnm ("textureColsnm", Color) = (0.5,0.5,0.5,1)
        _TextureAmt ("TextureAmt", Range(0, 1)) = 1
        _emissColor ("emissColor", Color) = (0.5,0.5,0.5,1)
        _dissolveTex ("dissolveTex", 2D) = "white" {}
        _dissolveAmt ("dissolveAmt", Range(0, 1)) = 0
        _edgeColor ("edgeColor", Color) = (1,0,0,1)
        _edgeWidth ("edgeWidth", Range(0, 1)) = 0.6375977
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite On
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _amount;
            uniform sampler2D _tex; uniform float4 _tex_ST;
            uniform sampler2D _noise; uniform float4 _noise_ST;
            uniform float _noiseSlide;
            uniform float _spawnerNoiseSpeed;
            uniform sampler2D _secondNoise; uniform float4 _secondNoise_ST;
            uniform float4 _textureColsnm;
            uniform float _TextureAmt;
            uniform float4 _emissColor;
            uniform float4 _edgeColor;
            uniform float _edgeWidth;
            uniform sampler2D _dissolveTex; uniform float4 _dissolveTex_ST;
            uniform float _dissolveAmt;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _dissolveTex_var = tex2D(_dissolveTex,TRANSFORM_TEX(i.uv0, _dissolveTex));
                float node_516 = (_dissolveTex_var.r-(_dissolveAmt*0.9456266+-0.6910348));
                clip(node_516 - 0.5);
////// Lighting:
////// Emissive:
                float node_818 = (i.uv0.g-_amount);
                float2 node_5831 = float2(i.uv0.r,node_818);
                float4 _tex_var = tex2D(_tex,TRANSFORM_TEX(node_5831, _tex));
                float node_4252 = step(node_516,_edgeWidth);
                float3 emissive = lerp(((_TextureAmt*(_textureColsnm.rgb+_tex_var.rgb))+_emissColor.rgb),_edgeColor.rgb,node_4252);
                float3 finalColor = emissive;
                float4 _secondNoise_var = tex2D(_secondNoise,TRANSFORM_TEX(i.uv0, _secondNoise));
                float4 node_8631 = _Time;
                float2 node_610 = float2((i.uv0+(_spawnerNoiseSpeed*node_8631.g)*float2(1,1)).rg.r,0.0);
                float4 _noise_var = tex2D(_noise,TRANSFORM_TEX(node_610, _noise));
                return fixed4(finalColor,step(_amount,((_noiseSlide*((_secondNoise_var.r+_noise_var.r)/2.0))+node_818)));
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
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _dissolveTex; uniform float4 _dissolveTex_ST;
            uniform float _dissolveAmt;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _dissolveTex_var = tex2D(_dissolveTex,TRANSFORM_TEX(i.uv0, _dissolveTex));
                float node_516 = (_dissolveTex_var.r-(_dissolveAmt*0.9456266+-0.6910348));
                clip(node_516 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
