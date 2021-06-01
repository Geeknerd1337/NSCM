// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-3675-OUT,alpha-6737-OUT;n:type:ShaderForge.SFN_TexCoord,id:6591,x:31232,y:32550,varname:node_6591,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Sin,id:8083,x:31684,y:32611,varname:node_8083,prsc:2|IN-318-OUT;n:type:ShaderForge.SFN_Multiply,id:318,x:31489,y:32595,varname:node_318,prsc:2|A-6591-U,B-7172-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7172,x:31314,y:32794,ptovrint:False,ptlb:lines,ptin:_lines,varname:node_7172,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_RemapRange,id:57,x:31870,y:32611,varname:node_57,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-8083-OUT;n:type:ShaderForge.SFN_Power,id:2629,x:32107,y:32574,varname:node_2629,prsc:2|VAL-57-OUT,EXP-178-OUT;n:type:ShaderForge.SFN_ValueProperty,id:178,x:31840,y:32838,ptovrint:False,ptlb:laserPower,ptin:_laserPower,varname:node_178,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Slider,id:3346,x:31621,y:32944,ptovrint:False,ptlb:basePower,ptin:_basePower,varname:node_3346,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Add,id:1576,x:32259,y:32748,varname:node_1576,prsc:2|A-2629-OUT,B-3346-OUT;n:type:ShaderForge.SFN_Tex2d,id:1213,x:31265,y:32976,varname:node_1213,prsc:2,tex:87412b021f67f5e439dbc652dd3c2025,ntxv:0,isnm:False|UVIN-2360-UVOUT,TEX-1053-TEX;n:type:ShaderForge.SFN_Multiply,id:1621,x:31830,y:33090,varname:node_1621,prsc:2|A-5300-OUT,B-4799-OUT;n:type:ShaderForge.SFN_Slider,id:4799,x:31572,y:33368,ptovrint:False,ptlb:smokeStrength,ptin:_smokeStrength,varname:node_4799,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Add,id:3212,x:32134,y:33019,varname:node_3212,prsc:2|A-1621-OUT,B-156-OUT;n:type:ShaderForge.SFN_Vector1,id:156,x:31936,y:33164,varname:node_156,prsc:2,v1:0.25;n:type:ShaderForge.SFN_Tex2dAsset,id:1053,x:30856,y:33021,ptovrint:False,ptlb:noise,ptin:_noise,varname:node_1053,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:87412b021f67f5e439dbc652dd3c2025,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Panner,id:2360,x:31065,y:32837,varname:node_2360,prsc:2,spu:1,spv:1|UVIN-665-UVOUT,DIST-5327-OUT;n:type:ShaderForge.SFN_TexCoord,id:665,x:30679,y:32705,varname:node_665,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ValueProperty,id:2496,x:30227,y:32849,ptovrint:False,ptlb:smokeSpeed,ptin:_smokeSpeed,varname:node_2496,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:5327,x:30470,y:32860,varname:node_5327,prsc:2|A-2496-OUT,B-4265-T;n:type:ShaderForge.SFN_Time,id:4265,x:30190,y:32991,varname:node_4265,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:8704,x:31265,y:33113,varname:node_8704,prsc:2,tex:87412b021f67f5e439dbc652dd3c2025,ntxv:0,isnm:False|UVIN-3180-UVOUT,TEX-1053-TEX;n:type:ShaderForge.SFN_Panner,id:3180,x:30876,y:33271,varname:node_3180,prsc:2,spu:-1,spv:-1|UVIN-665-UVOUT,DIST-5327-OUT;n:type:ShaderForge.SFN_Add,id:7064,x:31460,y:33079,varname:node_7064,prsc:2|A-1213-RGB,B-8704-RGB;n:type:ShaderForge.SFN_Clamp01,id:5300,x:31621,y:33043,varname:node_5300,prsc:2|IN-7064-OUT;n:type:ShaderForge.SFN_ComponentMask,id:5689,x:32320,y:33019,varname:node_5689,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-3212-OUT;n:type:ShaderForge.SFN_Multiply,id:6737,x:32415,y:32852,varname:node_6737,prsc:2|A-1576-OUT,B-5689-OUT,C-1234-OUT,D-3342-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1234,x:32206,y:32914,ptovrint:False,ptlb:laserIntens,ptin:_laserIntens,varname:node_1234,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_TexCoord,id:1764,x:32291,y:32452,varname:node_1764,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:9871,x:32558,y:32464,varname:node_9871,prsc:2|A-1764-V,B-3130-OUT,C-1883-OUT;n:type:ShaderForge.SFN_Vector1,id:3130,x:32291,y:32608,varname:node_3130,prsc:2,v1:2;n:type:ShaderForge.SFN_Pi,id:1883,x:32415,y:32653,varname:node_1883,prsc:2;n:type:ShaderForge.SFN_Sin,id:9115,x:32758,y:32437,varname:node_9115,prsc:2|IN-9871-OUT;n:type:ShaderForge.SFN_Clamp01,id:3342,x:32512,y:32673,varname:node_3342,prsc:2|IN-9115-OUT;n:type:ShaderForge.SFN_Color,id:4933,x:32458,y:33030,ptovrint:False,ptlb:lasColm,ptin:_lasColm,varname:node_4933,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:3675,x:32522,y:32956,varname:node_3675,prsc:2|A-6737-OUT,B-4933-RGB;proporder:7172-178-3346-4799-1053-2496-1234-4933;pass:END;sub:END;*/

Shader "Shader Forge/LaserTripWire" {
    Properties {
        _lines ("lines", Float ) = 1
        _laserPower ("laserPower", Float ) = 1
        _basePower ("basePower", Range(0, 1)) = 0
        _smokeStrength ("smokeStrength", Range(0, 1)) = 1
        _noise ("noise", 2D) = "white" {}
        _smokeSpeed ("smokeSpeed", Float ) = 0
        _laserIntens ("laserIntens", Float ) = 1
        _lasColm ("lasColm", Color) = (0.5,0.5,0.5,1)
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
            uniform float _lines;
            uniform float _laserPower;
            uniform float _basePower;
            uniform float _smokeStrength;
            uniform sampler2D _noise; uniform float4 _noise_ST;
            uniform float _smokeSpeed;
            uniform float _laserIntens;
            uniform float4 _lasColm;
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
                float node_1576 = (pow((sin((i.uv0.r*_lines))*0.5+0.5),_laserPower)+_basePower);
                float4 node_4265 = _Time;
                float node_5327 = (_smokeSpeed*node_4265.g);
                float2 node_2360 = (i.uv0+node_5327*float2(1,1));
                float4 node_1213 = tex2D(_noise,TRANSFORM_TEX(node_2360, _noise));
                float2 node_3180 = (i.uv0+node_5327*float2(-1,-1));
                float4 node_8704 = tex2D(_noise,TRANSFORM_TEX(node_3180, _noise));
                float3 node_7064 = (node_1213.rgb+node_8704.rgb);
                float3 node_1621 = (saturate(node_7064)*_smokeStrength);
                float3 node_3212 = (node_1621+0.25);
                float node_5689 = node_3212.r;
                float node_6737 = (node_1576*node_5689*_laserIntens*saturate(sin((i.uv0.g*2.0*3.141592654))));
                float3 emissive = (node_6737*_lasColm.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,node_6737);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
