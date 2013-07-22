AddScriptRuntime
================

AssetBundleにDLLを含め、ランタイムでコンポーネントに追加する機能のデモです。iOSを始めとするJIT不可のプラットフォームでは動作しません。

なお、「スクリプトをアタッチ済みのプレハブを読みたい」といった場合、別段特別な処理する事なく、AssetBundleにプレハブを含めれば読み込めます。（Package/clock script with prefab.unity3d参考）

###デモ

https://dl.dropboxusercontent.com/u/56297224/UnitySumple2/AssetBundle%E3%81%8B%E3%82%89%E3%83%95%E3%82%A1%E3%82%A4%E3%83%AB%E3%82%92%E8%AA%AD%E3%81%BF%E5%8F%96%E3%82%8B%E3%83%87%E3%83%A2/web.html
###元ネタ

http://docs-jp.unity3d.com/Documentation/Manual/Including%20scripts%20in%20AssetBundles.html


---
###作成手順

1.インポートするスクリプトをDLL化し、拡張子をbytesとする

2.AssetBundleに1の手順で作成したbytesファイルを含める


###読込手順
1.WWWクラスでAssetBundleをインスタンス化

2.プレハブからTextAsset形式でbytes化したファイルを取得

3.Assembly.Load でbyteをアセンブルに読込

4.typeで型情報を取得し、addComponentで追加

---

unity 4.1.5で作成されています。
