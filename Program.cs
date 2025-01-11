// See https://aka.ms/new-console-template for more information
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Webp;

///-----------------------------------
///Webp to jpeg変換プログラム
///-----------------------------------
try
{
    Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■");
    Console.WriteLine("Webp to jpeg変換プログラム");
    Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■");
    Console.WriteLine("");

    //コマンドライン引数を配列で取得する
    string[] cmds = System.Environment.GetCommandLineArgs();
    if (cmds.Length < 3)
    {
        throw new Exception("引数が足りません。\n[対象パス] [保存パス]");
    }

    // 対象パスの取得
    string tgtPath = cmds[1];
    Console.WriteLine($"対象パス :{tgtPath} ");
    if (!System.IO.Directory.Exists(tgtPath))
    {
        throw new Exception($"対象パスが存在しません。");
    }

    // 保存パスの取得
    string savePath = cmds[2];
    Console.WriteLine($"保存パス :{savePath} ");
    if (!System.IO.Directory.Exists(savePath))
    {
        throw new Exception($"保存パスが存在しません。");
    }

    Console.WriteLine("");


    //ファイル取得
    string[] files = Directory.GetFiles(tgtPath, "*.webp", SearchOption.TopDirectoryOnly);
    foreach (string file in files)
    {

        string inputFile = file;
        string outputFile = Path.Combine(savePath, Path.GetFileNameWithoutExtension(file)) + ".jpg";

        if(File.Exists(outputFile))
        {
            Console.WriteLine("Skip : " + outputFile);
            continue;
        }
        using (Image image = Image.Load(inputFile))
        {
            Console.WriteLine("webp to Jpeg : " + outputFile);
            var jpeg = new JpegEncoder();
            image.Save(outputFile, jpeg);
        }
    }

    Console.WriteLine($"終了しました。");
}
catch (Exception ex)
{
    Console.WriteLine("ERROR ---------------------------------");
    Console.WriteLine(ex.Message);
    Console.WriteLine("--------------------------------- ERROR");
}

