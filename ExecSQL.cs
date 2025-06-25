using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Reflection;

namespace SQLAgain
{
    class ExecSQL
    {
        public static string DoSQL(string sqlPlusPath, string db, string dbConnectString, string sqlFile, string logFile, string options, string processIDFile, int timeout, bool ignoreErrors)
        {
            string sqlOptions = string.Empty;
            string sqlFormat = "DEFAULT";
            string sqlStartFile = "SQLAgainStart.sql";


            List<string> textList = new List<string>();
            StreamWriter sw = new StreamWriter(logFile, true);
            DateTime localTime = DateTime.Now;
            string formatDate = "yyyy'/'MM'/'dd HH:mm:ss";
            Stopwatch stopWatch = Stopwatch.StartNew(); //creates and start the instance of Stopwatch
            string[] stopErrors = new string[]
                {
                    "ORA-01017",    // ORA-01017: invalid username/password; logon denied
                    "ORA-12170",    // ORA-12170: TNS:Connect timeout occurred
                    "ORA-12154",    // ORA-12154: TNS: could not resolve the connect identifier specified 
                    "ORA-12514",    // ORA-12514: TNS listener does not currently know of service requested in connect descriptor
                    "ORA-12545",    // ORA-12545: Connect failed because target host or object does not exist
                    "ORA-28001",    // ORA-28001: the password has expired
                };
            if (ignoreErrors)
            {
                stopErrors = "Enter value ".Split('.');
            }
            Process p = new Process();
            foreach (string value in options.Split(' '))
            {
                switch (value)
                {
                    case ("-S"):    // use -S (silent) as 1st argument in sql.exe
                        sqlOptions += "-S";
                        break;
                    case ("CSV"):   // set sqlformat CSV - needs to be hardcoded in the file; no variable allowed here
                        sqlStartFile = "SQLAgainStart_CSV.sql";
                        break;
                    case ("HTML"):  // set sqlformat HTML - needs to be hardcoded in the file; no variable allowed here
                        sqlStartFile = "SQLAgainStart_HTML.sql";
                        sqlFormat = "HTML";
                        break;
                }
            }
            if (logFile.Contains(".htm"))  sqlFormat = "HTML";      // Change sqlFormat to HTML when the logFile contains .htm - even when Option is not HTML (and sqlStartFile is not *_HTML.sql)
            sqlStartFile = "\"" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + sqlStartFile +"\"" ;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = sqlPlusPath;
            p.StartInfo.Arguments = string.Format("{0} -L {1} @{2} {3}", sqlOptions, dbConnectString, sqlStartFile,  AddQuotesIfRequired(sqlFile));
            if (sqlFormat == "HTML") sw.WriteLine("<pre>");
            sw.WriteLine(new string('*', 100));
            sw.WriteLine(string.Format("*** {0}   ***   Oracle TNS Alias: {1}", localTime.ToString(formatDate), db));
            sw.WriteLine(new string('*', 100));
            if (sqlFormat == "HTML") sw.WriteLine("</pre>");
            p.OutputDataReceived += new DataReceivedEventHandler((s, e) =>
            {
                try
                {
                    sw.WriteLine(e.Data);
                }
                catch (IndexOutOfRangeException ex)
                {
                    sw.WriteLine(ex.Message);
                }       
                catch (ObjectDisposedException ex)
                {

                    StreamWriter sw2 = new StreamWriter(logFile, true);
                    sw2.WriteLine("catch block ObjectDisposedException");
                    sw2.WriteLine(ex.Message);
                 }
                
                if (!string.IsNullOrWhiteSpace(e.Data))
                {
                    //Match match = Regex.Match(e.Data, @"\b[A-Z]{3,5}-\d{3,7}"); // search on word boundary 3-5 char Aplha uppercase '-' 3-7 numbers
                    Match match = Regex.Match(e.Data, @"^(SQL Error: )?(\b[A-Z]{3,5}-\d{3,7})");        // search on start of line, word boundary 3-5 char Aplha uppercase '-' 3-7 numbers
                    if (match.Success)
                    {
                        if (textList.Count < 4)
                        {
                            if (!textList.Contains(match.Value)) textList.Add(match.Groups[2].Value);   // Groups[1].Value is "SQL Error: " or "", Groups[2].Value contains the Error; "ORA-01017" or whatever
                        }
                        else { 
                            if (textList.Count == 4) textList.Add("more Errors ...");
                        }                        
                        if (Array.Exists(stopErrors, element => element == match.Value))
                        {
                            sw.WriteLine(" *** SQLAgain detected Error \"{0}\" and terminates the session. ***", match.Value);
                            EndProcessTree(p.Id);                  
                        }
                    }
                }
            }
           );

            try
            {
                p.Start();
                if (!string.IsNullOrEmpty(processIDFile)) File.WriteAllText(processIDFile, Convert.ToString(p.Id));
                p.BeginOutputReadLine();
                if (timeout > 0)
                {
                    if (!p.WaitForExit(timeout * 1000))
                    {
                        sw.WriteLine("*** SQLAgain detected \"Timeout {0} seconds exceeded\" and terminates the session.***", timeout);
                        EndProcessTree(p.Id);
                    }
                }
                else { p.WaitForExit(); }
                
                if (sqlFormat == "HTML") sw.WriteLine("<pre>");
                localTime = DateTime.Now;
                sw.WriteLine(string.Format("*** {0}   ***   SQL*Plus ended. Exit-Code: {1}", localTime.ToString(formatDate), p.ExitCode));
                sw.WriteLine(Environment.NewLine + Environment.NewLine);
                if (sqlFormat == "HTML") sw.WriteLine("</pre>");

                if (p.ExitCode !=0 ) textList.Add("Exit-Code: " + p.ExitCode);
            }
            catch (Exception ex)    
            {
                sw.WriteLine("SQL*Plus failed with Message: " + ex.Message);
            }
            try
            {
                if (sw != null) sw.Close();
            }
            catch (Exception ex)
            {
                textList.Add("Unable to write to logfile " + logFile + ex.Message);
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime;
            if (ts.Hours < 1)
            {
                if (ts.Minutes < 1) elapsedTime = string.Format("{0:#0}.{1:00}",         ts.Seconds, ts.Milliseconds / 10);
                else                elapsedTime = string.Format("{0:#0}:{1:00}.{2:00}",  ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            }
            else elapsedTime = string.Format("{0:#0}:{1:00}:{2:00}.{3:00}",              ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            if (textList.Count == 0)   textList.Add("OK, processed in " + elapsedTime);
            else                        textList.Add("processed in " + elapsedTime);
            SessionHistory.Record(String.Join(", ", textList.ToArray()), 0, 2) ;
            return String.Join(", ", textList.ToArray());
        }
        public static string AddQuotesIfRequired(string path)
        {
            return !string.IsNullOrWhiteSpace(path) ?
                path.Contains(" ") && (!path.StartsWith("\"") && !path.EndsWith("\"")) ?
                    "\"" + path + "\"" : path :
                    string.Empty;
        }
        public static void EndProcessTree(int pid)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "taskkill",
                Arguments = $"/PID {pid} /f /t",
                CreateNoWindow = true,
                UseShellExecute = false
            }).WaitForExit();
        }
    }
}


