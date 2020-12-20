// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33574,y:32700,varname:node_3138,prsc:2|emission-7487-OUT;n:type:ShaderForge.SFN_Tex2d,id:3290,x:32719,y:32776,ptovrint:False,ptlb:pixel,ptin:_pixel,varname:node_3290,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:843804d7203887945a8dd01fa2ae5934,ntxv:0,isnm:False|UVIN-6912-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9159,x:31202,y:32626,ptovrint:False,ptlb:numLines,ptin:_numLines,varname:node_9159,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:384;n:type:ShaderForge.SFN_TexCoord,id:7383,x:31202,y:32689,varname:node_7383,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:330,x:31428,y:32705,varname:node_330,prsc:2|A-9159-OUT,B-7383-UVOUT;n:type:ShaderForge.SFN_Vector1,id:1484,x:31424,y:33008,varname:node_1484,prsc:2,v1:2;n:type:ShaderForge.SFN_ComponentMask,id:3420,x:31351,y:32857,varname:node_3420,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-330-OUT;n:type:ShaderForge.SFN_Fmod,id:3882,x:31655,y:32945,varname:node_3882,prsc:2|A-3420-G,B-1484-OUT;n:type:ShaderForge.SFN_Floor,id:4337,x:31827,y:32931,varname:node_4337,prsc:2|IN-3882-OUT;n:type:ShaderForge.SFN_Slider,id:9413,x:31350,y:32527,ptovrint:False,ptlb:lineOffset,ptin:_lineOffset,varname:node_9413,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.5,max:1.5;n:type:ShaderForge.SFN_Add,id:1748,x:31851,y:32752,varname:node_1748,prsc:2|A-3420-R,B-770-OUT;n:type:ShaderForge.SFN_Multiply,id:770,x:31674,y:32705,varname:node_770,prsc:2|A-9413-OUT,B-4337-OUT;n:type:ShaderForge.SFN_Append,id:6912,x:32033,y:32752,varname:node_6912,prsc:2|A-1748-OUT,B-3420-G;n:type:ShaderForge.SFN_Tex2d,id:5348,x:32987,y:32669,ptovrint:False,ptlb:tex,ptin:_tex,varname:node_5348,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6e6cedc8159709049a578f8907e36578,ntxv:0,isnm:False;n:type:ShaderForge.SFN_TexCoord,id:6134,x:31779,y:32314,varname:node_6134,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ComponentMask,id:1587,x:32207,y:32752,varname:node_1587,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-6912-OUT;n:type:ShaderForge.SFN_Fmod,id:178,x:32379,y:32958,varname:node_178,prsc:2|A-1587-R,B-740-OUT;n:type:ShaderForge.SFN_Vector1,id:740,x:32072,y:33026,varname:node_740,prsc:2,v1:3;n:type:ShaderForge.SFN_OneMinus,id:8111,x:32719,y:32958,varname:node_8111,prsc:2|IN-243-OUT;n:type:ShaderForge.SFN_Floor,id:243,x:32565,y:32958,varname:node_243,prsc:2|IN-178-OUT;n:type:ShaderForge.SFN_Add,id:402,x:32379,y:33094,varname:node_402,prsc:2|A-1587-R,B-5837-OUT;n:type:ShaderForge.SFN_Vector1,id:5837,x:32174,y:33113,varname:node_5837,prsc:2,v1:1;n:type:ShaderForge.SFN_Add,id:7225,x:32379,y:33228,varname:node_7225,prsc:2|A-402-OUT,B-5837-OUT;n:type:ShaderForge.SFN_Fmod,id:9929,x:32565,y:33094,varname:node_9929,prsc:2|A-402-OUT,B-740-OUT;n:type:ShaderForge.SFN_Fmod,id:3541,x:32565,y:33228,varname:node_3541,prsc:2|A-7225-OUT,B-740-OUT;n:type:ShaderForge.SFN_Floor,id:4355,x:32719,y:33094,varname:node_4355,prsc:2|IN-9929-OUT;n:type:ShaderForge.SFN_Floor,id:623,x:32719,y:33228,varname:node_623,prsc:2|IN-3541-OUT;n:type:ShaderForge.SFN_OneMinus,id:4605,x:32897,y:33094,varname:node_4605,prsc:2|IN-4355-OUT;n:type:ShaderForge.SFN_OneMinus,id:2027,x:32897,y:33228,varname:node_2027,prsc:2|IN-623-OUT;n:type:ShaderForge.SFN_Multiply,id:5870,x:33117,y:32969,varname:node_5870,prsc:2|A-3290-R,B-8111-OUT,C-5348-R;n:type:ShaderForge.SFN_Multiply,id:8179,x:33117,y:33094,varname:node_8179,prsc:2|A-3290-G,B-4605-OUT,C-5348-G;n:type:ShaderForge.SFN_Multiply,id:7595,x:33117,y:33228,varname:node_7595,prsc:2|A-3290-B,B-2027-OUT,C-5348-B;n:type:ShaderForge.SFN_Append,id:7487,x:33345,y:33052,varname:node_7487,prsc:2|A-5870-OUT,B-8179-OUT,C-7595-OUT;proporder:3290-9159-9413-5348;pass:END;sub:END;*/

Shader "Shader Forge/CRTAcurrate" {
    Properties {
        _pixel ("pixel", 2D) = "white" {}
        _numLines ("numLines", Float ) = 384
        _lineOffset ("lineOffset", Range(0, 1.5)) = 1.5
        _tex ("tex", 2D) = "white" {}
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
            uniform sampler2D _pixel; uniform float4 _pixel_ST;
            uniform float _numLines;
            uniform float _lineOffset;
            uniform sampler2D _tex; uniform float4 _tex_ST;
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
                float2 node_3420 = (_numLines*i.uv0).rg;
                float node_1484 = 2.0;
                float node_4337 = floor(fmod(node_3420.g,node_1484));
                float2 node_6912 = float2((node_3420.r+(_lineOffset*node_4337)),node_3420.g);
                float4 _pixel_var = tex2D(_pixel,TRANSFORM_TEX(node_6912, _pixel));
                float2 node_1587 = node_6912.rg;
                float node_740 = 3.0;
                float node_178 = fmod(node_1587.r,node_740);
                float node_8111 = (1.0 - floor(node_178));
                float4 _tex_var = tex2D(_tex,TRANSFORM_TEX(i.uv0, _tex));
                float node_5837 = 1.0;
                float node_402 = (node_1587.r+node_5837);
                float node_9929 = fmod(node_402,node_740);
                float node_4605 = (1.0 - floor(node_9929));
                float node_3541 = fmod((node_402+node_5837),node_740);
                float node_2027 = (1.0 - floor(node_3541));
                float3 node_7487 = float3((_pixel_var.r*node_8111*_tex_var.r),(_pixel_var.g*node_4605*_tex_var.g),(_pixel_var.b*node_2027*_tex_var.b));
                float3 emissive = node_7487;
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
