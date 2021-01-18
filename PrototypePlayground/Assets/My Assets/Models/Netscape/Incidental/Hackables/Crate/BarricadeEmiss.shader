// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-5848-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:31833,y:32953,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Tex2d,id:4851,x:31833,y:33116,ptovrint:False,ptlb:text,ptin:_text,varname:node_4851,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9dbffe62f414d6a478c0b5ee8dd599c9,ntxv:0,isnm:False|UVIN-3592-UVOUT;n:type:ShaderForge.SFN_Multiply,id:8332,x:32045,y:32953,varname:node_8332,prsc:2|A-7241-RGB,B-4851-RGB,C-72-OUT;n:type:ShaderForge.SFN_Multiply,id:3382,x:32229,y:32587,varname:node_3382,prsc:2|A-8397-RGB,B-4365-OUT,C-5176-RGB;n:type:ShaderForge.SFN_Slider,id:4365,x:31817,y:32692,ptovrint:False,ptlb:noiseStrength,ptin:_noiseStrength,varname:node_4365,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:8397,x:31817,y:32509,ptovrint:False,ptlb:noiseTex,ptin:_noiseTex,varname:node_8397,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e8b94923ed8eb2b43ba3f9b32ee06bee,ntxv:0,isnm:False|UVIN-3125-UVOUT;n:type:ShaderForge.SFN_Color,id:5176,x:31974,y:32406,ptovrint:False,ptlb:backColor,ptin:_backColor,varname:node_5176,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Lerp,id:5848,x:32393,y:32901,varname:node_5848,prsc:2|A-3382-OUT,B-1279-OUT,T-4851-R;n:type:ShaderForge.SFN_Panner,id:3125,x:31587,y:32509,varname:node_3125,prsc:2,spu:1,spv:1|UVIN-108-UVOUT,DIST-7965-OUT;n:type:ShaderForge.SFN_TexCoord,id:108,x:31376,y:32509,varname:node_108,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:8937,x:31239,y:32655,varname:node_8937,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7965,x:31417,y:32655,varname:node_7965,prsc:2|A-8937-T,B-8763-OUT;n:type:ShaderForge.SFN_Vector1,id:8763,x:31239,y:32790,varname:node_8763,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Slider,id:3044,x:31817,y:32786,ptovrint:False,ptlb:textNoiseStrength,ptin:_textNoiseStrength,varname:node_3044,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:1309,x:32171,y:32790,varname:node_1309,prsc:2|A-3044-OUT,B-8397-R;n:type:ShaderForge.SFN_Subtract,id:1279,x:32239,y:32953,varname:node_1279,prsc:2|A-8332-OUT,B-1309-OUT;n:type:ShaderForge.SFN_Panner,id:3592,x:31642,y:33116,varname:node_3592,prsc:2,spu:1,spv:0|UVIN-6684-UVOUT,DIST-8878-OUT;n:type:ShaderForge.SFN_TexCoord,id:6684,x:31423,y:33116,varname:node_6684,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:7458,x:31289,y:33273,varname:node_7458,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:9824,x:31289,y:33413,ptovrint:False,ptlb:scrollSpeed,ptin:_scrollSpeed,varname:node_9824,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:8878,x:31464,y:33273,varname:node_8878,prsc:2|A-7458-T,B-9824-OUT;n:type:ShaderForge.SFN_TexCoord,id:5405,x:31833,y:33283,varname:node_5405,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Sin,id:9433,x:32193,y:33324,varname:node_9433,prsc:2|IN-6058-OUT;n:type:ShaderForge.SFN_Multiply,id:6058,x:32026,y:33324,varname:node_6058,prsc:2|A-5405-V,B-2647-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2647,x:31832,y:33470,ptovrint:False,ptlb:scanlineTile,ptin:_scanlineTile,varname:node_2647,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;n:type:ShaderForge.SFN_Slider,id:8705,x:32039,y:33570,ptovrint:False,ptlb:scanLineStrength,ptin:_scanLineStrength,varname:node_8705,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_RemapRange,id:4934,x:32380,y:33324,varname:node_4934,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-9433-OUT;n:type:ShaderForge.SFN_Add,id:159,x:32577,y:33324,varname:node_159,prsc:2|A-4934-OUT,B-5004-OUT;n:type:ShaderForge.SFN_OneMinus,id:5004,x:32380,y:33565,varname:node_5004,prsc:2|IN-8705-OUT;n:type:ShaderForge.SFN_Clamp01,id:3230,x:32758,y:33324,varname:node_3230,prsc:2|IN-159-OUT;n:type:ShaderForge.SFN_Set,id:8510,x:32930,y:33324,varname:scanlines,prsc:2|IN-3230-OUT;n:type:ShaderForge.SFN_Get,id:72,x:32202,y:33190,varname:node_72,prsc:2|IN-8510-OUT;proporder:7241-4851-4365-8397-5176-3044-9824-2647-8705;pass:END;sub:END;*/

Shader "Shader Forge/BarricadeEmiss" {
    Properties {
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _text ("text", 2D) = "white" {}
        _noiseStrength ("noiseStrength", Range(0, 1)) = 0
        _noiseTex ("noiseTex", 2D) = "white" {}
        _backColor ("backColor", Color) = (0.5,0.5,0.5,1)
        _textNoiseStrength ("textNoiseStrength", Range(0, 1)) = 0
        _scrollSpeed ("scrollSpeed", Float ) = 0
        _scanlineTile ("scanlineTile", Float ) = 4
        _scanLineStrength ("scanLineStrength", Range(0, 1)) = 1
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
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _text; uniform float4 _text_ST;
            uniform float _noiseStrength;
            uniform sampler2D _noiseTex; uniform float4 _noiseTex_ST;
            uniform float4 _backColor;
            uniform float _textNoiseStrength;
            uniform float _scrollSpeed;
            uniform float _scanlineTile;
            uniform float _scanLineStrength;
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
////// Lighting:
////// Emissive:
                float4 node_8937 = _Time;
                float2 node_3125 = (i.uv0+(node_8937.g*0.5)*float2(1,1));
                float4 _noiseTex_var = tex2D(_noiseTex,TRANSFORM_TEX(node_3125, _noiseTex));
                float4 node_7458 = _Time;
                float2 node_3592 = (i.uv0+(node_7458.g*_scrollSpeed)*float2(1,0));
                float4 _text_var = tex2D(_text,TRANSFORM_TEX(node_3592, _text));
                float node_9433 = sin((i.uv0.g*_scanlineTile));
                float scanlines = saturate(((node_9433*0.5+0.5)+(1.0 - _scanLineStrength)));
                float3 node_8332 = (_Color.rgb*_text_var.rgb*scanlines);
                float3 emissive = lerp((_noiseTex_var.rgb*_noiseStrength*_backColor.rgb),(node_8332-(_textNoiseStrength*_noiseTex_var.r)),_text_var.r);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
