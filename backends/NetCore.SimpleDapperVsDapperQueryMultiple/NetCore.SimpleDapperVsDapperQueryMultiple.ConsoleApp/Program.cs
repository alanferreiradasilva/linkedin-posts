// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;
using NetCore.SimpleDapperVsDapperQueryMultiple.ConsoleApp.Benchmarks;
using NetCore.SimpleDapperVsDapperQueryMultiple.ConsoleApp.Repositories;

ProductRepository _repository = new ProductRepository();
_repository.RunSeed();
var result = await _repository.GetSimpleDapper();
var resultMulti = await _repository.GetDapperQueryMultiple();

//var config = DefaultConfig.Instance
//            .WithOptions(ConfigOptions.DisableOptimizationsValidator)
//            .AddJob(Job.Default.WithToolchain(InProcessNoEmitToolchain.Instance));
//BenchmarkRunner.Run<ProductBenchmark>(config);