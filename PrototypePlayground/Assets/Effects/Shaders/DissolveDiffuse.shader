Shader "Custom/DissolveDiffuse"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
		_DissolveTexture("Dissolve Texture", 2D) = "white" {}
		_Amount("Amount", Range(-0.2,1)) = 0
        _DissolveColor ("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard addshadow


        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
		sampler2D _DissolveTexture;
		half _Amount;

        struct Input
        {
            float2 uv_MainTex;
			float2 uv_DissolveTexture;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
		fixed4 _DissolveColor;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
			//Dissolve function
			half dissolve_value = tex2D(_DissolveTexture, IN.uv_DissolveTexture).r;
			clip(dissolve_value - _Amount);
			o.Emission = _DissolveColor.rgb * step( dissolve_value - _Amount, 0.05f); //emits white color with 0.05 border size 
			//Basic shader function
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color; 
 
			o.Albedo = c.rgb;
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
