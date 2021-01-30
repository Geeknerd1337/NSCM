// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-5229-OUT;n:type:ShaderForge.SFN_Tex2d,id:394,x:31881,y:32837,ptovrint:False,ptlb:cam,ptin:_cam,varname:node_394,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b84def00a4bd46f44b696989e4a1cc42,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:7289,x:32202,y:32866,varname:node_7289,prsc:2|A-394-RGB,B-4533-OUT,C-303-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4533,x:31881,y:33025,ptovrint:False,ptlb:intensity,ptin:_intensity,varname:node_4533,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:6;n:type:ShaderForge.SFN_TexCoord,id:5747,x:31439,y:33113,varname:node_5747,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:6700,x:31639,y:33182,varname:node_6700,prsc:2|A-5747-V,B-4887-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4887,x:31456,y:33289,ptovrint:False,ptlb:scanLines,ptin:_scanLines,varname:node_4887,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:250;n:type:ShaderForge.SFN_Sin,id:9814,x:31803,y:33198,varname:node_9814,prsc:2|IN-6700-OUT;n:type:ShaderForge.SFN_RemapRange,id:8950,x:31968,y:33198,varname:node_8950,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-9814-OUT;n:type:ShaderForge.SFN_Add,id:2430,x:32107,y:33115,varname:node_2430,prsc:2|A-8950-OUT,B-9911-OUT;n:type:ShaderForge.SFN_Slider,id:9911,x:31821,y:33389,ptovrint:False,ptlb:scanLineInfluence,ptin:_scanLineInfluence,varname:node_9911,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Clamp01,id:3514,x:32310,y:33174,varname:node_3514,prsc:2|IN-2430-OUT;n:type:ShaderForge.SFN_Multiply,id:4788,x:32415,y:33011,varname:node_4788,prsc:2|A-7289-OUT,B-3514-OUT;n:type:ShaderForge.SFN_Tex2d,id:793,x:32213,y:32487,varname:node_793,prsc:2,tex:1a7b150f384b67642bc17d2ac54e0fa3,ntxv:0,isnm:False|UVIN-7938-UVOUT,TEX-8969-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:8969,x:31670,y:32504,ptovrint:False,ptlb:static,ptin:_static,varname:node_8969,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1a7b150f384b67642bc17d2ac54e0fa3,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6650,x:32146,y:32611,varname:node_6650,prsc:2,tex:1a7b150f384b67642bc17d2ac54e0fa3,ntxv:0,isnm:False|UVIN-9220-UVOUT,TEX-8969-TEX;n:type:ShaderForge.SFN_Panner,id:7938,x:31925,y:32318,varname:node_7938,prsc:2,spu:1,spv:1|UVIN-3905-UVOUT,DIST-4290-OUT;n:type:ShaderForge.SFN_Panner,id:9220,x:31954,y:32636,varname:node_9220,prsc:2,spu:-1,spv:-1|UVIN-3905-UVOUT,DIST-4290-OUT;n:type:ShaderForge.SFN_TexCoord,id:3905,x:31456,y:32409,varname:node_3905,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ValueProperty,id:6540,x:31336,y:32614,ptovrint:False,ptlb:staticSpeed,ptin:_staticSpeed,varname:node_6540,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Time,id:8533,x:31325,y:32678,varname:node_8533,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4290,x:31516,y:32672,varname:node_4290,prsc:2|A-6540-OUT,B-8533-T;n:type:ShaderForge.SFN_Add,id:990,x:32433,y:32532,varname:node_990,prsc:2|A-793-R,B-6650-R,C-3141-OUT;n:type:ShaderForge.SFN_Clamp01,id:303,x:32676,y:32477,varname:node_303,prsc:2|IN-990-OUT;n:type:ShaderForge.SFN_Slider,id:3141,x:32295,y:32809,ptovrint:False,ptlb:noiseInfluence,ptin:_noiseInfluence,varname:node_3141,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2455001,max:1;n:type:ShaderForge.SFN_TexCoord,id:350,x:30734,y:32878,varname:node_350,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Vector1,id:6539,x:30590,y:33059,varname:node_6539,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Slider,id:6441,x:30402,y:33163,ptovrint:False,ptlb:crossHairSize,ptin:_crossHairSize,varname:node_6441,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.02958192,max:0.2;n:type:ShaderForge.SFN_Add,id:6622,x:30775,y:33218,varname:node_6622,prsc:2|A-6539-OUT,B-6441-OUT;n:type:ShaderForge.SFN_Subtract,id:997,x:30788,y:33059,varname:node_997,prsc:2|A-6539-OUT,B-6441-OUT;n:type:ShaderForge.SFN_Multiply,id:9158,x:31157,y:32888,varname:node_9158,prsc:2|A-8577-OUT,B-2963-OUT;n:type:ShaderForge.SFN_Step,id:8577,x:30971,y:32888,varname:node_8577,prsc:2|A-997-OUT,B-350-U;n:type:ShaderForge.SFN_Step,id:2963,x:30971,y:33044,varname:node_2963,prsc:2|A-350-U,B-6622-OUT;n:type:ShaderForge.SFN_Step,id:1964,x:30971,y:33162,varname:node_1964,prsc:2|A-997-OUT,B-350-V;n:type:ShaderForge.SFN_Step,id:9052,x:30981,y:33313,varname:node_9052,prsc:2|A-350-V,B-6622-OUT;n:type:ShaderForge.SFN_Multiply,id:1860,x:31179,y:33159,varname:node_1860,prsc:2|A-1964-OUT,B-9052-OUT;n:type:ShaderForge.SFN_Clamp01,id:5603,x:31483,y:32888,varname:node_5603,prsc:2|IN-9855-OUT;n:type:ShaderForge.SFN_Multiply,id:9855,x:31325,y:32888,varname:node_9855,prsc:2|A-9158-OUT,B-1860-OUT;n:type:ShaderForge.SFN_Set,id:7158,x:31687,y:32888,varname:crossHair,prsc:2|IN-3811-OUT;n:type:ShaderForge.SFN_Multiply,id:3811,x:31708,y:32960,varname:node_3811,prsc:2|A-5603-OUT,B-4811-OUT;n:type:ShaderForge.SFN_Slider,id:4811,x:31344,y:33029,ptovrint:False,ptlb:crossHairInfluence,ptin:_crossHairInfluence,varname:node_4811,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Get,id:7743,x:32452,y:33254,varname:node_7743,prsc:2|IN-7158-OUT;n:type:ShaderForge.SFN_Add,id:5229,x:32574,y:33045,varname:node_5229,prsc:2|A-4788-OUT,B-7743-OUT;proporder:394-4533-4887-9911-8969-6540-3141-6441-4811;pass:END;sub:END;*/

