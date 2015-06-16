using FinalRaport2.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Library.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FinalRaport2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListHeadGroup : Page
    {
         DateTime startDate;
        public ListHeadGroup()
        {
            this.InitializeComponent();
        }

       protected override void OnNavigatedTo(NavigationEventArgs e)
        {
 	        DateTime.TryParse("1/1/2014", out startDate);

            PopulateProjects();
            PopulateActivities();


           // Collection = new ObservableCollection<PredRaport>();
           // Collection.Add(new PredRaport() { Username = "bog", Month = DateTime.Now.AddDays(1), Command = "Add", Books = 4, Hours = 2 });
           // Collection.Add(new PredRaport() { Username = "bog", Month = DateTime.Now.AddDays(2), Command = "Remove", Books = 3, Hours = 4 });
           // Collection.Add(new PredRaport() { Username = "bog", Month = DateTime.Now.AddDays(3), Command = "Spoer", Books = 2, Hours = 3 });
           // Collection.Add(new PredRaport() { Username = "bog", Month = DateTime.Now.AddDays(4), Command = "test", Books = 1, Hours = 5 });
           // var result = from act in Collection group act by act.Username into grp orderby grp.Key select new MyGrouping<string, PredRaport>(grp.Key.ToString(),grp.ToList());



           // IEnumerable<PredRaport> ints = Collection;
           //var barsByInts=ints.ToLookup(foo=>foo.Username);
           //var result2 = from act in Collection group act by act.Username into grp orderby grp.Key select grp;

           // var d22 = result2; 
           
           //var listOfGroups=new List<IGrouping<string,PredRaport>>();
           //listOfGroups.Add(barsByInts.First());
           //listOfGroups.Add(barsByInts.First());
           //cvsActivities.Source = result2;
        }


         public ObservableCollection<PredRaport> Collection { get; set; }
         public string Name { get; set; }

         private void PopulateActivities()
        {
            List<Activity> Activities = new List<Activity>();

            Activities.Add(new Activity() 
                { Name = "Activity 1", Complete = true, 
                    DueDate = startDate.AddDays(4), Project = "Project 1" });
            Activities.Add(new Activity() 
                { Name = "Activity 2", Complete = true, 
                    DueDate = startDate.AddDays(5), Project = "Project 1" });
            Activities.Add(new Activity() 
                { Name = "Activity 3", Complete = false, 
                    DueDate = startDate.AddDays(7), Project = "Project 1" });
            Activities.Add(new Activity() 
                { Name = "Activity 4", Complete = false, 
                    DueDate = startDate.AddDays(9), Project = "Project 1" });
            Activities.Add(new Activity() 
                { Name = "Activity 5", Complete = false, 
                    DueDate = startDate.AddDays(14), Project = "Project 1" });
            Activities.Add(new Activity() 
                { Name = "Activity A", Complete = true, 
                    DueDate = startDate.AddDays(2), Project = "Project 2" });
            Activities.Add(new Activity() 
                { Name = "Activity B", Complete = false, 
                    DueDate = startDate.AddDays(4), Project = "Project 2" });
            Activities.Add(new Activity() 
                { Name = "Activity C", Complete = true, 
                    DueDate = startDate.AddDays(5), Project = "Project 2" });
            Activities.Add(new Activity() 
                { Name = "Activity D", Complete = false, 
                    DueDate = startDate.AddDays(9), Project = "Project 2" });
            Activities.Add(new Activity() 
                { Name = "Activity E", Complete = false, 
                    DueDate = startDate.AddDays(18), Project = "Project 2" });

            

            var result = from act in Activities group act by act.Project into grp orderby grp.Key select grp;
            cvsActivities.Source = result;
        }

        private void PopulateProjects()
        {
            List<Project> Projects = new List<Project>();

            Project newProject = new Project();
            newProject.Name = "Project 1";
            newProject.Activities.Add(new Activity() 
                { Name = "Activity 1", Complete = true, DueDate = startDate.AddDays(4) });
            newProject.Activities.Add(new Activity() 
                { Name = "Activity 2", Complete = true, DueDate = startDate.AddDays(5) });
            newProject.Activities.Add(new Activity() 
                { Name = "Activity 3", Complete = false, DueDate = startDate.AddDays(7) });
            newProject.Activities.Add(new Activity() 
                { Name = "Activity 4", Complete = false, DueDate = startDate.AddDays(9) });
            newProject.Activities.Add(new Activity() 
                { Name = "Activity 5", Complete = false, DueDate = startDate.AddDays(14) });
            Projects.Add(newProject);

            newProject = new Project();
            newProject.Name = "Project 2";
            newProject.Activities.Add(new Activity() 
                { Name = "Activity A", Complete = true, DueDate = startDate.AddDays(2) });
            newProject.Activities.Add(new Activity() 
                { Name = "Activity B", Complete = false, DueDate = startDate.AddDays(3) });
            newProject.Activities.Add(new Activity() 
                { Name = "Activity C", Complete = true, DueDate = startDate.AddDays(5) });
            newProject.Activities.Add(new Activity() 
                { Name = "Activity D", Complete = false, DueDate = startDate.AddDays(9) });
            newProject.Activities.Add(new Activity() 
                { Name = "Activity E", Complete = false, DueDate = startDate.AddDays(18) });
            Projects.Add(newProject);

            newProject = new Project();
            newProject.Name = "Project 3";
            Projects.Add(newProject);

            cvsProjects.Source = Projects;
        }

    }
    
}
