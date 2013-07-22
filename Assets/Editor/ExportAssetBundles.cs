using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// shsres
/// </summary>
public class ExportAssetBundles
{
	[MenuItem("Assets/BundleBuild/iOS")]
	static void ExportIOS ()
	{
		CompressAssetsDelegate (BuildTarget.iPhone);
	}

	[MenuItem("Assets/BundleBuild/Web")]
	static void ExportWeb ()
	{
		CompressAssetsDelegate (BuildTarget.WebPlayer);
	}
	
	static void CompressAssetsDelegate (BuildTarget buildTarget)
	{
		Object[] selection = Selection.GetFiltered (typeof(Object), SelectionMode.DeepAssets);

		string path = string.Format ("{0}/{1}.unity3d", "Assets", selection[0].name);

		BuildPipeline.BuildAssetBundle (
				selection[0], 
				selection, 
				path, 
				BuildAssetBundleOptions.CompleteAssets | BuildAssetBundleOptions.CollectDependencies, 
				buildTarget);
	}
}
