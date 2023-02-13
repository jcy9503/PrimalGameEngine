﻿using System.Windows;
using System.Windows.Controls;

namespace PrimalEditor.GameProject;

public partial class NewProjectView : UserControl
{
    public NewProjectView()
    {
        InitializeComponent();
    }

    private void OnCreate_Button_Click(object sender, RoutedEventArgs e)
    {
        var vm = DataContext as NewProject;
        var projectPath = vm.CreateProject(templateListBox.SelectedItem as ProjectTemplate);
        var dialogResult = false;
        var win = Window.GetWindow(this);
        if (!string.IsNullOrEmpty(projectPath))
        {
            dialogResult = true;
            var project = OpenProject.Open(new ProjectData() { ProjectName = vm.ProjectName, ProjectPath = projectPath });
            win.DataContext = project;
        }

        win.DialogResult = dialogResult;
        win.Close();
    }
}