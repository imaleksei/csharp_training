using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovingTests : TestBase
    {
        [Test]
        public void ProjectRemovingTest()
        {
            List<ProjectData> projects = new List<ProjectData>();
            projects = app.Project.GetProjects();
            if (projects.Count == 0)
            {
                ProjectData newProject = new ProjectData("test-тест" + TestBase.GenerateRandomString(5));
                app.Navigator.GoToControlPanel();
                app.Navigator.GoToProjectControlPanel();
                app.Project.Create(newProject);
                projects = app.Project.GetProjects();
            }
            app.Navigator.GoToControlPanel();
            app.Navigator.GoToProjectControlPanel();
            app.Project.Remove();
            List<ProjectData> newProjects = app.Project.GetProjects();
            Assert.AreEqual(projects.Count() - 1, newProjects.Count());
        }
    }
}