using Library.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI.Xaml.Controls;

namespace FinalRaport2.Model
{
    public class ListGroupStyleSelector : GroupStyleSelector
    {
        protected override GroupStyle SelectGroupStyleCore(object group, uint level)
        {
            return (GroupStyle)App.Current.Resources["listViewGroupStyle"];
        }
    }

    public class FolderProject
    {
        public FolderProject()
        {
            Projects = new ObservableCollection<Project>();
            GroupProj = new ObservableCollection<Group<Activity>>();
        }
      public  ObservableCollection<Project> Projects { get; set; }
      public IEnumerable<Group<Activity>> GroupProj { get; set; }
        public bool IsSourceGrouped = true; 
    }
    public class Project
    {
        public Project()
        {
            Activities = new ObservableCollection<Activity>();
          
        }

        public string Name { get; set; }
        public string Nr { get; set; }
        public ObservableCollection<Activity> Activities { get; private set; }
    }

    public class Activity
    {
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public bool Complete { get; set; }
        public string Project { get; set; }
    }
}
