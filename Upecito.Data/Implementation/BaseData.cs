using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upecito.Data.Implementation
{
    public class BaseData
    {
        protected const string ConnectionName = "MyConnectionString";

        protected void LogError(Exception exc)
        {
            var iexc = exc.InnerException;

            // perform logging
            System.IO.StreamWriter writer = null;
            try
            {
                var path = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) + System.IO.Path.DirectorySeparatorChar;
                var logFileFolder = $"{path}Log{System.IO.Path.DirectorySeparatorChar}{DateTime.Now:MMM-yyyy}{System.IO.Path.DirectorySeparatorChar}";

                if (!System.IO.Directory.Exists(logFileFolder))
                    System.IO.Directory.CreateDirectory(logFileFolder);

                writer = System.IO.File.AppendText($"{logFileFolder}Bot_Error_[{DateTime.Now:ddMMMyyyy}].log");

                writer.WriteLine($"DATE AND TIME OF EXCEPTION : {DateTime.Now:MM/dd/yyyy HH:mm:ss}");

                writer.WriteLine($"MACHINE NAME               : {Environment.MachineName}");
                writer.WriteLine($"EXCEPTION SOURCE           : {exc.Source}");
                writer.WriteLine($"EXCEPTION TYPE             : {exc.GetType().FullName}");
                writer.WriteLine($"EXCEPTION MESSAGE          : {exc.Message}");
                writer.WriteLine($"EXCEPTION STACK TRACE      : {exc.StackTrace}");

                if (iexc != null)
                {
                    writer.WriteLine($"INNER EXCEPTION SOURCE     : {iexc.Source}");
                    writer.WriteLine($"INNER EXCEPTION TYPE       : {iexc.GetType().FullName}");
                    writer.WriteLine($"INNER EXCEPTION MESSAGE    : {iexc.Message}");
                    writer.WriteLine($"INNER EXCEPTION STACK TRACE: {iexc.StackTrace}");
                }

                writer.WriteLine($"FULL EXCEPTION             : {exc}");
                writer.WriteLine($"CALL STACK                 : {Environment.StackTrace}");

                writer.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                writer.Flush();
            }
            catch (Exception ex)
            {
                writer.WriteLine("Exception: " + ex.Message);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
    }
}
