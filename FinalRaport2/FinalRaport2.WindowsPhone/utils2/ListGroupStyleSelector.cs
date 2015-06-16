using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Controls;

namespace FinalRaport2.utils2
{
    public class ListGroupStyleSelector : GroupStyleSelector
    {
        protected override GroupStyle SelectGroupStyleCore(object group, uint level)
        {
            return (GroupStyle)App.Current.Resources["listViewGroupStyle"];
        }
    }
}
