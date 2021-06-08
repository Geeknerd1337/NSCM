// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|diff-1304-RGB,emission-995-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:32443,y:32712,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_TexCoord,id:2868,x:31301,y:33126,varname:node_2868,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Code,id:995,x:31740,y:33006,varname:node_995,prsc:2,code:ZgByAGEAZwBDAG8AbwByAGQALgB4ACAAIAA9ACAAZgBsAG8AbwByACgAZgByAGEAZwBDAG8AbwByAGQALgB4AC8ARAApADsAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAvAC8AIABUAGgAaQBzACAAaQBzACAAdABoAGUAIABlAHgAYQBjAHQAIAByAGUAcABsAGkAYwBhACAAbwBmACAAdABoAGUAIABjAGEAbABjAHUAbABhAHQAaQBvAG4AIABpAG4AIAB0AGUAeAB0ACAAZgB1AG4AYwB0AGkAbwBuACAAZgBvAHIAIABnAGUAdAB0AGkAbgBnACAAdABoAGUAIABjAGUAbABsACAAaQBkAHMALgAgAEgAZQByAGUAIAB3AGUAIAB3AGEAbgB0ACAAdABoAGUAIABpAGQAIABmAG8AcgAgAHQAaABlACAAYwBvAGwAdQBtAG4AcwAgAA0ACgAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgAA0ACgAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgAGYAbABvAGEAdAAgAG8AZgBmAHMAZQB0ACAAPQAgAHMAaQBuACAAKABmAHIAYQBnAEMAbwBvAHIAZAAuAHgAKgAxADUALgApADsAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAALwAvACAARQBhAGMAaAAgAGQAcgBvAHAAIABvAGYAIAByAGEAaQBuACAAbgBlAGUAZABzACAAdABvACAAcwB0AGEAcgB0ACAAYQB0ACAAYQAgAGQAaQBmAGYAZQByAGUAbgB0ACAAcABvAGkAbgB0AC4AIABUAGgAZQAgAGMAbwBsAHUAbQBuACAAaQBkACAAIABwAGwAdQBzACAAYQAgAHMAaQBuACAAaQBzACAAdQBzAGUAZAAgAHQAbwAgAGcAZQBuAGUAcgBhAHQAZQAgAGEAIABkAGkAZgBmAGUAcgBlAG4AdAAgAG8AZgBmAHMAZQB0ACAAZgBvAHIAIABlAGEAYwBoACAAYwBvAGwAdQBtAG0ADQAKACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAZgBsAG8AYQB0ACAAcwBwAGUAZQBkACAAIAA9ACAAYwBvAHMAIAAoAGYAcgBhAGcAQwBvAG8AcgBkAC4AeAAqADMALgApACoALgAxADUAIAArACAALgAzADUAOwAgACAAIAAgACAAIAAvAC8AIABTAGEAbQBlACAAYQBzACAAYQBiAG8AdgBlACwAIABiAHUAdAAgAGYAbwByACAAcwBwAGUAZQBkAC4AIABTAGkAbgBjAGUAIAB3AGUAIABkAG8AbgB0ACAAdwBhAG4AdAAgAHQAaABlACAAYwBvAGwAdQBtAG4AcwAgAHQAcgBhAHYAZQBsAGwAaQBuAGcAIAB1AHAALAAgAHcAZQAgAGEAcgBlACAAYQBkAGQAaQBuAGcAIAB0AGgAZQAgADAALgA3AC4AIABTAGkAbgBjAGUAIAB0AGgAZQAgAGMAbwBzACAAKgAwAC4AMwAgAGcAbwBlAHMAIABiAGUAdAB3AGUAZQBuACAALQAwAC4AMwAgAGEAbgBkACAAMAAuADMAIAB0AGgAZQAgADAALgA3ACAAZQBuAHMAdQByAGUAcwAgAHQAaABhAHQAIAB0AGgAZQAgAHMAcABlAGUAZAAgAGcAbwBlAHMAIABiAGUAdAB3AGUAZQBuACAAMAAuADQAIABtAGEAZAAgADEALgAwAC4AIABUAGgAaQBzACAAaQBzACAAYQBsAHMAbwAgAGMAbwBuAHQAcgBvAGwAIABwAGEAcgBhAG0AZQB0AGUAcgBzACAAZgBvAHIAIABtAGkAbgAgAGEAbgBkACAAbQBhAHgAIABzAHAAZQBlAGQADQAKACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAZgBsAG8AYQB0ACAAeQAgACAAIAAgACAAIAA9ACAAZgByAGEAYwAoACgAZgByAGEAZwBDAG8AbwByAGQALgB5ACAALwAgAEIAKQAgACAALwAvACAAVABoAGkAcwAgAG0AYQBwAHMAIAB0AGgAZQAgAHMAYwByAGUAZQBuACAAYQBnAGEAaQBuACAAcwBvACAAdABoAGEAdAAgAHQAbwBwACAAaQBzACAAMQAgAGEAbgBkACAAYgB1AHQAdABvAG4AIABpAHMAIAAwAC4AIABUAGgAZQAgAGEAZABkAGkAdABpAG8AbgAgAHcAaQB0AGgAIAB0AGkAbQBlACAAYQBuAGQAIABmAHIAYQBjACAAdwBvAHUAbABkACAAYwBhAHUAcwBlACAAYQBuACAAZQBuAHQAaQByAGUAIABiAGEAcgAgAG0AbwB2AGkAbgBnACAAZgByAG8AbQAgAGIAdQB0AHQAbwBuACAAdABvACAAdABvAHAADQAKACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACsAIABDACAAKgAgAHMAcABlAGUAZAAgACsAIABvAGYAZgBzAGUAdAApADsAIAAgACAAIAAvAC8AIAB0AGgAZQAgAHMAcABlAGUAZAAgAGEAbgBkACAAbwBmAGYAcwBlAHQAIAB3AG8AdQBsAGQAIABjAGEAdQBzAGUAIAB0AGgAZQAgAGMAbwBsAHUAbQBuAHMAIAB0AG8AIABtAG8AdgBlACAAZABvAHcAbgAgAGEAdAAgAGQAaQBmAGYAZQByAGUAbgB0ACAAcwBwAGUAZQBkAHMALgAgAFcAaABpAGMAaAAgAGMAYQB1AHMAZQBzACAAdABoAGUAIAByAGEAaQBuACAAZAByAG8AcAAgAGUAZgBmAGUAYwB0AA0ACgAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgAA0ACgAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgACAAIAAgAHIAZQB0AHUAcgBuACAARQAgAC8AIAAoAHkAKgAyADAALgApADsAIAAgACAAIAAgACAAIAA=,output:2,fname:Function_node_995,width:811,height:328,input:1,input:0,input:0,input:0,input:2,input_1_label:fragCoord,input_2_label:B,input_3_label:C,input_4_label:D,input_5_label:E|A-2868-UVOUT,B-5749-OUT,C-6387-OUT,D-6773-OUT,E-1022-RGB;n:type:ShaderForge.SFN_Vector1,id:7370,x:30889,y:33455,varname:node_7370,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:5749,x:31007,y:33047,varname:node_5749,prsc:2,v1:1;n:type:ShaderForge.SFN_Time,id:3805,x:30827,y:33194,varname:node_3805,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6387,x:31080,y:33229,varname:node_6387,prsc:2|A-3805-T,B-2900-OUT;n:type:ShaderForge.SFN_Slider,id:2900,x:30710,y:33365,ptovrint:False,ptlb:ScrollSpeed,ptin:_ScrollSpeed,varname:node_2900,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.196581,max:20;n:type:ShaderForge.SFN_Color,id:1022,x:31219,y:33374,ptovrint:False,ptlb:Color_Beams,ptin:_Color_Beams,varname:node_1022,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1,c2:1,c3:0.35,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:7048,x:30889,y:33548,ptovrint:False,ptlb:size,ptin:_size,varname:node_7048,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:16;n:type:ShaderForge.SFN_Divide,id:6773,x:31096,y:33482,varname:node_6773,prsc:2|A-7370-OUT,B-7048-OUT;proporder:1304-2900-1022-7048;pass:END;sub:END;*/

