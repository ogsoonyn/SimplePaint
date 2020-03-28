using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Input;

namespace SimplePaint
{
    class MainViewModel : ViewModelBase
    {
        public StrokeCollection Strokes { get; set; } = new StrokeCollection();

        public Visibility MenuVisibility
        {
            get
            {
                return _menuVis;
            }
            set
            {
                _menuVis = value;
                RaisePropertyChanged(() => MenuVisibility);
            }
        }
        private Visibility _menuVis;

        public ICommand DeleteStrokesCmd
        {
            get
            {
                if (_deleteStrokeCmd == null)
                {
                    _deleteStrokeCmd = new RelayCommand(
                        param =>
                        {
                            Strokes.Clear();
                        });
                }
                return _deleteStrokeCmd;
            }
        }
        private ICommand _deleteStrokeCmd;

        public ICommand ToggleMenuVisibilityCmd
        {
            get
            {
                if(_toggleMenuVisibilityCmd == null)
                {
                    _toggleMenuVisibilityCmd = new RelayCommand(
                        param =>
                        {
                            MenuVisibility = (MenuVisibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
                        });
                }
                return _toggleMenuVisibilityCmd;
            }
        }
        private ICommand _toggleMenuVisibilityCmd;

        public ICommand CloseAppCmd
        {
            get
            {
                if(_closeAppCmd == null)
                {
                    _closeAppCmd = new RelayCommand(
                        param =>
                        {
                            Application.Current.Shutdown();
                        });
                }
                return _closeAppCmd;
            }
        }
        private ICommand _closeAppCmd;
    }
}
