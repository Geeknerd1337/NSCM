// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-76-OUT,alpha-6066-OUT;n:type:ShaderForge.SFN_Tex2d,id:7237,x:31968,y:32716,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_7237,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Sin,id:3895,x:32086,y:33064,varname:node_3895,prsc:2|IN-1447-OUT;n:type:ShaderForge.SFN_Multiply,id:1447,x:31951,y:33064,varname:node_1447,prsc:2|A-679-OUT,B-1885-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1885,x:31737,y:33162,ptovrint:False,ptlb:lines,ptin:_lines,varname:node_1885,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;n:type:ShaderForge.SFN_Multiply,id:1348,x:32297,y:32753,varname:node_1348,prsc:2|A-7237-RGB,B-2813-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:5054,x:31622,y:32877,varname:node_5054,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:2813,x:32192,y:32907,varname:node_2813,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-2661-OUT;n:type:ShaderForge.SFN_Add,id:679,x:31829,y:32905,varname:node_679,prsc:2|A-5054-Y,B-8828-OUT;n:type:ShaderForge.SFN_Multiply,id:8828,x:31594,y:33033,varname:node_8828,prsc:2|A-6294-OUT,B-469-T;n:type:ShaderForge.SFN_ValueProperty,id:6294,x:31340,y:33037,ptovrint:False,ptlb:lineSpeed,ptin:_lineSpeed,varname:node_6294,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Time,id:469,x:31237,y:33117,varname:node_469,prsc:2;n:type:ShaderForge.SFN_Noise,id:2372,x:32152,y:33191,varname:node_2372,prsc:2|XY-450-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:6419,x:31737,y:33210,varname:node_6419,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:6649,x:32308,y:33161,varname:node_6649,prsc:2|A-2372-OUT,B-6526-OUT;n:type:ShaderForge.SFN_Slider,id:6526,x:32036,y:33361,ptovrint:False,ptlb:noiseAmt,ptin:_noiseAmt,varname:node_6526,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Add,id:2661,x:32231,y:33102,varname:node_2661,prsc:2|A-3895-OUT,B-6649-OUT;n:type:ShaderForge.SFN_Panner,id:450,x:31951,y:33210,varname:node_450,prsc:2,spu:1,spv:1|UVIN-6419-UVOUT,DIST-9667-OUT;n:type:ShaderForge.SFN_Time,id:2083,x:31573,y:33371,varname:node_2083,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9667,x:31807,y:33380,varname:node_9667,prsc:2|A-2083-T,B-4204-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4204,x:31558,y:33528,ptovrint:False,ptlb:noiseSpd,ptin:_noiseSpd,varname:node_4204,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:76,x:32476,y:32732,varname:node_76,prsc:2|A-4489-RGB,B-1348-OUT;n:type:ShaderForge.SFN_VertexColor,id:4489,x:32216,y:32602,varname:node_4489,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6066,x:32476,y:32913,varname:node_6066,prsc:2|A-7237-A,B-4489-A;proporder:7237-1885-6294-6526-4204;pass:END;sub:END;*/

Shader "Shader Forge/Text" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _lines ("lines", Float ) = 4
        _lineSpeed ("lineSpeed", Float ) = 0
        _noiseAmt ("noiseAmt", Range(0, 1)) = 0
        _noiseSpd ("noiseSpd", Float ) = 0
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
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _lines;
            uniform float _lineSpeed;
            uniform float _noiseAmt;
            uniform float _noiseSpd;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 node_469 = _Time;
                float4 node_2083 = _Time;
                float2 node_450 = (i.uv0+(node_2083.g*_noiseSpd)*float2(1,1));
                float2 node_2372_skew = node_450 + 0.2127+node_450.x*0.3713*node_450.y;
                float2 node_2372_rnd = 4.789*sin(489.123*(node_2372_skew));
                float node_2372 = frac(node_2372_rnd.x*node_2372_rnd.y*(1+node_2372_skew.x));
                float3 emissive = (i.vertexColor.rgb*(_MainTex_var.rgb*((sin(((i.posWorld.g+(_lineSpeed*node_469.g))*_lines))+(node_2372*_noiseAmt))*0.5+0.5)));
                float3 finalColor = emissive;
                return fixed4(finalColor,(_MainTex_var.a*i.vertexColor.a));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
