// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "OutlineThroughWalls"
{
	Properties
	{
		_OutlineColour("OutlineColour", Color) = (0,0,0,0)
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		_OutlineAlpha("OutlineAlpha", Range( -0.5 , 10)) = 2.594118
		_OutlineThickness("Outline Thickness", Range( -0.5 , 10)) = 2.594118
		_ObjectColour("Object Colour", Color) = (0,0,0,0)
		[Toggle]_ColourDiffuseToggle("Colour/Diffuse Toggle", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Pass
		{
			ColorMask 0
			ZTest LEqual
			ZWrite On
		}

		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0"}
		ZTest Greater
		Cull Front
		CGPROGRAM
		#pragma target 3.0
		#pragma surface outlineSurf Outline nofog alpha:fade  keepalpha noshadow noambient novertexlights nolightmap nodynlightmap nodirlightmap nometa noforwardadd vertex:outlineVertexDataFunc 
		
		
		
		struct Input
		{
			half filler;
		};
		uniform float _OutlineThickness;
		uniform float4 _OutlineColour;
		uniform float _OutlineAlpha;
		
		void outlineVertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float outlineVar = _OutlineThickness;
			v.vertex.xyz += ( v.normal * outlineVar );
		}
		inline half4 LightingOutline( SurfaceOutput s, half3 lightDir, half atten ) { return half4 ( 0,0,0, s.Alpha); }
		void outlineSurf( Input i, inout SurfaceOutput o )
		{
			o.Emission = _OutlineColour.rgb;
			o.Alpha = _OutlineAlpha;
		}
		ENDCG
		

		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "Geometry+0" }
		Cull Back
		ZWrite On
		ZTest GEqual
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows exclude_path:deferred vertex:vertexDataFunc 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform half _ColourDiffuseToggle;
		uniform sampler2D _TextureSample0;
		uniform float4 _TextureSample0_ST;
		uniform float4 _ObjectColour;

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			v.vertex.xyz += 0;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_TextureSample0 = i.uv_texcoord * _TextureSample0_ST.xy + _TextureSample0_ST.zw;
			o.Albedo = lerp(tex2D( _TextureSample0, uv_TextureSample0 ),_ObjectColour,_ColourDiffuseToggle).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=15600
1690;289;826;623;940.444;413.491;1.365;True;False
Node;AmplifyShaderEditor.SamplerNode;5;-527.1874,-279.3091;Float;True;Property;_TextureSample0;Texture Sample 0;2;0;Create;True;0;0;False;0;None;84508b93f15f2b64386ec07486afc7a3;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;10;-510.4673,-66.78091;Float;False;Property;_ObjectColour;Object Colour;5;0;Create;True;0;0;False;0;0,0,0,0;0,0,0,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;2;-560.9354,176.9964;Float;False;Property;_OutlineColour;OutlineColour;1;0;Create;True;0;0;False;0;0,0,0,0;1,0,0,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;9;-632.7094,349.0916;Float;False;Property;_OutlineAlpha;OutlineAlpha;3;0;Create;True;0;0;False;0;2.594118;2.2;-0.5;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;7;-634.051,424.9051;Float;False;Property;_OutlineThickness;Outline Thickness;4;0;Create;True;0;0;False;0;2.594118;0.1;-0.5;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.ToggleSwitchNode;11;-215.6293,-12.18099;Half;False;Property;_ColourDiffuseToggle;Colour/Diffuse Toggle;6;0;Create;True;0;0;False;0;0;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.OutlineNode;6;-296.8881,268.0063;Float;False;0;True;Transparent;0;2;Front;3;0;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;4;68.25001,-8.190001;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;OutlineThroughWalls;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;1;False;-1;4;False;-1;False;0;False;-1;0;False;-1;True;3;Custom;0.6;True;True;0;False;TransparentCutout;;Geometry;ForwardOnly;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;1;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0.41;1,0.01415092,0.01415092,0;VertexOffset;False;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;11;0;5;0
WireConnection;11;1;10;0
WireConnection;6;0;2;0
WireConnection;6;2;9;0
WireConnection;6;1;7;0
WireConnection;4;0;11;0
WireConnection;4;11;6;0
ASEEND*/
//CHKSM=1F8FAD75DE826B3C3124A5B472F36C1665CB80A8