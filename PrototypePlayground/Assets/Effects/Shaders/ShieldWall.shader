// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-1542-OUT,alpha-5932-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:31886,y:32754,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:8428,x:31959,y:32921,ptovrint:False,ptlb:tex,ptin:_tex,varname:node_8428,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2c593d5b42484fa47a53b5d170ac5784,ntxv:0,isnm:False|UVIN-5646-UVOUT;n:type:ShaderForge.SFN_Multiply,id:7761,x:32325,y:32864,varname:node_7761,prsc:2|A-7241-RGB,B-7648-OUT;n:type:ShaderForge.SFN_Multiply,id:1542,x:32489,y:32770,varname:node_1542,prsc:2|A-7761-OUT,B-2714-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2714,x:32147,y:32720,ptovrint:False,ptlb:emiss,ptin:_emiss,varname:node_2714,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Slider,id:668,x:31950,y:33234,ptovrint:False,ptlb:baseOpp,ptin:_baseOpp,varname:node_668,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_ComponentMask,id:5932,x:32495,y:33146,varname:node_5932,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-7648-OUT;n:type:ShaderForge.SFN_Panner,id:5646,x:31640,y:32898,varname:node_5646,prsc:2,spu:1,spv:1|UVIN-6045-UVOUT,DIST-7918-OUT;n:type:ShaderForge.SFN_TexCoord,id:6045,x:31353,y:32862,varname:node_6045,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:9384,x:31257,y:33020,varname:node_9384,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7918,x:31464,y:33032,varname:node_7918,prsc:2|A-9384-T,B-9556-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9556,x:31257,y:33177,ptovrint:False,ptlb:speed,ptin:_speed,varname:node_9556,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Add,id:7648,x:32121,y:32921,varname:node_7648,prsc:2|A-8428-RGB,B-668-OUT;proporder:7241-8428-2714-668-9556;pass:END;sub:END;*/

Shader "Shader Forge/ShieldWall" {
    Properties {
        [HDR]_Color ("Color", Color) = (1,1,1,1)
        _tex ("tex", 2D) = "white" {}
        _emiss ("emiss", Float ) = 1
        _baseOpp ("baseOpp", Range(0, 1)) = 0
        _speed ("speed", Float ) = 0
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
            uniform float4 _Color;
            uniform sampler2D _tex; uniform float4 _tex_ST;
            uniform float _emiss;
            uniform float _baseOpp;
            uniform float _speed;
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
                float4 node_9384 = _Time;
                float2 node_5646 = (i.uv0+(node_9384.g*_speed)*float2(1,1));
                float4 _tex_var = tex2D(_tex,TRANSFORM_TEX(node_5646, _tex));
                float3 node_7648 = (_tex_var.rgb+_baseOpp);
                float3 emissive = ((_Color.rgb*node_7648)*_emiss);
                float3 finalColor = emissive;
                return fixed4(finalColor,node_7648.r);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
