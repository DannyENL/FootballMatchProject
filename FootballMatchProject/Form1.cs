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
            match_label.Width = 210;
            match_label.Location = new Point(433, 38+(25*team_data.matches.Count)); //Set the location
            match_label.Text = $"{new_match.team1.name} v. {new_match.team2.name}"; //Set the text to show the two teams
            this.Controls.Add(match_label); //Display on screen
            new_match.label = match_label; //Assign this label to the team object
            return (new_match);
        }

        private List<team> setup_team_list() //This function creates the list of team objects and their on-screen labels
        {
            //Read team file
            var team_file = File.ReadAllLines("teams.txt"); //Reads the contents of teams.txt and splits based on line
            List<string> team_names = new List<string>(team_file); //Create a list of the team names extracted from the file
                
            //Data validation
            while ((team_names.Count < 2) || (team_names.Count > 32)) //While you have an invalid number of teams
            {
                DialogResult user_choice = MessageBox.Show("Your teams.txt data is invalid. Write your team names separated by linebreaks. You can have any number of teams greater than 1 and less than 33.", "Error", //Show error box
                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error); //"Retry" and "Cancel" buttons are available
                if (user_choice == DialogResult.Cancel) //If you click "Cancel"
                {
                    System.Environment.Exit(1); //Exit program
                }
                else //If you click "Retry"
                {
                    team_file = File.ReadAllLines("teams.txt"); //Re-read the "teams.txt" file to see if the data updated
                    team_names = new List<string>(team_file); //Create a new list of the team names extracted from the file
                }
            }

            //Create list and fill with team objects
            List<team> teams_list = new List<team>(); //Create a new list for the list of teams 
            int team_number = 1; //Associated ball number
            int y_position = 38; //initial y position for first team label
            int x_position = 13;
            foreach (string team_name in team_names) //Loop through for each team name in the list
            {
                team new_team = new team(); //Create a new team object
                new_team.name = team_name; //Set the object's name
                new_team.number = team_number; //Set the object's associated ball number
                Label team_label = new Label(); //Create a new label for the team
                team_label.Width = 210;
                team_label.Location = new Point(x_position, y_position); //Set the location
                team_label.Text = $"{team_number}. {team_name}"; //Set the text to show the team number and the team name
                this.Controls.Add(team_label); //Display on screen
                new_team.label = team_label; //Assign this label to the team object
                teams_list.Add(new_team); //Add this object to the list of teams
                team_number += 1; //Increase the ball number to be used for the next one
                y_position += 25; //Increase y position for the next team
                if (y_position>420) {
                    y_position = 38;
                    x_position += 210;
                }
            }

            //Output
            return (teams_list); //Return the final list of teams
        }

        public window()
        {
            //Startup
            InitializeComponent();
            team_data.available_teams = setup_team_list(); //Initialise the list of team objects
            team_data.matches = new List<match>(); //Initialise the list of match objects
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
            team_data.available_teams[ball_index].selected = true; //Mark this team as selected so it won't be picked again
            if (team_data.choosing_team == false) { //If this is the first team of the match
                team_data.available_teams[ball_index].label.ForeColor = System.Drawing.Color.Red; //Set the chosen team to be red
                team_data.choosing_team = true; //Set to true so that we know the first team of a match is selected and we only need one more
                team_data.chosen_team_index = ball_index; //Set the current chosen index
            }
            else //If we've already chosen the first team of the match
            {
                match new_match = generate_match(team_data.available_teams, team_data.chosen_team_index, ball_index); //Generate match using the selected team indexes
                team_data.matches.Add(new_match); //Add the new match to the list of matches
                team_data.available_teams[ball_index].label.ForeColor = Color.FromArgb(128, 128, 128); //Set the used teams to grey
                team_data.available_teams[team_data.chosen_team_index].label.ForeColor = Color.FromArgb(128, 128, 128); //Set the used teams to grey
                team_data.choosing_team = false; //No longer choosing a team
            }

            if ((team_data.matches.Count >= team_data.available_teams.Count*0.5) || (team_data.matches.Count >= team_data.available_teams.Count * 0.5 - 1 && team_data.available_teams.Count % 2 != 0)) //If we've run out of possible matches
            {
                button_ball.Enabled = false; //Disable the "Draw Next Ball" button (no more balls to draw)
                button_skip.Enabled = false; //Disable the "Skip To End" button (we're at the end)
                string csv_text = "Home,Away"; //Create the column headers for the CSV file
                foreach (match match in team_data.matches) //For each match generated
                {
                    csv_text += $"\n{match.team1.name},{match.team2.name}"; //Add the match data to the bottom of the csv
                }
                File.WriteAllText("matches.csv", csv_text); //Write the csv data to matches.csv
            }
        }

        static class team_data //All team data is stored in this class so it can be accessed from different functions
        {
            public static List<team> available_teams; //List of teams 
            public static List<match> matches; //List of matches
            public static int chosen_team_index; //Currently highlighted team
            public static bool choosing_team = false; //After selecting the first team in a match, this variable is set to true
        }

        private void button_reset_Click(object sender, EventArgs e) //Reset button
        {
            foreach (team team_obj in team_data.available_teams) //For each team in the team list
            {
                team_obj.label.Dispose(); //Remove the label from the screen
            }
            foreach (match match_obj in team_data.matches) //For each match in the match list
            {
                match_obj.label.Dispose(); //Remove the label from the screen
            }
            team_data.available_teams = setup_team_list(); //Initialise the list of team objects
            team_data.matches = new List<match>(); //Initialise the list of match objects
            button_ball.Enabled = true; //Re-enable the "Draw Next Ball" button
            button_skip.Enabled = true; //Re-enable the "Skip To End" button
            label_chosen.Text = "None"; //Reset the chosen ball number text
        }

        private void button_skip_Click(object sender, EventArgs e)
        {
            while (button_ball.Enabled == true) //As long as we can click the Draw Next Ball button,
            {
                button_ball_Click(null, null); //keep clicking it.
            }
        }
    }
}
