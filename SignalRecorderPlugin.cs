using SDRSharp.Common;
using SDRSharp.Radio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SDRSharp.Plugin.SignalRecorder
{
    public class SignalRecorderPlugin : ISharpPlugin, ICanLazyLoadGui
    {
        private const string _displayName = "Signal recorder";
        private ISharpControl _control;
        private ProcessorPanel _configGui;
        private SignalRecorderProcessor _processor;

        public UserControl Gui
        {
            get
            {
                LoadGui();
                return _configGui;
            }
        }

        public string DisplayName
        {
            get { return _displayName; }
        }

        public void Close()
        {
            _processor.Enabled = false;
        }

        public void Initialize(ISharpControl control)
        {
            _control = control;

            _processor = new SignalRecorderProcessor();
            _processor.Enabled = false;

            _control.RegisterStreamHook(_processor, ProcessorType.DecimatedAndFilteredIQ);
        }

        public void LoadGui()
        {
            if (_configGui == null)
            {
                _configGui = new ProcessorPanel(_processor);
                _processor.Enabled = true;
            }
        }
    }
}
