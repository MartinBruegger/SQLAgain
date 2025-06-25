using System;
using System.IO;

namespace SQLAgain
{
    class SessionHistory
    {
        public static string traceFile = Environment.GetEnvironmentVariable("AllUsersProfile") + "\\SQLAgain\\Sessions.log";
        public static void Record(string message, int lineFeed = 1, int lineAppend = 0)
        {
            try
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(traceFile, true))
                {
                    DateTime localDate = DateTime.Now;
                    switch (lineAppend)
                    {
                        case 1:     // Print Prefix including Timestamp
                            sw.Write(localDate.ToString("yyyy'/'MM'/'dd HH:mm:ss") + "  " + message);
                            break;
                        case 2:     // Print 2nd part (SQL Result) followed by a new-line
                            sw.Write(" " + message);
                            sw.WriteLine();
                            break;
                        case 3:     // Print empty line 
                            sw.WriteLine();
                            break;
                        default:
                            while (lineFeed > 1)
                            {
                                sw.WriteLine("  ");
                                lineFeed--;
                            }
                            sw.WriteLine(localDate.ToString("yyyy'/'MM'/'dd HH:mm:ss") + "  " + message);
                            break;
                    }
                }
            }
            catch (Exception)
            {
                // ignore any error and continue
            }

        }
        public static void Reorg()
        {
            {
                // delete SessionHistory Trace Records older than 365 days. Date is always in ordered format; suitable for sort and compare.
                bool obsoleteDateFound = true;
                string oldestDate = DateTime.Now.AddYears(-1).ToString("yyyy'/'MM'/'dd HH:mm:ss");
                string traceRecord;
                string traceRecords = "";
                int linesDeleted = 0;
                string firstDate = string.Empty;
                try
                {
                    if (File.Exists(traceFile))
                    {
                        StreamReader sr = File.OpenText(traceFile);
                        while ((traceRecord = sr.ReadLine()) != null)
                        {
                            if (obsoleteDateFound)
                            {
                                linesDeleted++;
                                if (traceRecord.Length > 18)
                                {
                                    if (firstDate == string.Empty)  firstDate = traceRecord.Substring(0, 19);
                                    if (String.Compare(oldestDate, traceRecord.Substring(0, 19)) < 0)
                                    {
                                        obsoleteDateFound = false;
                                        linesDeleted--;
                                        traceRecords += traceRecord + Environment.NewLine;
                                    }
                                }
                            }
                            else  traceRecords += traceRecord + Environment.NewLine; 
                        }
                        sr.Close();
                        if (linesDeleted > 0)
                        {
                            File.WriteAllText(traceFile, traceRecords);
                            SessionHistory.Record("SessionHistory.Reorg - First Date found: \"" + firstDate + "\", # Lines deleted: " + linesDeleted,2);
                        }                        
                    }
                    else
                    {
                        System.IO.Directory.CreateDirectory(Path.GetDirectoryName(traceFile));
                        SessionHistory.Record("File created.");
                    }
                }
                catch (Exception)
                {
                    // ignore any error and continue
                }
            }
        }
    }
}
