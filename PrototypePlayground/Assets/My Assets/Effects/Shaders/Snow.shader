// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|diff-1304-RGB,emission-2771-OUT,alpha-3461-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:32393,y:32518,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Slider,id:28,x:32204,y:33311,ptovrint:False,ptlb:base_opacity,ptin:_base_opacity,varname:node_28,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Tex2d,id:9264,x:31646,y:32391,ptovrint:False,ptlb:firstSnow,ptin:_firstSnow,varname:node_9264,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d196ff2f4c4c45444950dd8153174dcb,ntxv:0,isnm:False|UVIN-1363-UVOUT;n:type:ShaderForge.SFN_Add,id:2324,x:32479,y:33131,varname:node_2324,prsc:2|A-2763-OUT,B-28-OUT;n:type:ShaderForge.SFN_Add,id:4366,x:32119,y:32733,varname:node_4366,prsc:2|A-334-OUT,B-1866-OUT,C-9278-OUT,D-3424-OUT,E-2261-OUT;n:type:ShaderForge.SFN_Slider,id:1866,x:31648,y:32855,ptovrint:False,ptlb:emissOpac,ptin:_emissOpac,varname:node_1866,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_ComponentMask,id:2763,x:32234,y:33083,varname:node_2763,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-4366-OUT;n:type:ShaderForge.SFN_Panner,id:1363,x:31646,y:32628,varname:node_1363,prsc:2,spu:0,spv:1|UVIN-2283-UVOUT,DIST-5985-OUT;n:type:ShaderForge.SFN_TexCoord,id:2283,x:31355,y:32626,varname:node_2283,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:9752,x:31355,y:32788,varname:node_9752,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:1590,x:31355,y:32956,ptovrint:False,ptlb:speed1,ptin:_speed1,varname:node_1590,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:5985,x:31515,y:32749,varname:node_5985,prsc:2|A-9752-T,B-1590-OUT;n:type:ShaderForge.SFN_Tex2d,id:4352,x:31851,y:32936,ptovrint:False,ptlb:secondSnow,ptin:_secondSnow,varname:node_4352,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d196ff2f4c4c45444950dd8153174dcb,ntxv:0,isnm:False|UVIN-8638-UVOUT;n:type:ShaderForge.SFN_Panner,id:8638,x:31648,y:32936,varname:node_8638,prsc:2,spu:0,spv:1|UVIN-2283-UVOUT,DIST-2497-OUT;n:type:ShaderForge.SFN_ValueProperty,id:754,x:31288,y:33048,ptovrint:False,ptlb:speed2,ptin:_speed2,varname:node_754,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Time,id:2193,x:31288,y:33116,varname:node_2193,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2497,x:31457,y:33048,varname:node_2497,prsc:2|A-754-OUT,B-2193-T;n:type:ShaderForge.SFN_Multiply,id:9278,x:31979,y:32877,varname:node_9278,prsc:2|A-4352-RGB,B-380-OUT;n:type:ShaderForge.SFN_Slider,id:380,x:31654,y:33116,ptovrint:False,ptlb:reduction,ptin:_reduction,varname:node_380,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2108342,max:1;n:type:ShaderForge.SFN_Tex2d,id:6963,x:31851,y:33255,ptovrint:False,ptlb:thirdSnow,ptin:_thirdSnow,varname:node_6963,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d196ff2f4c4c45444950dd8153174dcb,ntxv:0,isnm:False|UVIN-1500-UVOUT;n:type:ShaderForge.SFN_Panner,id:1500,x:31654,y:33251,varname:node_1500,prsc:2,spu:0,spv:1|UVIN-2283-UVOUT,DIST-5042-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4825,x:31254,y:33452,ptovrint:False,ptlb:speed3,ptin:_speed3,varname:node_4825,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:5042,x:31455,y:33353,varname:node_5042,prsc:2|A-2193-T,B-4825-OUT;n:type:ShaderForge.SFN_Slider,id:9822,x:31676,y:33450,ptovrint:False,ptlb:secondReduction,ptin:_secondReduction,varname:node_9822,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5332352,max:1;n:type:ShaderForge.SFN_Multiply,id:3424,x:32009,y:33093,varname:node_3424,prsc:2|A-6963-RGB,B-9822-OUT;n:type:ShaderForge.SFN_Color,id:1260,x:32158,y:32902,ptovrint:False,ptlb:glowColor,ptin:_glowColor,varname:node_1260,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:2771,x:32435,y:32785,varname:node_2771,prsc:2|A-4366-OUT,B-1260-RGB,C-3289-OUT;n:type:ShaderForge.SFN_Clamp01,id:3461,x:32484,y:32984,varname:node_3461,prsc:2|IN-2324-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3289,x:32349,y:32946,ptovrint:False,ptlb:emiss,ptin:_emiss,varname:node_3289,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Tex2d,id:7471,x:32013,y:32357,ptovrint:False,ptlb:base,ptin:_base,varname:node_7471,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:a069d44dbad921145ac466d32dd322d7,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:6189,x:31856,y:32533,ptovrint:False,ptlb:baseInfluence,ptin:_baseInfluence,varname:node_6189,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8376068,max:1;n:type:ShaderForge.SFN_Multiply,id:2261,x:32202,y:32483,varname:node_2261,prsc:2|A-7471-R,B-6189-OUT;n:type:ShaderForge.SFN_Slider,id:3038,x:31669,y:32749,ptovrint:False,ptlb:topReduction,ptin:_topReduction,varname:node_3038,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:334,x:31945,y:32650,varname:node_334,prsc:2|A-9264-RGB,B-3038-OUT;proporder:1304-28-9264-1866-1590-4352-754-380-6963-4825-9822-1260-3289-7471-6189-3038;pass:END;sub:END;*/

