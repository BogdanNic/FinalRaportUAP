using GalaSoft.MvvmLight;
using Library.Helper_Vm;
using System;
using System.Collections.Generic;
using System.Text;
using Library.Web;
using FinalRaport2.Model;
using Library.Model;
namespace FinalRaport2.ViewModel
{
    public class HubVM:ViewModelBase
    {
        public HubVM()
        {
            IsVisibleDud=true;
            Controlls = new List<string>(){"Add","Arhive","Teste","Chart"};
            SelectCommand = new Command<string>(Select);

        }

        private void Select(string command)
        {
           
        }
        private List<string> _controlls;

        public List<string> Controlls
        {
            get { return _controlls; }
            set { _controlls = value; }
        }

        public Command<string> SelectCommand { get; set; }
        public Boolean IsVisibleDud { get; set; }
    }
}
