#nullable enable
using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Coosu.Storyboard;
using Coosu.Storyboard.Extensions.Optimizing;

namespace Milki.OsbOptimizer.CommandLine
{
    internal class Program
    {
        private static string? _version;

        private class Arguments
        {
            public int ThreadCount { get; set; }
            public string? OutputPath { get; set; }
            public string InputPath { get; set; } = null!;
        }

        static async Task<int> Main(string[] args)
        {
            var rootCommand = new RootCommand
            {
                new Option<int>(new[] { "-t", "--thread-count" },
                    () => Environment.ProcessorCount,
                    "Threads used for compressing script."),
                new Option<string?>(new[] { "-o", "--output-path" },
                    "Specified output path."),
                new Argument<string>("--input-path", "Specified input path."),
            };

            rootCommand.Description = "osb-optimizer commandline " + GetVersion();
            rootCommand.Handler = CommandHandler.Create<Arguments>(Execution);

            var ret = await rootCommand.InvokeAsync(args);

            if (ret != 0) await Task.Delay(1500);
            else await Task.Delay(500);
            return ret;
        }

        private static async Task<int> Execution(Arguments arguments)
        {
            try
            {
                Console.WriteLine("Parsing file...");
                var stopwatch = Stopwatch.StartNew();
                var layer = await Layer.ParseFromFileAsync(arguments.InputPath);
                Console.WriteLine($"Done within {Math.Round(stopwatch.Elapsed.TotalMilliseconds, 2)}ms.");
                var compressor = new SpriteCompressor(layer, new CompressOptions
                {
                    ThreadCount = arguments.ThreadCount
                });

                Console.WriteLine($"Compressing file with {arguments.ThreadCount} threads...");
                stopwatch.Restart();
                await compressor.CompressAsync();
                Console.WriteLine($"Done in {Math.Round(stopwatch.Elapsed.TotalMilliseconds, 2)}ms.");

                string outputPath;
                if (arguments.OutputPath == default)
                {
                    var filename = Path.GetFileNameWithoutExtension(arguments.InputPath);
                    outputPath = $"./{filename}-optimized.osb";
                }
                else
                {
                    outputPath = arguments.OutputPath;
                }


                await using var sw = new StreamWriter(outputPath);
                await layer.WriteFullScriptAsync(sw);
                return 0;
            }
            catch (Exception e)
            {
                await Console.Error.WriteLineAsync($"Error occurs while executing: {e.Message}");
                return -1;
            }
        }
        private static string GetVersion()
        {
            if (_version != null) return _version;

            var assembly = Assembly.GetEntryAssembly();
            //var nameAttr = (AssemblyProductAttribute)assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false)[0];

            var verAttr = ((AssemblyInformationalVersionAttribute)assembly.GetCustomAttributes(
                typeof(AssemblyInformationalVersionAttribute), false)[0]).InformationalVersion;

            _version = verAttr;

            return _version;
        }
    }
}
