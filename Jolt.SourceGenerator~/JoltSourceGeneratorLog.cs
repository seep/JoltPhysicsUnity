using System;
using System.IO;
using System.Text;

namespace Jolt.SourceGenerators;

/// <summary>
/// Simple log stream that writes to a temp file if possible.
/// </summary>
internal class JoltSourceGeneratorLog
{
    private StringBuilder logs = new StringBuilder();
    
    public void Debug(string message)
    {
        logs.AppendLine($"[DEBUG {DateTime.Now}] {message}");
    }

    public void Error(string message)
    {
        logs.AppendLine($"[ERROR {DateTime.Now}] {message}");
    }
    
    public void Flush()
    {
        try
        {
            File.WriteAllText(Path.Combine(Path.GetTempPath(), "JoltPhysicsUnitySourceGenerator.log"), logs.ToString());
        }
        catch
        {
            // skip logs
        }
    }
}