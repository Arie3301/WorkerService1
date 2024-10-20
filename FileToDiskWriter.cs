using System;
using System.IO;

public class FileToDiskWriter {

  public FileToDiskWriter() {
    incr = 0;
  }

  private int incr;

  public void WriteFileToDisk() {
  string folderPath = @"C:\Users\arie_\repos\WorkerService1\out";

  string fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
  string filePath = Path.Combine(folderPath, fileName);

  File.WriteAllText(filePath, $"Hello World {incr}");

  Console.WriteLine($"File created at: {filePath}");
  incr++;
  }
}
