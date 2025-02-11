﻿using RoomPals.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RoomPals
{
    /// <summary>
    /// Interaction logic for ViewMatchesWindow.xaml
    /// </summary>
    public partial class ViewMatchesWindow : Window
    {
        private Student _loggedInStudent;
        private List<(Student, int)> _matches;
        private List<Student> _acceptedMatches = new List<Student>();
        private List<Student> _allStudents;
        private int _currentMatchIndex;
       
        public ViewMatchesWindow(Student loggedInStudent, List<Student> allStudents, int currentMatchIndex)
        {
            InitializeComponent();
            _loggedInStudent = loggedInStudent;
            _allStudents = StudentPersistence.LoadStudents(); //load students from json file
            _matches = Matchmaking.FindMatches(loggedInStudent, allStudents); // Get matches based on the user's preferences
            _currentMatchIndex = currentMatchIndex;

            DisplayMatch();
        }

        public ViewMatchesWindow(Student loggedInStudent, List<Student> allStudents, List<Student> acceptedMatches, int currentMatchIndex)
        {
            InitializeComponent();
            _loggedInStudent = loggedInStudent;
            _allStudents = StudentPersistence.LoadStudents();
            _matches = Matchmaking.FindMatches(loggedInStudent, allStudents); // Get matches based on the user's preferences
            _currentMatchIndex = currentMatchIndex;

            DisplayMatch();
            _acceptedMatches = acceptedMatches;
        }

        private void DisplayMatch()
        {
            if (_matches != null && _matches.Count > 0 && _currentMatchIndex < _matches.Count)
            {
                var currentMatch = _matches[_currentMatchIndex];
                var topMatch = currentMatch.Item1; // The matched Student
                var compatibilityScore = currentMatch.Item2; // The score

                // Display top match information
                NameTextBlock.Text = topMatch.Name;
                LastNameTextBlock.Text = topMatch.Surname;
                AgeTextBlock.Text = topMatch.Age.ToString();
                MajorTextBlock.Text = topMatch.Major;
                CityTextBlock.Text = topMatch.city;
                ScoreTextBlock.Text = compatibilityScore.ToString();
            }
            else
            {
                MessageBox.Show("No more matches available, return to the MainPage to refresh your Matches.");
            }
        }


        private void SkipButton_Click(object sender, RoutedEventArgs e)
        {
            // Skip to the next match
            if (_currentMatchIndex < _matches.Count - 1)
            {
                _currentMatchIndex++;
                DisplayMatch(); // Show the next match details
            }
            else
            {
                MessageBox.Show("No more matches available, return to the MainPage to refresh your Matches.");
                return;
            }
        }

        private void go_back_Click(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow = new StartWindow(_loggedInStudent);
            startWindow.Show();
            this.Close();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            var currentMatch = _matches[_currentMatchIndex].Item1; //accepted match (student)
            _acceptedMatches.Add(currentMatch); 
            
            MatchWindow matchWindow = new MatchWindow(_loggedInStudent, _allStudents, _acceptedMatches, _currentMatchIndex);
            matchWindow.Show();
            this.Close();
        }
        
        
    }  
}
