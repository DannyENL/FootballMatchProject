using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballMatchProject
{
    public partial class window : Form
    {
        public class match //Match class
        {
            public team team1;
            public team team2;
            public Label label;
        }

        public class team //Team class
        {
            public string name; //Name of team
            public Label label; //Label used to display name on the left
            public int number; //Associated ball number
        }
        private match generate_match(List<team> teams, int index1, int index2) //Match generator
        {
            match new_match = new match(); //Generate the new match object
            new_match.team1 = teams[index1]; //Set the first team number
            new_match.team2 = teams[index2]; //Set the second team number
            Label match_label = new Label(); //Create a new label for the match
            match_label.Location = new Point(256, 50); //Set the location
            match_label.Text = $"{new_match.team1.name} VS {new_match.team2.name}"; //Set the text to show the two teams
            this.Controls.Add(match_label); //Display on screen
            new_match.label = match_label; //Assign this label to the team object
            return (new_match);
        }
        private List<team> setup_team_list() //This function creates the list of team objects and their on-screen labels
        {
            var team_file = File.ReadAllLines("teams.txt"); //Reads the contents of teams.txt and splits based on line
            List<string> team_names = new List<string>(team_file); //Create a list of the team names extracted from the file

            List<team> teams_list = new List<team>(); //Create a new list for the list of teams 
            int team_number = 1; //Associated ball number
            int y_position = 38; //initial y position for first team label
            foreach (string team_name in team_names) //Loop through for each team name in the list
            {
                team new_team = new team(); //Create a new team object
                new_team.name = team_name; //Set the object's name
                new_team.number = team_number; //Set the object's associated ball number
                Label team_label = new Label(); //Create a new label for the team
                team_label.Location = new Point(13, y_position); //Set the location
                team_label.Text = $"{team_number}. {team_name}"; //Set the text to show the team number and the team name
                this.Controls.Add(team_label); //Display on screen
                new_team.label = team_label; //Assign this label to the team object
                teams_list.Add(new_team); //Add this object to the list of teams
                team_number += 1; //Increase the ball number to be used for the next one
                y_position += 25; //Increase y position for the next team
            }
            return (teams_list); //Return the final list of teams
        }

        public window()
        {
            InitializeComponent();

            List<team> available_teams = setup_team_list(); //Initialise the list of team objects
            List<match> matches = new List<match>(); //Initialise the list of team objects
            match new_match = generate_match(available_teams, 1, 2); //Generates a new match using index 1 and index 2
        }
    }
}
