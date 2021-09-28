Shader "Unlit/Light" // shader will appear as FakeHalo in Unlit folder
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {} // user properties that we can change in UI
  }
  SubShader
  {
    Tags { "RenderType"="Opaque" } // hints for Unity how to render object and when
    LOD 100 // used when we want to change quality settings

    Pass
    {
      CGPROGRAM
      #pragma vertex vert // declaration of vertex shader stage. It will use vert name
      #pragma fragment frag // declaration of fragment shader stage. It will use frag name
      // make fog work
      #pragma multi_compile_fog // means shader will receive fog from unity lighting settings
     
      #include "UnityCG.cginc" // library of common shader functions and variables

      struct appdata // stuff that we want to be sent from unity app
      {
        float4 vertex : POSITION; // vertex positions of model.
        float2 uv : TEXCOORD0; // uv coords of model
      };

      struct v2f // struct that will be used to pass data between vertex program and fragment program
      {
        float2 uv : TEXCOORD0; // pass the uv coords so we can use them to sample texture                  
        UNITY_FOG_COORDS(1) // transfer of fog
        float4 vertex : SV_POSITION; // we need something to interpolate
      };

      sampler2D _MainTex; // repeat of declaration
      float4 _MainTex_ST; // additional variable with uv that stores scale and offset
     
      v2f vert (appdata v) // vertex program that use appdata as input
      {
        v2f o; // declaration of output struct
        o.vertex = UnityObjectToClipPos(v.vertex); // Make MVP multiply
        o.uv = TRANSFORM_TEX(v.uv, _MainTex); // uses _MainTex_ST and generate uvs
        UNITY_TRANSFER_FOG(o,o.vertex); // further passing of fog fade
        return o; // passing to the next stage
      }
     
      fixed4 frag (v2f i) : SV_Target // fragment program that uses v2f struct as input
      {
        // sample the texture
        fixed4 col = tex2D(_MainTex, i.uv); // rgba data grabbed from texture
        // apply fog
        UNITY_APPLY_FOG(i.fogCoord, col); // apply fog form lighting settings
        return col; // display at screen
      }
      ENDCG
    }
  }
}