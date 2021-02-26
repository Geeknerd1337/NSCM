// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-5902-OUT,alpha-7273-OUT;n:type:ShaderForge.SFN_TexCoord,id:4281,x:30345,y:32763,varname:node_4281,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:8651,x:29902,y:32977,ptovrint:False,ptlb:noise,ptin:_noise,varname:node_8651,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d55475573bb30964aa11ba213b34a723,ntxv:0,isnm:False|UVIN-4246-UVOUT;n:type:ShaderForge.SFN_Step,id:8270,x:30816,y:32822,varname:node_8270,prsc:2|A-8506-OUT,B-5070-OUT;n:type:ShaderForge.SFN_Step,id:7833,x:30816,y:32951,varname:node_7833,prsc:2|A-7627-OUT,B-8506-OUT;n:type:ShaderForge.SFN_Multiply,id:7700,x:31013,y:32879,varname:node_7700,prsc:2|A-8270-OUT,B-7833-OUT;n:type:ShaderForge.SFN_Vector1,id:610,x:30345,y:33100,varname:node_610,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Add,id:5070,x:30565,y:33100,varname:node_5070,prsc:2|A-610-OUT,B-4091-OUT;n:type:ShaderForge.SFN_Slider,id:4091,x:30188,y:33186,ptovrint:False,ptlb:width,ptin:_width,varname:node_4091,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6476226,max:1;n:type:ShaderForge.SFN_OneMinus,id:7627,x:30565,y:33252,varname:node_7627,prsc:2|IN-5070-OUT;n:type:ShaderForge.SFN_TexCoord,id:7647,x:29220,y:32906,varname:node_7647,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:7154,x:30297,y:32930,varname:node_7154,prsc:2|A-8651-R,B-980-OUT;n:type:ShaderForge.SFN_Slider,id:980,x:29745,y:33157,ptovrint:False,ptlb:distort,ptin:_distort,varname:node_980,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4017094,max:1;n:type:ShaderForge.SFN_Multiply,id:6282,x:29569,y:32793,varname:node_6282,prsc:2|A-7647-UVOUT,B-3874-OUT;n:type:ShaderForge.SFN_Slider,id:3874,x:29208,y:32782,ptovrint:False,ptlb:scale,ptin:_scale,varname:node_3874,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5003631,max:10;n:type:ShaderForge.SFN_Add,id:8506,x:30582,y:32726,varname:node_8506,prsc:2|A-4281-V,B-7154-OUT;n:type:ShaderForge.SFN_Panner,id:4246,x:29839,y:32760,varname:node_4246,prsc:2,spu:1,spv:1|UVIN-6282-OUT,DIST-3167-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2257,x:29220,y:33075,ptovrint:False,ptlb:animSpeed,ptin:_animSpeed,varname:node_2257,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:9742,x:29535,y:32978,varname:node_9742,prsc:2|A-2257-OUT,B-95-T;n:type:ShaderForge.SFN_Time,id:95,x:29220,y:33137,varname:node_95,prsc:2;n:type:ShaderForge.SFN_Set,id:6409,x:31292,y:33001,varname:set,prsc:2|IN-6327-R;n:type:ShaderForge.SFN_Get,id:8498,x:31450,y:33090,varname:node_8498,prsc:2|IN-6409-OUT;n:type:ShaderForge.SFN_Color,id:8192,x:31504,y:32667,ptovrint:False,ptlb:outCol,ptin:_outCol,varname:node_8192,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:7273,x:31938,y:33013,varname:node_7273,prsc:2|A-8498-OUT,B-8192-A;n:type:ShaderForge.SFN_Append,id:7988,x:30836,y:32601,varname:node_7988,prsc:2|A-4281-U,B-8506-OUT;n:type:ShaderForge.SFN_Tex2d,id:6327,x:31049,y:32665,ptovrint:False,ptlb:lightning,ptin:_lightning,varname:node_6327,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:cb57bdd132a131845bec894e4c1a011b,ntxv:0,isnm:False|UVIN-7988-OUT;n:type:ShaderForge.SFN_Color,id:3756,x:31504,y:32844,ptovrint:False,ptlb:inCol,ptin:_inCol,varname:node_3756,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Lerp,id:5902,x:32138,y:32685,varname:node_5902,prsc:2|A-4329-OUT,B-4255-OUT,T-8498-OUT;n:type:ShaderForge.SFN_Tex2d,id:6994,x:31473,y:33316,varname:node_6994,prsc:2,tex:54ac70b5a2b4a9f48b34f5ea03e3031b,ntxv:0,isnm:False|UVIN-9057-UVOUT,TEX-7473-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:7473,x:31123,y:33428,ptovrint:False,ptlb:binary,ptin:_binary,varname:node_7473,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:54ac70b5a2b4a9f48b34f5ea03e3031b,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Panner,id:9057,x:31308,y:33206,varname:node_9057,prsc:2,spu:1,spv:1|UVIN-8886-UVOUT,DIST-992-OUT;n:type:ShaderForge.SFN_Slider,id:7582,x:30737,y:33252,ptovrint:False,ptlb:textSpeed,ptin:_textSpeed,varname:node_7582,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:5;n:type:ShaderForge.SFN_TexCoord,id:8886,x:31121,y:33031,varname:node_8886,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:992,x:31060,y:33225,varname:node_992,prsc:2|A-7582-OUT,B-1174-T;n:type:ShaderForge.SFN_Time,id:1174,x:30863,y:33367,varname:node_1174,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:9396,x:31473,y:33454,varname:node_9396,prsc:2,tex:54ac70b5a2b4a9f48b34f5ea03e3031b,ntxv:0,isnm:False|UVIN-1178-UVOUT,TEX-7473-TEX;n:type:ShaderForge.SFN_Panner,id:1178,x:31308,y:33380,varname:node_1178,prsc:2,spu:0.5,spv:0.5|UVIN-8886-UVOUT,DIST-992-OUT;n:type:ShaderForge.SFN_Add,id:5180,x:31721,y:33375,varname:node_5180,prsc:2|A-6994-RGB,B-8101-OUT;n:type:ShaderForge.SFN_Multiply,id:8101,x:31635,y:33489,varname:node_8101,prsc:2|A-9396-RGB,B-1422-OUT;n:type:ShaderForge.SFN_Vector1,id:1422,x:31357,y:33600,varname:node_1422,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:4255,x:31963,y:32802,varname:node_4255,prsc:2|A-3756-RGB,B-5180-OUT;n:type:ShaderForge.SFN_ScreenPos,id:5785,x:30565,y:33725,varname:node_5785,prsc:2,sctp:1;n:type:ShaderForge.SFN_Multiply,id:4329,x:31897,y:32590,varname:node_4329,prsc:2|A-2590-OUT,B-8192-RGB;n:type:ShaderForge.SFN_ValueProperty,id:2590,x:31638,y:32414,ptovrint:False,ptlb:outGlow,ptin:_outGlow,varname:node_2590,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ObjectPosition,id:111,x:29111,y:32576,varname:node_111,prsc:2;n:type:ShaderForge.SFN_Add,id:795,x:29382,y:32578,varname:node_795,prsc:2|A-111-X,B-111-Y,C-111-Z;n:type:ShaderForge.SFN_Add,id:3167,x:29703,y:32558,varname:node_3167,prsc:2|A-795-OUT,B-9742-OUT;proporder:8651-4091-980-3874-2257-8192-6327-3756-7473-7582-2590;pass:END;sub:END;*/

