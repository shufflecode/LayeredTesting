using System.ComponentModel;
using System.Runtime.CompilerServices;
using SerializerTesting.Model;
using SerializerTesting.Wpf.Base;

namespace SerializerTesting.Wpf.ViewModels
{
    public class AxisViewModel : BaseViewModel
    {
        private IAxis _axis;

        public AxisViewModel(IAxis axis )
        {
            _axis = axis;
        }


        public string Name
        {
            get { return _axis.Name; }
            set
            {
                _axis.Name = value;
                OnPropertyChanged();
            }
        }
    }
}
