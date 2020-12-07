// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:0,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32793,y:32729,varname:node_4013,prsc:2|diff-7849-OUT,emission-2656-OUT,alpha-6110-OUT,voffset-3735-OUT;n:type:ShaderForge.SFN_Tex2d,id:9863,x:31257,y:32484,ptovrint:False,ptlb:noise,ptin:_noise,varname:node_9863,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-8246-OUT;n:type:ShaderForge.SFN_Multiply,id:8246,x:31115,y:32628,varname:node_8246,prsc:2|A-5182-OUT,B-7293-OUT;n:type:ShaderForge.SFN_Vector2,id:7293,x:30824,y:32768,varname:node_7293,prsc:2,v1:0.002,v2:0.002;n:type:ShaderForge.SFN_Add,id:5182,x:31012,y:32484,varname:node_5182,prsc:2|A-4321-OUT,B-9236-OUT;n:type:ShaderForge.SFN_Vector2,id:6126,x:30709,y:32611,varname:node_6126,prsc:2,v1:0,v2:5;n:type:ShaderForge.SFN_FragmentPosition,id:8861,x:30575,y:32524,varname:node_8861,prsc:2;n:type:ShaderForge.SFN_ComponentMask,id:4321,x:30736,y:32424,varname:node_4321,prsc:2,cc1:0,cc2:2,cc3:-1,cc4:-1|IN-8861-XYZ;n:type:ShaderForge.SFN_Time,id:3379,x:30665,y:32736,varname:node_3379,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9236,x:30884,y:32611,varname:node_9236,prsc:2|A-6126-OUT,B-3379-T;n:type:ShaderForge.SFN_NormalVector,id:3176,x:30683,y:33418,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:1517,x:31195,y:33297,varname:node_1517,prsc:2|A-5302-OUT,B-3176-OUT;n:type:ShaderForge.SFN_Multiply,id:3626,x:31853,y:33412,varname:node_3626,prsc:2|A-1517-OUT,B-2012-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2012,x:31154,y:33492,ptovrint:False,ptlb:displacement,ptin:_displacement,varname:node_2012,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Tex2d,id:4067,x:31946,y:32311,ptovrint:False,ptlb:secondNoise,ptin:_secondNoise,varname:node_4067,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-1577-OUT;n:type:ShaderForge.SFN_Multiply,id:1577,x:31669,y:32235,varname:node_1577,prsc:2|A-6910-OUT,B-6275-OUT;n:type:ShaderForge.SFN_Vector2,id:6275,x:31487,y:32351,varname:node_6275,prsc:2,v1:0.002,v2:0.002;n:type:ShaderForge.SFN_Add,id:6910,x:31566,y:32091,varname:node_6910,prsc:2|A-6826-OUT,B-8822-OUT;n:type:ShaderForge.SFN_Vector2,id:3491,x:31263,y:32218,varname:node_3491,prsc:2,v1:5,v2:0;n:type:ShaderForge.SFN_FragmentPosition,id:7996,x:31129,y:32131,varname:node_7996,prsc:2;n:type:ShaderForge.SFN_ComponentMask,id:6826,x:31290,y:32031,varname:node_6826,prsc:2,cc1:0,cc2:2,cc3:-1,cc4:-1|IN-7996-XYZ;n:type:ShaderForge.SFN_Time,id:1717,x:31129,y:32295,varname:node_1717,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8822,x:31438,y:32218,varname:node_8822,prsc:2|A-3491-OUT,B-1717-T;n:type:ShaderForge.SFN_Add,id:4681,x:32182,y:32452,varname:node_4681,prsc:2|A-4067-RGB,B-9863-RGB;n:type:ShaderForge.SFN_Divide,id:4819,x:32442,y:32287,varname:node_4819,prsc:2|A-4681-OUT,B-4586-OUT;n:type:ShaderForge.SFN_Vector1,id:4586,x:32231,y:32573,varname:node_4586,prsc:2,v1:2;n:type:ShaderForge.SFN_RemapRange,id:9013,x:31097,y:32881,varname:node_9013,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-4819-OUT;n:type:ShaderForge.SFN_Abs,id:7833,x:31217,y:33119,varname:node_7833,prsc:2|IN-9013-OUT;n:type:ShaderForge.SFN_Lerp,id:6304,x:32151,y:32702,varname:node_6304,prsc:2|A-5368-RGB,B-9398-RGB,T-5302-OUT;n:type:ShaderForge.SFN_Color,id:5368,x:31796,y:32698,ptovrint:False,ptlb:Color1,ptin:_Color1,varname:node_5368,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:9398,x:31946,y:32567,ptovrint:False,ptlb:Color2,ptin:_Color2,varname:node_9398,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Smoothstep,id:5302,x:31741,y:33178,varname:node_5302,prsc:2|A-6655-OUT,B-2871-OUT,V-7833-OUT;n:type:ShaderForge.SFN_Vector1,id:6655,x:31688,y:32994,varname:node_6655,prsc:2,v1:-0.1;n:type:ShaderForge.SFN_Vector1,id:2871,x:31680,y:33075,varname:node_2871,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:2656,x:32511,y:32906,varname:node_2656,prsc:2|A-7849-OUT,B-5975-OUT,C-8395-R;n:type:ShaderForge.SFN_ValueProperty,id:5975,x:32232,y:33001,ptovrint:False,ptlb:emiss,ptin:_emiss,varname:node_5975,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_NormalVector,id:9128,x:30822,y:33701,prsc:2,pt:False;n:type:ShaderForge.SFN_FragmentPosition,id:722,x:30822,y:33880,varname:node_722,prsc:2;n:type:ShaderForge.SFN_ObjectPosition,id:7555,x:30822,y:34015,varname:node_7555,prsc:2;n:type:ShaderForge.SFN_Distance,id:6279,x:31517,y:33698,varname:node_6279,prsc:2|A-722-XYZ,B-7555-XYZ;n:type:ShaderForge.SFN_Multiply,id:5429,x:31888,y:33544,varname:node_5429,prsc:2|A-9128-OUT,B-2661-OUT;n:type:ShaderForge.SFN_Add,id:3735,x:32110,y:33443,varname:node_3735,prsc:2|A-3626-OUT,B-5429-OUT;n:type:ShaderForge.SFN_Power,id:2661,x:31888,y:33768,varname:node_2661,prsc:2|VAL-6209-OUT,EXP-1446-OUT;n:type:ShaderForge.SFN_Vector1,id:1446,x:31528,y:33854,varname:node_1446,prsc:2,v1:3;n:type:ShaderForge.SFN_Divide,id:6209,x:31687,y:33698,varname:node_6209,prsc:2|A-6279-OUT,B-3189-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3189,x:31545,y:33941,ptovrint:False,ptlb:Curv Radius,ptin:_CurvRadius,varname:node_3189,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1000;n:type:ShaderForge.SFN_Multiply,id:9453,x:32121,y:33128,varname:node_9453,prsc:2|A-5302-OUT,B-6921-OUT;n:type:ShaderForge.SFN_Fresnel,id:6921,x:32077,y:33258,varname:node_6921,prsc:2|EXP-4466-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4466,x:31888,y:33323,ptovrint:False,ptlb:Fresnel,ptin:_Fresnel,varname:node_4466,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:7869,x:32325,y:33148,varname:node_7869,prsc:2|A-9453-OUT,B-7443-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7443,x:32223,y:33258,ptovrint:False,ptlb:Fresnel Alpha,ptin:_FresnelAlpha,varname:node_7443,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Add,id:7849,x:32435,y:32763,varname:node_7849,prsc:2|A-6304-OUT,B-7869-OUT;n:type:ShaderForge.SFN_DepthBlend,id:6110,x:32566,y:33228,varname:node_6110,prsc:2|DIST-2856-OUT;n:type:ShaderForge.SFN_Slider,id:2856,x:32223,y:33546,ptovrint:False,ptlb:Density,ptin:_Density,varname:node_2856,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:46.15385,max:100;n:type:ShaderForge.SFN_Vector1,id:9928,x:32907,y:34046,varname:node_9928,prsc:2,v1:1;n:type:ShaderForge.SFN_FragmentPosition,id:78,x:31348,y:32815,varname:node_78,prsc:2;n:type:ShaderForge.SFN_ComponentMask,id:5115,x:31509,y:32715,varname:node_5115,prsc:2,cc1:0,cc2:2,cc3:-1,cc4:-1|IN-78-XYZ;n:type:ShaderForge.SFN_Tex2d,id:8395,x:31807,y:32888,ptovrint:False,ptlb:cicruit,ptin:_cicruit,varname:node_8395,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:33967458e505c1a48929fcc98025b078,ntxv:0,isnm:False|UVIN-5115-OUT;proporder:9863-2012-4067-5368-9398-5975-3189-4466-7443-2856-8395;pass:END;sub:END;*/

