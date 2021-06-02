// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-9206-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32120,y:32968,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Slider,id:7297,x:31211,y:32869,ptovrint:False,ptlb:eyeOpen,ptin:_eyeOpen,varname:node_7297,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3717949,max:0.5;n:type:ShaderForge.SFN_TexCoord,id:2664,x:31368,y:32704,varname:node_2664,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Step,id:9462,x:31884,y:32916,varname:node_9462,prsc:2|A-2664-V,B-7297-OUT;n:type:ShaderForge.SFN_Step,id:4317,x:31873,y:32781,varname:node_4317,prsc:2|A-7693-OUT,B-7297-OUT;n:type:ShaderForge.SFN_OneMinus,id:7693,x:31559,y:32748,varname:node_7693,prsc:2|IN-2664-V;n:type:ShaderForge.SFN_Add,id:8586,x:32046,y:32781,varname:node_8586,prsc:2|A-4317-OUT,B-9462-OUT,C-6843-RGB;n:type:ShaderForge.SFN_Tex2d,id:6843,x:31211,y:32980,ptovrint:False,ptlb:eye,ptin:_eye,varname:node_6843,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:af9c31578bd607646972f1045b090343,ntxv:0,isnm:False|UVIN-8954-OUT;n:type:ShaderForge.SFN_Slider,id:4349,x:30247,y:32852,ptovrint:False,ptlb:eyeX,ptin:_eyeX,varname:node_4349,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-0.4,cur:-0.4,max:0.4;n:type:ShaderForge.SFN_Slider,id:6210,x:30201,y:32973,ptovrint:False,ptlb:eyeY,ptin:_eyeY,varname:node_6210,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-0.4,cur:0,max:0.4;n:type:ShaderForge.SFN_Append,id:6087,x:30539,y:32852,varname:node_6087,prsc:2|A-4349-OUT,B-6210-OUT;n:type:ShaderForge.SFN_TexCoord,id:9019,x:30686,y:33095,varname:node_9019,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:8954,x:31003,y:33115,varname:node_8954,prsc:2|A-5163-OUT,B-9019-UVOUT;n:type:ShaderForge.SFN_Negate,id:5163,x:30741,y:32852,varname:node_5163,prsc:2|IN-6087-OUT;n:type:ShaderForge.SFN_Multiply,id:9206,x:32347,y:32930,varname:node_9206,prsc:2|A-8586-OUT,B-7241-RGB;proporder:7241-7297-6843-4349-6210;pass:END;sub:END;*/

Shader "Shader Forge/C4PEyeShader" {
    Properties {
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _eyeOpen ("eyeOpen", Range(0, 0.5)) = 0.3717949
        _eye ("eye", 2D) = "white" {}
        _eyeX ("eyeX", Range(-0.4, 0.4)) = -0.4
        _eyeY ("eyeY", Range(-0.4, 0.4)) = 0
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
            uniform float _eyeOpen;
            uniform sampler2D _eye; uniform float4 _eye_ST;
            uniform float _eyeX;
            uniform float _eyeY;
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
                float2 node_8954 = ((-1*float2(_eyeX,_eyeY))+i.uv0);
                float4 _eye_var = tex2D(_eye,TRANSFORM_TEX(node_8954, _eye));
                float3 emissive = ((step((1.0 - i.uv0.g),_eyeOpen)+step(i.uv0.g,_eyeOpen)+_eye_var.rgb)*_Color.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