Shader "Shader Forge/Scope" {
    Properties {
        _cam ("cam", 2D) = "white" {}
        _intensity ("intensity", Float ) = 6
        _scanLines ("scanLines", Float ) = 250
        _scanLineInfluence ("scanLineInfluence", Range(0, 1)) = 0
        _static ("static", 2D) = "white" {}
        _staticSpeed ("staticSpeed", Float ) = 1
        _noiseInfluence ("noiseInfluence", Range(0, 1)) = 0.2455001
        _crossHairSize ("crossHairSize", Range(0, 0.2)) = 0.02958192
        _crossHairInfluence ("crossHairInfluence", Range(0, 1)) = 1
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
            uniform sampler2D _cam; uniform float4 _cam_ST;
            uniform float _intensity;
            uniform float _scanLines;
            uniform float _scanLineInfluence;
            uniform sampler2D _static; uniform float4 _static_ST;
            uniform float _staticSpeed;
            uniform float _noiseInfluence;
            uniform float _crossHairSize;
            uniform float _crossHairInfluence;
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
                float4 _cam_var = tex2D(_cam,TRANSFORM_TEX(i.uv0, _cam));
                float4 node_8533 = _Time;
                float node_4290 = (_staticSpeed*node_8533.g);
                float2 node_7938 = (i.uv0+node_4290*float2(1,1));
                float4 node_793 = tex2D(_static,TRANSFORM_TEX(node_7938, _static));
                float2 node_9220 = (i.uv0+node_4290*float2(-1,-1));
                float4 node_6650 = tex2D(_static,TRANSFORM_TEX(node_9220, _static));
                float node_6539 = 0.5;
                float node_997 = (node_6539-_crossHairSize);
                float node_6622 = (node_6539+_crossHairSize);
                float node_9158 = (step(node_997,i.uv0.r)*step(i.uv0.r,node_6622));
                float node_1860 = (step(node_997,i.uv0.g)*step(i.uv0.g,node_6622));
                float crossHair = (saturate((node_9158*node_1860))*_crossHairInfluence);
                float3 emissive = (((_cam_var.rgb*_intensity*saturate((node_793.r+node_6650.r+_noiseInfluence)))*saturate(((sin((i.uv0.g*_scanLines))*0.5+0.5)+_scanLineInfluence)))+crossHair);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
