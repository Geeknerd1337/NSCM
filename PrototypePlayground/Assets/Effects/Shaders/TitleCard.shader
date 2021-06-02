// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-173-OUT,alpha-995-OUT,clip-8389-OUT;n:type:ShaderForge.SFN_Tex2d,id:5619,x:32191,y:32759,ptovrint:False,ptlb:tex,ptin:_tex,varname:node_5619,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d3b5c3c577b333c4f9b286929d6bf957,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5981,x:32018,y:33019,ptovrint:False,ptlb:diss,ptin:_diss,varname:node_5981,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c87514d84c519ac418ea7ee923f65f1d,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:8389,x:32249,y:33140,varname:node_8389,prsc:2|A-5981-R,B-7488-OUT;n:type:ShaderForge.SFN_Slider,id:7488,x:31891,y:33214,ptovrint:False,ptlb:0,ptin:_0,varname:node_7488,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:2,max:2;n:type:ShaderForge.SFN_Color,id:8045,x:32191,y:32934,ptovrint:False,ptlb:col,ptin:_col,varname:node_8045,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:173,x:32445,y:32916,varname:node_173,prsc:2|A-5619-R,B-8045-RGB,C-8389-OUT;n:type:ShaderForge.SFN_Multiply,id:995,x:32445,y:33044,varname:node_995,prsc:2|A-8045-A,B-5619-A;proporder:5619-5981-7488-8045;pass:END;sub:END;*/

Shader "Shader Forge/TitleCard" {
    Properties {
        _tex ("tex", 2D) = "white" {}
        _diss ("diss", 2D) = "white" {}
        _0 ("0", Range(-1, 2)) = 2
        _col ("col", Color) = (1,1,1,1)
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
            uniform sampler2D _tex; uniform float4 _tex_ST;
            uniform sampler2D _diss; uniform float4 _diss_ST;
            uniform float _0;
            uniform float4 _col;
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
                float4 _diss_var = tex2D(_diss,TRANSFORM_TEX(i.uv0, _diss));
                float node_8389 = (_diss_var.r+_0);
                clip(node_8389 - 0.5);
////// Lighting:
////// Emissive:
                float4 _tex_var = tex2D(_tex,TRANSFORM_TEX(i.uv0, _tex));
                float3 emissive = (_tex_var.r*_col.rgb*node_8389);
                float3 finalColor = emissive;
                return fixed4(finalColor,(_col.a*_tex_var.a));
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
            uniform sampler2D _diss; uniform float4 _diss_ST;
            uniform float _0;
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
                float4 _diss_var = tex2D(_diss,TRANSFORM_TEX(i.uv0, _diss));
                float node_8389 = (_diss_var.r+_0);
                clip(node_8389 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
