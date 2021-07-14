using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResourcePackUtils
{
    static class Program
    {
        private const string devAppendTag = "";
        private const string betaAppendTag = "BETA_1";

        private static string _path = string.Empty;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                foreach (string arg in args)
                {
                    if (Directory.Exists(arg)) _path = arg;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ResourcePackUtils(_path));
        }

        public static bool IsStableBuild()
        {
            return (!IsDevBuild() && !IsBetaBuild());
        }

        public static bool IsBetaBuild()
        {
            return !String.IsNullOrWhiteSpace(betaAppendTag);
        }

        public static bool IsDevBuild()
        {
            return !String.IsNullOrWhiteSpace(devAppendTag);
        }

        public static string GetVersion()
        {
            string[] ver = (typeof(Program).Assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version).Split('.');
            if (IsDevBuild())
                return "v" + ver[0] + "." + ver[1] + "." + ver[2] + " (" + devAppendTag + ")";
            else if (IsBetaBuild())
                return "v" + ver[0] + "." + ver[1] + "." + ver[2] + " (" + betaAppendTag + ")";
            else
                return "v" + ver[0] + "." + ver[1] + "." + ver[2];
        }
    }
}
