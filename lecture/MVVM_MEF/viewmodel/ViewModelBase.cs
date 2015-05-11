using System;

namespace ViewModel
{
    public abstract class ViewModelBase
    {
        public event EventHandler Closed;

        public bool IsClosed { get; private set; }

        public void Close()
        {
            if(!IsClosed && OnClosing())
            {
                IsClosed = true;
                OnClosed();
            }
        }

        protected virtual bool OnClosing()
        {
            return true;
        }

        private void OnClosed()
        {
            EventHandler handler = Closed;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
