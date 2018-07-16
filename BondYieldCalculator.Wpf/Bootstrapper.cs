using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using NLog;

namespace BondYieldCalculator.Wpf
{
    public class Bootstrapper
    {
        // In case we need command args; not used in this project
        private string[] _args;

        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public Bootstrapper(string[] args)
        {
            Log.Info($"Starting Application. Thread: {Thread.CurrentThread.ManagedThreadId}; Isbackground: {Thread.CurrentThread.IsBackground}");
            _args = args;
            Initialize();
        }

        private void Initialize()
        {
            Log.Info("Starting MEF Composition");

            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var dllsCatalog = new DirectoryCatalog(path, "*.dll");
            var exeCatalog = new DirectoryCatalog(path, "*.exe");

            MefContainer = new CompositionContainer(new AggregateCatalog(dllsCatalog, exeCatalog));

            Log.Info("Finished MEF Composition. Number of Parts: {0}", MefContainer.Catalog.Parts.Count());
            Log.Info("List of Parts -- Begin");

            MefContainer.Catalog.Parts.ForEach(c => Log.Info(c.ToString()));

            Log.Info("List of Parts -- End");
        }

        public static CompositionContainer MefContainer { get; private set; }
    }
}
