using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        string folderPath = @"C:\Users\sungu\OneDrive\Masaüstü\Fatura\"; // Dosya yolunu aldık

        string ftrFileName = "I-FTR"+DateTime.Now.ToShortDateString()+"-00001.txt";
        string fdyFileName = "I-FDY20240927-00001.txt";

        // Klasördeki tüm dosyaların listesini al
        string[] files = Directory.GetFiles(folderPath);

        for (int i = 0; i < files.Length; i++)
        {
            // Dosya yolunu al
            string filePath = files[i];

            // Dosya adını al
            string fileName = Path.GetFileName(filePath);

            if (File.Exists(filePath))
            {
                string dateSuffix = DateTime.Now.ToString("yyyyMMddHHmm");
                string newFileName = "";

                if (fileName == ftrFileName)
                {
                    // Yeni dosya adını oluşturun
                    newFileName = "ftrFile-" + dateSuffix + Path.GetExtension(filePath);
                    string newFilePath = Path.Combine(folderPath, newFileName);
                    File.Move(filePath, newFilePath);
                    Debug.WriteLine($"Dosya yeniden adlandırıldı: {filePath} -> {newFilePath}");
                }
                else if (fileName == fdyFileName)
                {
                    newFileName = "fdyFile-" + dateSuffix + Path.GetExtension(filePath);
                    string newFilePath = Path.Combine(folderPath, newFileName);
                    File.Move(filePath, newFilePath);
                    Debug.WriteLine($"Dosya yeniden adlandırıldı: {filePath} -> {newFilePath}");
                }
            }
            else
            {
                Debug.WriteLine($"Dosya bulunamadı: {filePath}");
            }
        }
    }
}
