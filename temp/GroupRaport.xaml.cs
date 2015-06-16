using FinalRaport2.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FinalRaport2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GroupRaport : Page
    {
        public ObservableCollection<PredRaport> Collection { get; set; } 
        public GroupRaport()
        {
            this.InitializeComponent();


            Collection = new ObservableCollection<PredRaport>();
            Collection.Add(new PredRaport() { Username = "bog", Month = DateTime.Now.AddDays(1), Command = "Add", Books = 4, Hours = 2 });
            Collection.Add(new PredRaport() { Username = "bog", Month = DateTime.Now.AddDays(2), Command = "Remove", Books = 3, Hours = 4 });
            Collection.Add(new PredRaport() { Username = "bog", Month = DateTime.Now.AddDays(3), Command = "Spoer", Books = 2, Hours = 3 });
            Collection.Add(new PredRaport() { Username = "bog", Month = DateTime.Now.AddDays(4), Command = "test", Books = 1, Hours = 5 });
            Collection.Add(new PredRaport() { Username = "bog", Month = DateTime.Now.AddDays(2), Command = "test", Books = 1, Hours = 5 });
            Collection.Add(new PredRaport() { Username = "bog", Month = DateTime.Now.AddDays(2), Command = "test", Books = 1, Hours = 5 });
            var r = from report in Collection group report by report.Month.ToString("MMMM") into g orderby g.Key ascending select new Library.Model.Group<PredRaport>(g.Key.ToString(), (IEnumerable<PredRaport>)g.ToList(), 2, 10);


            cvsActivities.Source = r;
        

        }
    }
}
