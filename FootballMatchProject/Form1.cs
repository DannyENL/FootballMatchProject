using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public class team //Team class
        {
            public string name; //Name of team
            public Label label; //Label used to display name on the left
            public int number; //Associated ball number
        }

        private List<team> setup_team_list() //This function creates the list of team objects and their on-screen labels
        {
            List<string> team_names = new List<string>(); //Team names list (change this to be file based eventually)
            team_names.Add("Watson"); //Just random names for now
            team_names.Add("Kiryu");

            List<team> teams_list = new List<team>(); //Create a new list for the list of teams 
            int team_number = 1; //Associated ball number
            int y_position = 38; //initial y position for first team label
            foreach (string team_name in team_names) //Loop through for each team name in the list
            {
                team new_team = new team(); //Create a new team object
                new_team.name = team_name; //Set the object's name
                new_team.number = team_number; //Set the object's associated ball number
                Label teamlabel = new Label(); //Create a new label for the team
                teamlabel.Location = new Point(13, y_position); //Set the location
                teamlabel.Text = $"{team_number}. {team_name}"; //Set the text to show the team number and the team name
                this.Controls.Add(teamlabel); //Display on screen
                new_team.label = teamlabel; //Assign this label to the team object
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
        }
    }
}
