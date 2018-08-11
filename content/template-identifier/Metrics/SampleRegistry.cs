using App.Metrics;
using App.Metrics.Apdex;
using App.Metrics.Counter;
using App.Metrics.Gauge;
using App.Metrics.Histogram;
using App.Metrics.Meter;
using App.Metrics.ReservoirSampling.ExponentialDecay;
using App.Metrics.ReservoirSampling.Uniform;
using App.Metrics.Timer;

namespace template_identifier.Metrics {

    public static class SampleRegistry
    {
        public static TimerOptions GetBookTimer => new TimerOptions
        {
            Name = "Get Book Timer",
            MeasurementUnit = Unit.Items,
            DurationUnit = TimeUnit.Milliseconds,
            RateUnit = TimeUnit.Milliseconds,
            Reservoir = () => new DefaultForwardDecayingReservoir(sampleSize: 1028, alpha: 0.015)
        };

        public static TimerOptions GetBooksTimer => new TimerOptions
        {
            Name = "Get Books Timer",
            MeasurementUnit = Unit.Items,
            DurationUnit = TimeUnit.Milliseconds,
            RateUnit = TimeUnit.Milliseconds,
            Reservoir = () => new DefaultForwardDecayingReservoir(sampleSize: 1028, alpha: 0.015)
        };
    }
}