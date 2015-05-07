using System.Windows.Input;
using Client.ShapeServiceReference;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace Client
{
    public class MainWindowViewModel : BindableBase
    {
        private int _shapeType;
        private ICommand _createShapeCommand;
        private string _createdShapeName;

        public int ShapeType
        {
            get { return _shapeType; }
            set { SetProperty(ref _shapeType, value); }
        }

        public string CreatedShapeName
        {
            get { return _createdShapeName; }
            set { SetProperty(ref _createdShapeName, value); }
        }

        public ICommand CreateShapeCommand
        {
            get { return _createShapeCommand ?? (_createShapeCommand = new DelegateCommand(CreateShape)); }
        }

        private async void CreateShape()
        {
            var serviceClient = new ShapeServiceClient();

            var shape = await serviceClient.CreateShapeAsync(ShapeType);

            CreatedShapeName = shape.GetType().Name;
        }

        
    }
}