Shader "Shader Forge/Lightning" {
    Properties {
        _noise ("noise", 2D) = "white" {}
        _width ("width", Range(0, 1)) = 0.6476226
        _distort ("distort", Range(0, 1)) = 0.4017094
        _scale ("scale", Range(0, 10)) = 0.5003631
        _animSpeed ("animSpeed", Float ) = 1
        _outCol ("outCol", Color) = (0.5,0.5,0.5,1)
        _lightning ("lightning", 2D) = "white" {}
        _inCol ("inCol", Color) = (0.5,0.5,0.5,1)
        _binary ("binary", 2D) = "white" {}
        _textSpeed ("textSpeed", Range(0, 5)) = 0
        _outGlow ("outGlow", Float ) = 1
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
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _noise; uniform float4 _noise_ST;
            uniform float _distort;
            uniform float _scale;
            uniform float _animSpeed;
            uniform float4 _outCol;
            uniform sampler2D _lightning; uniform float4 _lightning_ST;
            uniform float4 _inCol;
            uniform sampler2D _binary; uniform float4 _binary_ST;
            uniform float _textSpeed;
            uniform float _outGlow;
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
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
////// Lighting:
////// Emissive:
                float4 node_1174 = _Time;
                float node_992 = (_textSpeed*node_1174.g);
                float2 node_9057 = (i.uv0+node_992*float2(1,1));
                float4 node_6994 = tex2D(_binary,TRANSFORM_TEX(node_9057, _binary));
                float2 node_1178 = (i.uv0+node_992*float2(0.5,0.5));
                float4 node_9396 = tex2D(_binary,TRANSFORM_TEX(node_1178, _binary));
                float4 node_95 = _Time;
                float2 node_4246 = ((i.uv0*_scale)+((objPos.r+objPos.g+objPos.b)+(_animSpeed*node_95.g))*float2(1,1));
                float4 _noise_var = tex2D(_noise,TRANSFORM_TEX(node_4246, _noise));
                float node_8506 = (i.uv0.g+(_noise_var.r*_distort));
                float2 node_7988 = float2(i.uv0.r,node_8506);
                float4 _lightning_var = tex2D(_lightning,TRANSFORM_TEX(node_7988, _lightning));
                float set = _lightning_var.r;
                float node_8498 = set;
                float3 emissive = lerp((_outGlow*_outCol.rgb),(_inCol.rgb*(node_6994.rgb+(node_9396.rgb*0.5))),node_8498);
                float3 finalColor = emissive;
                return fixed4(finalColor,(node_8498*_outCol.a));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
