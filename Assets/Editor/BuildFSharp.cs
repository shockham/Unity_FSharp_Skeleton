using UnityEngine;
using UnityEditor;
using System.Diagnostics;
using System;

class BuildFSharp : AssetPostprocessor {
    static void OnPostprocessAllAssets (string[] ia, string[] da, string[] ma, string[] mfap) {
        // skip if importing dll as already built
        if (Array.IndexOf(ia, "Assets/dll/scripts.dll") > -1) return;

        // setup the process
        var p = new Process();
        p.StartInfo.FileName = "/usr/bin/make";
        p.StartInfo.Arguments = "-C " + System.IO.Directory.GetCurrentDirectory() + "/Assets/Editor/";
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.RedirectStandardError = true;

        // assign events
        p.OutputDataReceived +=
            new DataReceivedEventHandler((o, e) => {
                if (e.Data != null) {
                    UnityEngine.Debug.Log(e.Data);
                }
            });
        p.ErrorDataReceived +=
            new DataReceivedEventHandler((o, e) => {
                if (e.Data != null) {
                    UnityEngine.Debug.LogError(e.Data);
                }
            });

        // start to process and output/error reading
        p.Start();
        p.BeginOutputReadLine();
        p.BeginErrorReadLine();
    }
}
