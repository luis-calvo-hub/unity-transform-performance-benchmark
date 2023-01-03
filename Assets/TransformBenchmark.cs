using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Profiling;

public class TransformBenchmark : MonoBehaviour {
    public int iterations = 1000000;
    
    private void Awake() {
        Benchmark(iterations, BenchmarkGetComponentTransform);
        Benchmark(iterations, BenchmarkPropertyTransform);
    }

    private void Benchmark(int iterations, Action action) {
        Stopwatch sw = new();
        sw.Start();
        for (int i = 0; i < iterations; i++) {
            action();
        }
        sw.Stop();
        UnityEngine.Debug.Log($"{sw.Elapsed.TotalMilliseconds} Milliseconds has passed on Benchmark: {action.Method.Name}");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void BenchmarkGetComponentTransform() {
        _ = GetComponent<Transform>();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void BenchmarkPropertyTransform() {
        _ = transform;
    }
}
