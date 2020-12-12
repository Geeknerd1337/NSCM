// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-723-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32002,y:32759,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.375534,c2:0.8207547,c3:0.4034662,c4:1;n:type:ShaderForge.SFN_TexCoord,id:9926,x:31727,y:32975,varname:node_9926,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:6939,x:31570,y:33154,ptovrint:False,ptlb:amt,ptin:_amt,varname:node_6939,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6666667,max:1;n:type:ShaderForge.SFN_Step,id:4793,x:31993,y:32973,varname:node_4793,prsc:2|A-9926-U,B-6939-OUT;n:type:ShaderForge.SFN_Tex2d,id:3344,x:31993,y:33173,ptovrint:False,ptlb:noiseTex,ptin:_noiseTex,varname:node_3344,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3b790006c63b85f44bc5712013fc7fdf,ntxv:0,isnm:False|UVIN-8669-UVOUT;n:type:ShaderForge.SFN_ValueProperty,id:4873,x:31727,y:33250,ptovrint:False,ptlb:noiseSpeed,ptin:_noiseSpeed,varname:node_4873,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Time,id:5065,x:31532,y:33321,varname:node_5065,prsc:2;n:type:ShaderForge.SFN_Panner,id:8669,x:31976,y:33360,varname:node_8669,prsc:2,spu:1,spv:1|UVIN-9926-UVOUT,DIST-9236-OUT;n:type:ShaderForge.SFN_Multiply,id:9236,x:31765,y:33458,varname:node_9236,prsc:2|A-4873-OUT,B-5065-T;n:type:ShaderForge.SFN_Multiply,id:3729,x:32342,y:33161,varname:node_3729,prsc:2|A-3346-OUT,B-3344-RGB;n:type:ShaderForge.SFN_Slider,id:3346,x:32111,y:33303,ptovrint:False,ptlb:noiseAmt,ptin:_noiseAmt,varname:node_3346,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6495737,max:1;n:type:ShaderForge.SFN_Multiply,id:723,x:32388,y:32908,varname:node_723,prsc:2|A-7241-RGB,B-3060-OUT;n:type:ShaderForge.SFN_Add,id:3060,x:32196,y:33008,varname:node_3060,prsc:2|A-4255-OUT,B-3729-OUT;n:type:ShaderForge.SFN_Fmod,id:6688,x:31816,y:32723,varname:node_6688,prsc:2|A-9926-U,B-7570-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9313,x:31430,y:32667,ptovrint:False,ptlb:bars,ptin:_bars,varname:node_9313,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3;n:type:ShaderForge.SFN_Divide,id:7570,x:31606,y:32717,varname:node_7570,prsc:2|A-2271-OUT,B-9313-OUT;n:type:ShaderForge.SFN_Vector1,id:2271,x:31383,y:32768,varname:node_2271,prsc:2,v1:1;n:type:ShaderForge.SFN_Step,id:9105,x:32082,y:32522,varname:node_9105,prsc:2|A-6688-OUT,B-4039-OUT;n:type:ShaderForge.SFN_Slider,id:4039,x:31638,y:32540,ptovrint:False,ptlb:barWidth,ptin:_barWidth,varname:node_4039,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2478638,max:1;n:type:ShaderForge.SFN_Multiply,id:4255,x:32280,y:32668,varname:node_4255,prsc:2|A-9105-OUT,B-4793-OUT;proporder:7241-6939-3344-4873-3346-9313-4039;pass:END;sub:END;*/

Shader "Shader Forge/LoadingBar" {
    Properties {
        _Color ("Color", Color) = (0.375534,0.8207547,0.4034662,1)
        _amt ("amt", Range(0, 1)) = 0.6666667
        _noiseTex ("noiseTex", 2D) = "white" {}
        _noiseSpeed ("noiseSpeed", Float ) = 1
        _noiseAmt ("noiseAmt", Range(0, 1)) = 0.6495737
        _bars ("bars", Float ) = 3
        _barWidth ("barWidth", Range(0, 1)) = 0.2478638
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
            uniform float _amt;
            uniform sampler2D _noiseTex; uniform float4 _noiseTex_ST;
            uniform float _noiseSpeed;
            uniform float _noiseAmt;
            uniform float _bars;
            uniform float _barWidth;
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
                float4 node_5065 = _Time;
                float2 node_8669 = (i.uv0+(_noiseSpeed*node_5065.g)*float2(1,1));
                float4 _noiseTex_var = tex2D(_noiseTex,TRANSFORM_TEX(node_8669, _noiseTex));
                float3 emissive = (_Color.rgb*((step(fmod(i.uv0.r,(1.0/_bars)),_barWidth)*step(i.uv0.r,_amt))+(_noiseAmt*_noiseTex_var.rgb)));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
