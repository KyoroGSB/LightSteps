Shader "Custom/Outline"
{
	Properties//Variables
	{
	 	_MainTex("Main Texture (RGB)",2D) = "white" {}//Allows for a texture property
	 	_Color("Color",color) = (1,1,1,1) // Allows for a color property
		_TransVal("Transparency Value", Range(0,1)) = 0.5
		_OutlineTex("Outline Texture",2D) = "white" {}
		_OutlineColor("Outline Color", Color) = (1,1,1,1)
		_OutlineWidth("Outline Width", Range(1.0, 10.0)) = 1.1
	}
	Subshader
	{

		Tags
		{
			"Queue" = "Transparent"
		}
			
			 Blend SrcAlpha OneMinusSrcAlpha
		Pass
		{
			Name "OUTLINE"

			ZWrite Off

			CGPROGRAM//Allow talk between two languages: shader lab and nvidia C for graphics.
			//\=============================================================================================
			//\ Function Define - defines hte name for the vertex and fragment function.
			//\=============================================================================================

			#pragma vertex vert //Define for the buliding function.

			#pragma fragment frag //Define for color function.

			//\=============================================================================================
			//\ Includes
			//\=============================================================================================

			#include "UnityCG.cginc"//Built in shader functions.

			//\=============================================================================================
			//\ Structures - Can get data like - verticles's, normal, color, uv.
			//\=============================================================================================
			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};
			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};
			//\=============================================================================================
			//\ Imports - Re-import property from shader lab to nvidia cg.
			//\=============================================================================================
			
			float _OutlineWidth;
			float4 _OutlineColor;
			sampler2D _OutlineTex;
			float _TransVal;
			//\=============================================================================================
			//\ Vertex Function - Builds the object
			//\=============================================================================================

			v2f vert(appdata IN)
			{
				IN.vertex.xyz *= _OutlineWidth;
				v2f OUT;

				OUT.pos = UnityObjectToClipPos(IN.vertex);
				OUT.uv = IN.uv;

				return OUT;

			}

			//\=============================================================================================
			//\ Fragment Function - Color it in.
			//\=============================================================================================
			fixed4 frag(v2f IN) : SV_Target
			{
				float4 texColor = tex2D(_OutlineTex, IN.uv);//Wraps the texture around the uv's.
				return texColor * _OutlineColor * _TransVal;//Tints the texture.
			}


			ENDCG
		}
		Pass
		{
            Name"OBJECT"
			CGPROGRAM//Allow talk between two languages: shader lab and nvidia C for graphics.
			//\=============================================================================================
			//\ Function Define - defines hte name for the vertex and fragment function.
			//\=============================================================================================

			#pragma vertex vert //Define for the buliding function.

			#pragma fragment frag //Define for color function.

			//\=============================================================================================
			//\ Includes
			//\=============================================================================================

			#include "UnityCG.cginc"//Built in shader functions.

			//\=============================================================================================
			//\ Structures - Can get data like - verticles's, normal, color, uv.
			//\=============================================================================================
			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};
			struct v2f 
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};
			//\=============================================================================================
			//\ Imports - Re-import property from shader lab to nvidia cg.
			//\=============================================================================================

			float4 _Color;
			sampler2D _MainTex;
			float _TransVal;
			//\=============================================================================================
			//\ Vertex Function - Builds the object
			//\=============================================================================================

			v2f vert(appdata IN)
			{
				v2f OUT;

				OUT.pos = UnityObjectToClipPos(IN.vertex);
				OUT.uv = IN.uv;

				return OUT;

			}

			//\=============================================================================================
			//\ Fragment Function - Color it in.
			//\=============================================================================================
			fixed4 frag(v2f IN) : SV_Target
			{
				float4 texColor = tex2D(_MainTex, IN.uv);//Wraps the texture around the uv's.
				return texColor * _Color * _TransVal;//Tints the texture.
			}


			ENDCG
		}
	}
}