Shader "Shader Forge/Snow" {
    Properties {
        _Color ("Color", Color) = (0,0,0,1)
        _base_opacity ("base_opacity", Range(0, 1)) = 1
        _firstSnow ("firstSnow", 2D) = "white" {}
        _emissOpac ("emissOpac", Range(0, 1)) = 0
        _speed1 ("speed1", Float ) = 1
        _secondSnow ("secondSnow", 2D) = "white" {}
        _speed2 ("speed2", Float ) = 0.1
        _reduction ("reduction", Range(0, 1)) = 0.2108342
        _thirdSnow ("thirdSnow", 2D) = "white" {}
        _speed3 ("speed3", Float ) = 0
        _secondReduction ("secondReduction", Range(0, 1)) = 0.5332352
        [HDR]_glowColor ("glowColor", Color) = (1,1,1,1)
        _emiss ("emiss", Float ) = 1
        _base ("base", 2D) = "white" {}
        _baseInfluence ("baseInfluence", Range(0, 1)) = 0.8376068
        _topReduction ("topReduction", Range(0, 1)) = 1
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
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _Color;
            uniform float _base_opacity;
            uniform sampler2D _firstSnow; uniform float4 _firstSnow_ST;
            uniform float _emissOpac;
            uniform float _speed1;
            uniform sampler2D _secondSnow; uniform float4 _secondSnow_ST;
            uniform float _speed2;
            uniform float _reduction;
            uniform sampler2D _thirdSnow; uniform float4 _thirdSnow_ST;
            uniform float _speed3;
            uniform float _secondReduction;
            uniform float4 _glowColor;
            uniform float _emiss;
            uniform sampler2D _base; uniform float4 _base_ST;
            uniform float _baseInfluence;
            uniform float _topReduction;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_9752 = _Time;
                float2 node_1363 = (i.uv0+(node_9752.g*_speed1)*float2(0,1));
                float4 _firstSnow_var = tex2D(_firstSnow,TRANSFORM_TEX(node_1363, _firstSnow));
                float4 node_2193 = _Time;
                float2 node_8638 = (i.uv0+(_speed2*node_2193.g)*float2(0,1));
                float4 _secondSnow_var = tex2D(_secondSnow,TRANSFORM_TEX(node_8638, _secondSnow));
                float2 node_1500 = (i.uv0+(node_2193.g*_speed3)*float2(0,1));
                float4 _thirdSnow_var = tex2D(_thirdSnow,TRANSFORM_TEX(node_1500, _thirdSnow));
                float4 _base_var = tex2D(_base,TRANSFORM_TEX(i.uv0, _base));
                float3 node_4366 = ((_firstSnow_var.rgb*_topReduction)+_emissOpac+(_secondSnow_var.rgb*_reduction)+(_thirdSnow_var.rgb*_secondReduction)+(_base_var.r*_baseInfluence));
                float3 emissive = (node_4366*_glowColor.rgb*_emiss);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,saturate((node_4366.r+_base_opacity)));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
