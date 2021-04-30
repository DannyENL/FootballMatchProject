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
            public team team1; //First team object in the match (home team)
            public team team2; //Away team
            public Label label; //On-screen label
        }
        public class team //Team class
        {
            public bool selected = false;
            public string name; //Name of team
            public Label label; //Label used to display name on the left
            public int number; //Associated ball number
        }

        private match generate_match(List<team> teams, int index1, int index2) //Match generator
        {
            match new_match = new match(); //Generate the new match object
            new_match.team1 = teams[index1]; //Assign the first team
            new_match.team2 = teams[index2]; //Assign the second team
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
            team_data.available_teams = setup_team_list(); //Initialise the list of team objects
            team_data.matches = new List<match>(); //Initialise the list of match objects
            match new_match = generate_match(team_data.available_teams, 1, 2); //Generates a new match using index 1 and index 2
        }

        private void button_ball_Click(object sender, EventArgs e) //Triggered when the "Draw Next Ball" button is pressed
        {
            Random rnd = new Random(); //Generate random seed
            int ball_index = rnd.Next(team_data.available_teams.Count); //Select random index
            while (team_data.available_teams[ball_index].selected==true) //If you choose a team that's already been used
            {
                ball_index = rnd.Next(team_data.available_teams.Count); //Select a different random index
            }
            label_chosen.Text = Convert.ToString(ball_index+1); //Display chosen ball number
            team_data.available_teams[ball_index].label.ForeColor = System.Drawing.Color.Red; //Set the chosen team to be red
            team_data.available_teams[ball_index].selected = true; //Mark this team as selected so it won't be picked again
        }

        static class team_data //All team data is stored in this class so it can be accessed from different functions
        {
            public static List<team> available_teams; //List of teams 
            public static List<match> matches; //List of matches
        }

    }
}
