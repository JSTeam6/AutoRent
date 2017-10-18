using Client.Core.Contracts;
using System;
using System.Diagnostics;

namespace Traveller.Decorators
{
    public class EngineDecorator : IEngine
    {
        private readonly IEngine engine;
        private readonly IWriter writer;

        public EngineDecorator(IEngine engine, IWriter writer)
        {
            this.engine = engine ?? throw new ArgumentNullException("Engine can't be null!");
            this.writer = writer ?? throw new ArgumentNullException("Writer can't be null!");
        }

        public void Start()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            this.writer.Write("The Engine is starting..." + Environment.NewLine);
            this.engine.Start();
            stopwatch.Stop();
            long elapsedTime = stopwatch.ElapsedMilliseconds;

            this.writer.Write($"The Engine worked for {elapsedTime} milliseconds." + Environment.NewLine);
        }
    }
}
