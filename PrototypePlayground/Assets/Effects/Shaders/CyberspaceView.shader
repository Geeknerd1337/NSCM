// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-8193-OUT;n:type:ShaderForge.SFN_Fresnel,id:3960,x:32012,y:32988,varname:node_3960,prsc:2|NRM-3391-OUT,EXP-9805-OUT;n:type:ShaderForge.SFN_NormalVector,id:3391,x:31638,y:32892,prsc:2,pt:True;n:type:ShaderForge.SFN_ValueProperty,id:9805,x:31730,y:33139,ptovrint:False,ptlb:fresnelc,ptin:_fresnelc,varname:node_9805,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;n:type:ShaderForge.SFN_Color,id:7414,x:32158,y:33135,ptovrint:False,ptlb:color,ptin:_color,varname:node_7414,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Cubemap,id:8625,x:32055,y:32571,ptovrint:False,ptlb:node_8625,ptin:_node_8625,varname:node_8625,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,cube:2706423cfc93146f5bfbe7acb4b24334,pvfc:4|DIR-7681-OUT;n:type:ShaderForge.SFN_ViewVector,id:8292,x:31623,y:32588,varname:node_8292,prsc:2;n:type:ShaderForge.SFN_Lerp,id:8193,x:32413,y:32823,varname:node_8193,prsc:2|A-8625-RGB,B-7414-RGB,T-3960-OUT;n:type:ShaderForge.SFN_Negate,id:7681,x:31837,y:32564,varname:node_7681,prsc:2|IN-8292-OUT;proporder:9805-7414-8625;pass:END;sub:END;*/

Shader "Shader Forge/CyberspaceView" {
    Properties {
        _fresnelc ("fresnelc", Float ) = 4
        _color ("color", Color) = (0.5,0.5,0.5,1)
        _node_8625 ("node_8625", Cube) = "_Skybox" {}
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
            uniform float _fresnelc;
            uniform float4 _color;
            uniform samplerCUBE _node_8625;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float3 emissive = lerp(texCUBE(_node_8625,(-1*viewDirection)).rgb,_color.rgb,pow(1.0-max(0,dot(normalDirection, viewDirection)),_fresnelc));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
