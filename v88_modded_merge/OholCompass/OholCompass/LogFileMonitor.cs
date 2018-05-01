using System;
using System.IO;
using System.Timers;

namespace OholCompass
{

    public class LogFileMonitorLineEventArgs : EventArgs
    {
        public string Line { get; set; }
    }

    public class LogFileMonitorLinesEventArgs : EventArgs
    {
        public string[] Lines { get; set; }
    }

    public class LogFileMonitor
    {
        public EventHandler<LogFileMonitorLineEventArgs> OnLine;

        // file path + delimiter internals
        string _path = String.Empty;
        string _delimiter = String.Empty;

        // timer object
        Timer _t = null;

        // buffer for storing data at the end of the file that does not yet have a delimiter
        string _buffer = String.Empty;

        // get the current size
        long _currentSize = 0;

        // are we currently checking the log (stops the timer going in more than once)
        bool _isCheckingLog = false;

        protected bool StartCheckingLog()
        {
            lock (_t)
            {
                if (_isCheckingLog)
                    return true;

                _isCheckingLog = true;
                return false;
            }
        }

        protected void DoneCheckingLog()
        {
            lock (_t)
                _isCheckingLog = false;
        }

        public LogFileMonitor(string path, string delimiter = "\n")
        {
            _path = path;
            _delimiter = delimiter;
        }

        public void Start()
        {
            // get the current size
            try
            {
                _currentSize = new FileInfo(_path).Length;
            }
            catch
            {
                _currentSize = 0;
            }

            // start the timer
            _t = new Timer();
            _t.Elapsed += CheckLog;
            _t.AutoReset = true;
            _t.Start();
        }

        private void CheckLog(object s, ElapsedEventArgs e)
        {
            if (StartCheckingLog())
            {
                try
                {
                    long newSize;

                    // get the new size
                    var f = new FileInfo(_path);
                    if (f.Exists)
                    {
                        newSize = f.Length;
                    }
                    else { return; }
                    
                    // if they are the same then continue.. if the current size is bigger than the new size continue
                    if (_currentSize >= newSize)
                        return;

                    // read the contents of the file
                    using (var stream = File.Open(_path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        // seek to the current file position
                        sr.BaseStream.Seek(_currentSize, SeekOrigin.Begin);

                        // read from current position to the end of the file
                        var newData = _buffer + sr.ReadToEnd();

                        // if we don't end with a delimiter we need to store some data in the buffer for next time
                        if (!newData.EndsWith(_delimiter))
                        {
                            // we don't have any lines to process so save in the buffer for next time
                            if (newData.IndexOf(_delimiter) == -1)
                            {
                                _buffer += newData;
                                newData = String.Empty;
                            }
                            else
                            {
                                // we have at least one line so store the last section (without lines) in the buffer
                                var pos = newData.LastIndexOf(_delimiter) + _delimiter.Length;
                                _buffer = newData.Substring(pos);
                                newData = newData.Substring(0, pos);
                            }
                        }

                        // split the data into lines
                        var lines = newData.Split(new string[] { _delimiter }, StringSplitOptions.RemoveEmptyEntries);

                        //send back to caller, NOTE: this is done from a different thread!
                        foreach (var l in lines)
                        {
                            OnLine?.Invoke(this, new LogFileMonitorLineEventArgs { Line = l });
                        }
                    }

                    // set the new current position
                    _currentSize = newSize;
                }
                catch (Exception)
                {
                }

                // we done..
                DoneCheckingLog();
            }
        }

        public void Stop()
        {
            if (_t == null)
                return;

            _t.Stop();
        }
    }
}