Shader "Shader Forge/Test" {
    Properties {
        _noise ("noise", 2D) = "white" {}
        _displacement ("displacement", Float ) = 0
        _secondNoise ("secondNoise", 2D) = "white" {}
        _Color1 ("Color1", Color) = (0.5,0.5,0.5,1)
        _Color2 ("Color2", Color) = (0.5,0.5,0.5,1)
        _emiss ("emiss", Float ) = 0
        _CurvRadius ("Curv Radius", Float ) = 1000
        _Fresnel ("Fresnel", Float ) = 1
        _FresnelAlpha ("Fresnel Alpha", Float ) = 1
        _Density ("Density", Range(0, 100)) = 46.15385
        _cicruit ("cicruit", 2D) = "white" {}
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
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _CameraDepthTexture;
            uniform sampler2D _noise; uniform float4 _noise_ST;
            uniform float _displacement;
            uniform sampler2D _secondNoise; uniform float4 _secondNoise_ST;
            uniform float4 _Color1;
            uniform float4 _Color2;
            uniform float _emiss;
            uniform float _CurvRadius;
            uniform float _Fresnel;
            uniform float _FresnelAlpha;
            uniform float _Density;
            uniform sampler2D _cicruit; uniform float4 _cicruit_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 projPos : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float node_6655 = (-0.1);
                float node_2871 = 1.0;
                float4 node_1717 = _Time;
                float2 node_1577 = ((mul(unity_ObjectToWorld, v.vertex).rgb.rb+(float2(5,0)*node_1717.g))*float2(0.002,0.002));
                float4 _secondNoise_var = tex2Dlod(_secondNoise,float4(TRANSFORM_TEX(node_1577, _secondNoise),0.0,0));
                float4 node_3379 = _Time;
                float2 node_8246 = ((mul(unity_ObjectToWorld, v.vertex).rgb.rb+(float2(0,5)*node_3379.g))*float2(0.002,0.002));
                float4 _noise_var = tex2Dlod(_noise,float4(TRANSFORM_TEX(node_8246, _noise),0.0,0));
                float3 node_5302 = smoothstep( float3(node_6655,node_6655,node_6655), float3(node_2871,node_2871,node_2871), abs((((_secondNoise_var.rgb+_noise_var.rgb)/2.0)*2.0+-1.0)) );
                v.vertex.xyz += (((node_5302*v.normal)*_displacement)+(v.normal*pow((distance(mul(unity_ObjectToWorld, v.vertex).rgb,objPos.rgb)/_CurvRadius),3.0)));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float node_6655 = (-0.1);
                float node_2871 = 1.0;
                float4 node_1717 = _Time;
                float2 node_1577 = ((i.posWorld.rgb.rb+(float2(5,0)*node_1717.g))*float2(0.002,0.002));
                float4 _secondNoise_var = tex2D(_secondNoise,TRANSFORM_TEX(node_1577, _secondNoise));
                float4 node_3379 = _Time;
                float2 node_8246 = ((i.posWorld.rgb.rb+(float2(0,5)*node_3379.g))*float2(0.002,0.002));
                float4 _noise_var = tex2D(_noise,TRANSFORM_TEX(node_8246, _noise));
                float3 node_5302 = smoothstep( float3(node_6655,node_6655,node_6655), float3(node_2871,node_2871,node_2871), abs((((_secondNoise_var.rgb+_noise_var.rgb)/2.0)*2.0+-1.0)) );
                float3 node_7849 = (lerp(_Color1.rgb,_Color2.rgb,node_5302)+((node_5302*pow(1.0-max(0,dot(normalDirection, viewDirection)),_Fresnel))*_FresnelAlpha));
                float3 diffuseColor = node_7849;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float2 node_5115 = i.posWorld.rgb.rb;
                float4 _cicruit_var = tex2D(_cicruit,TRANSFORM_TEX(node_5115, _cicruit));
                float3 emissive = (node_7849*_emiss*_cicruit_var.r);
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,saturate((sceneZ-partZ)/_Density));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _CameraDepthTexture;
            uniform sampler2D _noise; uniform float4 _noise_ST;
            uniform float _displacement;
            uniform sampler2D _secondNoise; uniform float4 _secondNoise_ST;
            uniform float4 _Color1;
            uniform float4 _Color2;
            uniform float _emiss;
            uniform float _CurvRadius;
            uniform float _Fresnel;
            uniform float _FresnelAlpha;
            uniform float _Density;
            uniform sampler2D _cicruit; uniform float4 _cicruit_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 projPos : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float node_6655 = (-0.1);
                float node_2871 = 1.0;
                float4 node_1717 = _Time;
                float2 node_1577 = ((mul(unity_ObjectToWorld, v.vertex).rgb.rb+(float2(5,0)*node_1717.g))*float2(0.002,0.002));
                float4 _secondNoise_var = tex2Dlod(_secondNoise,float4(TRANSFORM_TEX(node_1577, _secondNoise),0.0,0));
                float4 node_3379 = _Time;
                float2 node_8246 = ((mul(unity_ObjectToWorld, v.vertex).rgb.rb+(float2(0,5)*node_3379.g))*float2(0.002,0.002));
                float4 _noise_var = tex2Dlod(_noise,float4(TRANSFORM_TEX(node_8246, _noise),0.0,0));
                float3 node_5302 = smoothstep( float3(node_6655,node_6655,node_6655), float3(node_2871,node_2871,node_2871), abs((((_secondNoise_var.rgb+_noise_var.rgb)/2.0)*2.0+-1.0)) );
                v.vertex.xyz += (((node_5302*v.normal)*_displacement)+(v.normal*pow((distance(mul(unity_ObjectToWorld, v.vertex).rgb,objPos.rgb)/_CurvRadius),3.0)));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float node_6655 = (-0.1);
                float node_2871 = 1.0;
                float4 node_1717 = _Time;
                float2 node_1577 = ((i.posWorld.rgb.rb+(float2(5,0)*node_1717.g))*float2(0.002,0.002));
                float4 _secondNoise_var = tex2D(_secondNoise,TRANSFORM_TEX(node_1577, _secondNoise));
                float4 node_3379 = _Time;
                float2 node_8246 = ((i.posWorld.rgb.rb+(float2(0,5)*node_3379.g))*float2(0.002,0.002));
                float4 _noise_var = tex2D(_noise,TRANSFORM_TEX(node_8246, _noise));
                float3 node_5302 = smoothstep( float3(node_6655,node_6655,node_6655), float3(node_2871,node_2871,node_2871), abs((((_secondNoise_var.rgb+_noise_var.rgb)/2.0)*2.0+-1.0)) );
                float3 node_7849 = (lerp(_Color1.rgb,_Color2.rgb,node_5302)+((node_5302*pow(1.0-max(0,dot(normalDirection, viewDirection)),_Fresnel))*_FresnelAlpha));
                float3 diffuseColor = node_7849;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * saturate((sceneZ-partZ)/_Density),0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
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
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _noise; uniform float4 _noise_ST;
            uniform float _displacement;
            uniform sampler2D _secondNoise; uniform float4 _secondNoise_ST;
            uniform float _CurvRadius;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float node_6655 = (-0.1);
                float node_2871 = 1.0;
                float4 node_1717 = _Time;
                float2 node_1577 = ((mul(unity_ObjectToWorld, v.vertex).rgb.rb+(float2(5,0)*node_1717.g))*float2(0.002,0.002));
                float4 _secondNoise_var = tex2Dlod(_secondNoise,float4(TRANSFORM_TEX(node_1577, _secondNoise),0.0,0));
                float4 node_3379 = _Time;
                float2 node_8246 = ((mul(unity_ObjectToWorld, v.vertex).rgb.rb+(float2(0,5)*node_3379.g))*float2(0.002,0.002));
                float4 _noise_var = tex2Dlod(_noise,float4(TRANSFORM_TEX(node_8246, _noise),0.0,0));
                float3 node_5302 = smoothstep( float3(node_6655,node_6655,node_6655), float3(node_2871,node_2871,node_2871), abs((((_secondNoise_var.rgb+_noise_var.rgb)/2.0)*2.0+-1.0)) );
                v.vertex.xyz += (((node_5302*v.normal)*_displacement)+(v.normal*pow((distance(mul(unity_ObjectToWorld, v.vertex).rgb,objPos.rgb)/_CurvRadius),3.0)));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
