using System;
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

    public static class GenericRegistry
    {
        public static TimerOptions Exists(Type t) => new TimerOptions
        {
            Name = $"Exists Timer {t.FullName}",
            MeasurementUnit = Unit.Items,
            DurationUnit = TimeUnit.Milliseconds,
            RateUnit = TimeUnit.Milliseconds,
            Reservoir = () => new DefaultForwardDecayingReservoir(sampleSize: 1028, alpha: 0.015)
        };
        internal static TimerOptions Get(Type t) => new TimerOptions
        {
            Name = $"Get Timer {t.FullName}",
            MeasurementUnit = Unit.Items,
            DurationUnit = TimeUnit.Milliseconds,
            RateUnit = TimeUnit.Milliseconds,
            Reservoir = () => new DefaultForwardDecayingReservoir(sampleSize: 1028, alpha: 0.015)
        };

        internal static TimerOptions GetById(Type t) => new TimerOptions
        {
            Name = $"GetById Timer {t.FullName}",
            MeasurementUnit = Unit.Items,
            DurationUnit = TimeUnit.Milliseconds,
            RateUnit = TimeUnit.Milliseconds,
            Reservoir = () => new DefaultForwardDecayingReservoir(sampleSize: 1028, alpha: 0.015)
        };

        internal static TimerOptions Post(Type t) => new TimerOptions
        {
            Name = $"Post Timer {t.FullName}",
            MeasurementUnit = Unit.Items,
            DurationUnit = TimeUnit.Milliseconds,
            RateUnit = TimeUnit.Milliseconds,
            Reservoir = () => new DefaultForwardDecayingReservoir(sampleSize: 1028, alpha: 0.015)
        };
        internal static TimerOptions Patch(Type t) => new TimerOptions
        {
            Name = $"Patch Timer {t.FullName}",
            MeasurementUnit = Unit.Items,
            DurationUnit = TimeUnit.Milliseconds,
            RateUnit = TimeUnit.Milliseconds,
            Reservoir = () => new DefaultForwardDecayingReservoir(sampleSize: 1028, alpha: 0.015)
        };

        internal static TimerOptions Put(Type t) => new TimerOptions
        {
            Name = $"Put Timer {t.FullName}",
            MeasurementUnit = Unit.Items,
            DurationUnit = TimeUnit.Milliseconds,
            RateUnit = TimeUnit.Milliseconds,
            Reservoir = () => new DefaultForwardDecayingReservoir(sampleSize: 1028, alpha: 0.015)
        };

        internal static TimerOptions Delete(Type t) => new TimerOptions
        {
            Name = $"Delete Timer {t.FullName}",
            MeasurementUnit = Unit.Items,
            DurationUnit = TimeUnit.Milliseconds,
            RateUnit = TimeUnit.Milliseconds,
            Reservoir = () => new DefaultForwardDecayingReservoir(sampleSize: 1028, alpha: 0.015)
        };
    }
}