Shader "Shader Forge/Matrix" {
    Properties {
        _Color ("Color", Color) = (0,0,0,1)
        _ScrollSpeed ("ScrollSpeed", Range(0, 20)) = 1.196581
        _Color_Beams ("Color_Beams", Color) = (0.1,1,0.35,1)
        _size ("size", Float ) = 16
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
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color;
            float3 Function_node_995( float2 fragCoord , float B , float C , float D , float3 E ){
            fragCoord.x  = floor(fragCoord.x/D);             // This is the exact replica of the calculation in text function for getting the cell ids. Here we want the id for the columns 
                                     
                                     float offset = sin (fragCoord.x*15.);               // Each drop of rain needs to start at a different point. The column id  plus a sin is used to generate a different offset for each columm
                                     float speed  = cos (fragCoord.x*3.)*.15 + .35;      // Same as above, but for speed. Since we dont want the columns travelling up, we are adding the 0.7. Since the cos *0.3 goes between -0.3 and 0.3 the 0.7 ensures that the speed goes between 0.4 mad 1.0. This is also control parameters for min and max speed
                                     float y      = frac((fragCoord.y / B)  // This maps the screen again so that top is 1 and button is 0. The addition with time and frac would cause an entire bar moving from button to top
                                                         + C * speed + offset);    // the speed and offset would cause the columns to move down at different speeds. Which causes the rain drop effect
                                     
                                     return E / (y*20.);       
            }
            
            uniform float _ScrollSpeed;
            uniform float4 _Color_Beams;
            uniform float _size;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = _Color.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 node_3805 = _Time;
                float3 emissive = Function_node_995( i.uv0 , 1.0 , (node_3805.g*_ScrollSpeed) , (1.0/_size) , _Color_Beams.rgb );
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
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
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color;
            float3 Function_node_995( float2 fragCoord , float B , float C , float D , float3 E ){
            fragCoord.x  = floor(fragCoord.x/D);             // This is the exact replica of the calculation in text function for getting the cell ids. Here we want the id for the columns 
                                     
                                     float offset = sin (fragCoord.x*15.);               // Each drop of rain needs to start at a different point. The column id  plus a sin is used to generate a different offset for each columm
                                     float speed  = cos (fragCoord.x*3.)*.15 + .35;      // Same as above, but for speed. Since we dont want the columns travelling up, we are adding the 0.7. Since the cos *0.3 goes between -0.3 and 0.3 the 0.7 ensures that the speed goes between 0.4 mad 1.0. This is also control parameters for min and max speed
                                     float y      = frac((fragCoord.y / B)  // This maps the screen again so that top is 1 and button is 0. The addition with time and frac would cause an entire bar moving from button to top
                                                         + C * speed + offset);    // the speed and offset would cause the columns to move down at different speeds. Which causes the rain drop effect
                                     
                                     return E / (y*20.);       
            }
            
            uniform float _ScrollSpeed;
            uniform float4 _Color_Beams;
            uniform float _size;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = _Color.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
