using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SerializerTesting.Data.Repositories;
using SerializerTesting.Model;
using SerializerTesting.Model.FooData;
using SerializerTesting.Wpf.Base;

namespace SerializerTesting.Application
{
    class ApplicationViewmodel : BaseViewModel
    {
        private XmlRepository _repo;
        private TypeFile _type;
        private List<string> _messages;


        public List<string> Messages
        {
            get { return _messages; }
            set
            {
                _messages = value;
                OnPropertyChanged();
            }
        }

        public ICommand UiCommand { get; set; }
        public ApplicationViewmodel()
        {
            _repo = new XmlRepository();
            _type = new TypeFile();
            _type.Axis = new List<IAxis>() {new Axis() {Name = "A 1"}, new Axis() {Name = "A 2"} };
            Messages = new List<string>();
            UiCommand = new RelayCommand(UiCommandFired);
        }

        private void UiCommandFired(object obj)
        {
            switch (obj as string)
            {
                case @"1":
                    _type.ConfigName = @"D:\demofile.type";
                    _repo.Create(_type);
                    Messages.Add($"geschrieben: {_type.ConfigName}");
                    break;
                case @"2":

                    var file = _repo.Read(@"D:\demofile.type");
                    Messages.Add($"gelesen: {_type.ConfigName}");
                    break;

            }
        }
    }
}
