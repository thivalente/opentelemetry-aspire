using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace OpenTelemetryAspireApi.Setup
{
    public static class LoggingConfig
    {
        private const string ApplicationName = "OpenTelemetryAspire";

        public static WebApplicationBuilder AddLoggingConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddOpenTelemetry()
                            .ConfigureResource(resource => resource.AddService(ApplicationName))
                            .WithMetrics(metrics =>
                            {
                                metrics
                                    .AddAspNetCoreInstrumentation()
                                    .AddHttpClientInstrumentation();

                                metrics.AddOtlpExporter();
                            })
                            .WithTracing(tracing =>
                            {
                                tracing
                                    .AddAspNetCoreInstrumentation()
                                    .AddHttpClientInstrumentation();

                                tracing.AddOtlpExporter();
                            });

            builder.Logging.ClearProviders();
            builder.Logging.AddOpenTelemetry(logging =>
            {
                logging.IncludeScopes = true;
                logging.IncludeFormattedMessage = true;

                logging.AddOtlpExporter();
            });

            return builder;
        }
    }
}
