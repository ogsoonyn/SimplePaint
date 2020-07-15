using System.Windows;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;

namespace SimplePaint
{
    class MainViewModel : ViewModelBase
    {
        #region Properties
        public StrokeCollection Strokes { get; set; } = new StrokeCollection();

        public Visibility MenuVisibility
        {
            get { return _menuVis; }
            set
            {
                _menuVis = value;
                RaisePropertyChanged(() => MenuVisibility);
            }
        }
        private Visibility _menuVis;

        public DrawingAttributes MyDrawingAttributes
        {
            get
            {
                return _drawingAttributes;
            }
            set
            {
                _drawingAttributes = value;
                RaisePropertyChanged(() => MyDrawingAttributes);
            }
        }
        private DrawingAttributes _drawingAttributes = new DrawingAttributes()
        {
            Color = Colors.Blue,
            FitToCurve = false,
            Width = 2,
            Height = 2
        };

        #endregion // Properties


        #region Commands
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

        public ICommand ToggleHighlighterCmd
        {
            get
            {
                if(_toggleHighlighterCmd == null)
                {
                    _toggleHighlighterCmd = new RelayCommand(
                        param =>
                        {
                            MyDrawingAttributes.IsHighlighter = !MyDrawingAttributes.IsHighlighter;
                            if (MyDrawingAttributes.IsHighlighter)
                            {
                                MyDrawingAttributes.Color = Colors.Yellow;
                                MyDrawingAttributes.Width = 15;
                                MyDrawingAttributes.Height = 15;
                            }
                            else
                            {
                                MyDrawingAttributes.Color = Colors.Blue;
                                MyDrawingAttributes.Width = 2;
                                MyDrawingAttributes.Height = 2;
                            }
                        });
                }
                return _toggleHighlighterCmd;
            }
        }
        private ICommand _toggleHighlighterCmd;

        #endregion // Commands
    }
}
