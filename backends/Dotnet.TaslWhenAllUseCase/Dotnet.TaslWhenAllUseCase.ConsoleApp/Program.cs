// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;
using Dotnet.TaslWhenAllUseCase.ConsoleApp.Benchmarks;

Console.WriteLine("Hello, World!");

var config = DefaultConfig.Instance
            .WithOptions(ConfigOptions.DisableOptimizationsValidator)
            .AddJob(Job.Default.WithToolchain(InProcessNoEmitToolchain.Instance));

BenchmarkRunner.Run<PostDetailsBenchmark>(config);
