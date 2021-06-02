// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:6,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:False,igpj:False,qofs:1,qpre:4,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|emission-4873-OUT;n:type:ShaderForge.SFN_Tex2d,id:5442,x:31977,y:32661,ptovrint:False,ptlb:circuit,ptin:_circuit,varname:node_5442,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:cb1aa710bffb5294aa31a907ca6f490e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:6276,x:32354,y:32856,varname:node_6276,prsc:2|A-5442-R,B-2230-OUT;n:type:ShaderForge.SFN_Sin,id:7314,x:31977,y:32828,varname:node_7314,prsc:2|IN-159-OUT;n:type:ShaderForge.SFN_TexCoord,id:1632,x:31523,y:32837,varname:node_1632,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:6795,x:31832,y:32949,varname:node_6795,prsc:2|A-1632-V,B-2147-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2147,x:31628,y:33065,ptovrint:False,ptlb:amp,ptin:_amp,varname:node_2147,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:40;n:type:ShaderForge.SFN_Add,id:2230,x:32331,y:33026,varname:node_2230,prsc:2|A-7582-OUT,B-1666-OUT;n:type:ShaderForge.SFN_Slider,id:1666,x:31862,y:33108,ptovrint:False,ptlb:node_1666,ptin:_node_1666,varname:node_1666,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1196581,max:1;n:type:ShaderForge.SFN_RemapRange,id:7582,x:32144,y:32810,varname:node_7582,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-7314-OUT;n:type:ShaderForge.SFN_Add,id:159,x:31801,y:32828,varname:node_159,prsc:2|A-5224-OUT,B-6795-OUT;n:type:ShaderForge.SFN_Time,id:6047,x:31563,y:32633,varname:node_6047,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:9476,x:31334,y:32751,ptovrint:False,ptlb:scrollSpeed,ptin:_scrollSpeed,varname:node_9476,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:5224,x:31711,y:32723,varname:node_5224,prsc:2|A-6047-TSL,B-9476-OUT;n:type:ShaderForge.SFN_Color,id:8552,x:32419,y:32535,ptovrint:False,ptlb:technoColor,ptin:_technoColor,varname:node_8552,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:4873,x:32560,y:32728,varname:node_4873,prsc:2|A-8552-RGB,B-6276-OUT;proporder:5442-2147-1666-9476-8552;pass:END;sub:END;*/

Shader "Shader Forge/CircuitZTest" {
    Properties {
        _circuit ("circuit", 2D) = "white" {}
        _amp ("amp", Float ) = 40
        _node_1666 ("node_1666", Range(0, 1)) = 0.1196581
        _scrollSpeed ("scrollSpeed", Float ) = 1
        _technoColor ("technoColor", Color) = (0.5,0.5,0.5,1)
    }
    SubShader {
        Tags {
            "Queue"="Overlay+1"
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            ZTest Always
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _circuit; uniform float4 _circuit_ST;
            uniform float _amp;
            uniform float _node_1666;
            uniform float _scrollSpeed;
            uniform float4 _technoColor;
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
                float4 _circuit_var = tex2D(_circuit,TRANSFORM_TEX(i.uv0, _circuit));
                float4 node_6047 = _Time;
                float3 emissive = (_technoColor.rgb*(_circuit_var.r*((sin(((node_6047.r*_scrollSpeed)+(i.uv0.g*_amp)))*0.5+0.5)+_node_1666)));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
