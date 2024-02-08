using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Dynamic;
using System.Xml.Linq;
using System.Data.Common;

namespace Progress_Tracker {
    //"Data Source=YourServer;Initial Catalog=YourDatabase;Integrated Security=True;"
    //Server=localhost\SQLEXPRESS;Database=ExerTrace;Trusted_Connection=True;
    public partial class Form1 : Form {
        public SqlConnection sqlConnection = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=ExerTrace;Trusted_Connection=True;");
        int userId;
        public Form1() {
            sqlConnection.Open();
            InitializeComponent();
            updatePage();
            panel1.BackColor = Color.DarkGray;
        }
        int spaceBetweenExercises = 150;
        private void addSet_Click(object sender, EventArgs e) {
            if (sender is Button clickedButton) {
                string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                int exerciseOrder = int.Parse(clickedButton.Name[9].ToString());
                int setIndex = int.Parse(setInd(dateTimePicker1.Value.ToString("yyyy-MM-dd"), exerciseOrder));
                Insert(setIndex + 1, date, exerciseOrder, "0", "0");
                Panel group = Controls.Find("setPanel" + exerciseOrder, true).FirstOrDefault() as Panel;
                int scroll = group.AutoScrollPosition.X;
                group.Controls.Add(AddWeightTxt(setIndex + 1, scroll));
                group.Controls.Add(AddRepTxt(setIndex + 1, scroll));
                clickedButton.Location = new System.Drawing.Point((setIndex + 1) * 140 + scroll + 20, 10);
                foreach (Control control in group.Controls) {
                    // Check if the control's name is not "addExercise"
                    if (control.Name == "removeSetBtn" + exerciseOrder) {
                        // Add the control to the list of controls to be removed
                        control.Location = new System.Drawing.Point((setIndex + 1) * 140 + scroll + 60, 10);
                    }
                }
                calculateSetsAndVolume();
            }
        }
        private void removeSet_Click(object sender, EventArgs e) {
            if (sender is Button clickedButton) {
                string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                int exerciseOrder = int.Parse(clickedButton.Name[12].ToString());
                int setIndex = int.Parse(setInd(dateTimePicker1.Value.ToString("yyyy-MM-dd"), exerciseOrder));
                RemoveSet(setIndex, date, exerciseOrder);
                Panel group = Controls.Find("setPanel" + exerciseOrder, true).FirstOrDefault() as Panel;
                int scroll = group.AutoScrollPosition.X;
                List<Control> toDelete = new List<Control>();
                foreach (Control control in group.Controls) {
                    // Check if the control's name is not "addExercise"
                    if (control.Name == "addSetBtn" + exerciseOrder) {
                        // Add the control to the list of controls to be removed
                        control.Location = new System.Drawing.Point((setIndex - 1) * 140 + scroll + 20, 10);
                    }
                    if(control.Name == "repTxt" + setIndex || control.Name == "weightTxt" + setIndex) {
                        toDelete.Add(control);
                    }
                }
                foreach (Control controlToRemove in toDelete) {
                    panel1.Controls.Remove(controlToRemove);
                    controlToRemove.Dispose(); // Dispose to release resources (optional)
                }
                clickedButton.Location = new System.Drawing.Point((setIndex - 1) * 140 + scroll + 60, 10);
                calculateSetsAndVolume();
            }
        }
        private void addExercise_Click(object sender, EventArgs e) {
            if (sender is Button clickedButton) {
                Panel panel = clickedButton.Parent as Panel;
                int scroll = panel.AutoScrollPosition.Y;
                string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                int exerciseOrder = exerciseCount(date);
                Insert(1, date, exerciseOrder + 1, "0", "0");
                CreateExercise(exerciseOrder + 1, 0, spaceBetweenExercises * exerciseOrder + scroll, true);
                addExercise.Location = new Point(panel.Size.Width/2 - 100, 10 + (exerciseOrder + 1) * spaceBetweenExercises + scroll);
            }
        }
        private int exerciseCount(string date) {
            SqlCommand setInd = new SqlCommand("SELECT TOP 1 ExerciseOrder FROM Sets WHERE WorkoutDate = '" + date + "'  AND UserId = " + userId + "ORDER BY ExerciseOrder DESC;", sqlConnection);
            SqlDataReader dr = setInd.ExecuteReader();
            dr.Read();
            try {
                int count = int.Parse(dr["ExerciseOrder"].ToString());
                dr.Close();
                return count;
            }
            catch {
                dr.Close();
                return 0;
            }
        }
        private string setInd(string date, int exerciseOrder) {
            SqlCommand setInd = new SqlCommand("SELECT TOP 1 SetInd FROM Sets WHERE WorkoutDate = '" + date + "' AND ExerciseOrder = "+ exerciseOrder + "AND UserId = " + userId + " ORDER BY SetInd DESC;", sqlConnection);
            SqlDataReader dr = setInd.ExecuteReader();
            dr.Read();
            try {
                string name = dr["SetInd"].ToString();
                dr.Close();
                return name;
            }
            catch {
                dr.Close();
                return "0";
            }
        }
        private string NameOfExercise(string date, int exerciseOrder) {
            SqlCommand setName = new SqlCommand("SELECT TOP 1 ExerciseName FROM Sets WHERE WorkoutDate = '"+ date  + "' AND ExerciseOrder = " + exerciseOrder + "AND UserId = " + userId + ";", sqlConnection);
            SqlDataReader dr = setName.ExecuteReader();
            dr.Read();
            try {
                string name = dr["ExerciseName"].ToString();
                dr.Close();
                return name;
            }
            catch {
                dr.Close();
                return "";
            }
        }
        private string ExtraNote(string date, int exerciseOrder) {
            SqlCommand extraNote = new SqlCommand("SELECT Note FROM Sets WHERE WorkoutDate = '" + date + "' AND ExerciseOrder = " + exerciseOrder + "AND UserId = " + userId + ";", sqlConnection);
            SqlDataReader reader = extraNote.ExecuteReader();
            reader.Read();
            try {
                string name = reader["Note"].ToString();
                reader.Close();
                return name;
            }
            catch {
                reader.Close();
                return "";
            }
        }
        private string DayName(string date) {
            SqlCommand dayName = new SqlCommand("SELECT TOP 1 DayName FROM Sets WHERE WorkoutDate = '" + date + "' AND UserId = "+ userId + ";", sqlConnection);
            SqlDataReader reader = dayName.ExecuteReader();
            reader.Read();
            try {
                string name = reader["DayName"].ToString();
                reader.Close();
                return name;
            }
            catch {
                reader.Close();
                return "";
            }
        }
        private string WeightOfSet(string date, int SetInd, int exerciseOrder) {
            SqlCommand setWeight = new SqlCommand("SELECT Weight FROM Sets WHERE WorkoutDate = '" + date + "' AND SetInd = " + SetInd + " AND ExerciseOrder ="+ exerciseOrder  + "AND UserId = " + userId + ";", sqlConnection);
            SqlDataReader dr = setWeight.ExecuteReader();
            dr.Read();
            try {
                string weight = dr["Weight"].ToString();
                dr.Close();
                return weight + "kg";
            }
            catch {
                dr.Close();
                return "0kg";
            }
        }
        private string RepsOfSet(string date, int SetInd, int exerciseOrder) {
            SqlCommand setReps = new SqlCommand("SELECT Reps FROM Sets WHERE WorkoutDate = '" + date + "' AND SetInd = " + SetInd + " AND ExerciseOrder =" + exerciseOrder + "AND UserId = " + userId + ";", sqlConnection);
            SqlDataReader dr = setReps.ExecuteReader();
            dr.Read();
            try {
                string reps = dr["Reps"].ToString();
                dr.Close();
                return "x" + reps;
            }
            catch {
                dr.Close();
                return "x0";
            }
        }
        private void LoggedUser() {
            SqlCommand command = new SqlCommand("SELECT * FROM Session;", sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            try {
                string user = reader["LoggedUser"].ToString();
                reader.Close();
                userId = int.Parse(user);
                if (userId == 0) {
                    UserPage.Visible = true;
                    loginPagePanel.Visible = true;
                }
                else {
                    UserPage.Visible = false;
                    loginPagePanel.Visible = false;
                }
            }
            catch {
                reader.Close();
                Console.WriteLine("Couldn't get logged in user.");
            }
        }
        private void Insert(int setInd, string date, int exerciseOrder, string weight, string reps) {
            try {
                SqlCommand add = new SqlCommand("INSERT INTO Sets (SetInd, WorkoutDate, ExerciseOrder, UserId, Weight, Reps, DayName) VALUES (" + setInd + ", '" + date + "' , " + exerciseOrder + " , " + userId + " , " + weight + ", " + reps + " , '" + dayTitle.Text + "');", sqlConnection);
                add.ExecuteNonQuery();
            }
            catch {
                Console.WriteLine("Couldn't insert set.");
            }
        }
        private void RemoveSet(int setInd, string date, int exerciseOrder) {
            try {
                SqlCommand add = new SqlCommand("DELETE FROM Sets WHERE SetInd = " + setInd + " AND WorkoutDate = '" + date + "' AND ExerciseOrder = " + exerciseOrder + " AND UserId = " + userId + ";", sqlConnection);
                add.ExecuteNonQuery();
            }
            catch {
                Console.WriteLine("Couldn't remove set.");
            }
        }
        private void RemoveExercise(string date, int exerciseOrder) {
            try {
                SqlCommand add = new SqlCommand("DELETE FROM Sets WHERE  WorkoutDate = '" + date + "' AND ExerciseOrder = " + exerciseOrder + " AND UserId = " + userId + ";", sqlConnection);
                add.ExecuteNonQuery();
                for(int i = exerciseOrder + 1; i <= exerciseCount(date); i++) {
                    SqlCommand updateRows = new SqlCommand("UPDATE Sets SET ExerciseOrder = " + (i - 1) + " WHERE ExerciseOrder = " + i + " AND WorkoutDate = '" + date + "' AND UserId = " + userId + ";", sqlConnection);
                    updateRows.ExecuteNonQuery();
                }
                
            } 
            catch {
                Console.WriteLine("Couldn't remove Exercise.");
            }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {
            updatePage();
        }

        private void updatePage() {
            LoggedUser();
            if (panel1 != null) {
                // Create a list to store controls that should be removed
                List<Control> controlsToRemove = new List<Control>();

                // Iterate through the controls in the panel
                foreach (Control control in panel1.Controls) {
                    // Check if the control's name is not "addExercise"
                    if (control.Name != "addExercise") {
                        // Add the control to the list of controls to be removed
                        controlsToRemove.Add(control);
                    }
                    else {
                        control.Location = new Point(control.Parent.Size.Width/2 - 100, 53);
                    }
                }

                // Remove the controls that should be deleted
                foreach (Control controlToRemove in controlsToRemove) {
                    panel1.Controls.Remove(controlToRemove);
                    controlToRemove.Dispose(); // Dispose to release resources (optional)
                }
            }
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            for (int i = 1; i <= exerciseCount(date); i++) {
                CreateExercise(i, 0, spaceBetweenExercises * (i-1), false);
            }
            dayTitle.Text = DayName(date);
            calculateSetsAndVolume();
        }
        private void removeExercise(object sender, EventArgs e) {
            if (sender is Button button) {
                int exerciseOrder = int.Parse(button.Name.Substring(17, button.Name.Length - 17));
                List<Control> toMove = new List<Control>();
                List<Control> toRemove = new List<Control>();
                foreach (Control exercisepanel in panel1.Controls) {
                    if (exercisepanel.Name.StartsWith("exercise")) {
                        if (int.Parse(exercisepanel.Name.Substring(8, exercisepanel.Name.Length - 8)) == exerciseOrder) {
                            toRemove.Add(exercisepanel);
                        }
                        if (int.Parse(exercisepanel.Name.Substring(8, exercisepanel.Name.Length - 8)) > exerciseOrder) {
                            toMove.Add(exercisepanel);
                        }
                    }
                }
                RemoveExercise(dateTimePicker1.Value.ToString("yyyy-MM-dd"), exerciseOrder);
                foreach (Control exercise in toMove) {
                    int scroll = panel1.AutoScrollPosition.Y;
                    exerciseOrder = int.Parse(exercise.Name.Substring(8, exercise.Name.Length - 8));
                    Console.WriteLine(exerciseOrder);
                    exercise.Location = new System.Drawing.Point(20, exercise.Location.Y - spaceBetweenExercises);
                    exercise.Name = exercise.Name.Substring(0, 8) + (exerciseOrder - 1);
                    exerciseOrder = int.Parse(exercise.Name.Substring(8, exercise.Name.Length - 8));
                    Console.WriteLine(exerciseOrder);
                    foreach (Control control in exercise.Controls) {
                        int btnOrder;
                        if (control.Name.StartsWith("removeExerciseBtn")) {
                            btnOrder = int.Parse(control.Name.Substring(17, control.Name.Length - 17));
                            control.Name = "removeExerciseBtn" + (btnOrder - 1 );
                        }
                        else if (control.Name.StartsWith("setPanel")) {
                            Console.WriteLine(control.Name.Substring(8, control.Name.Length - 8));
                            btnOrder = int.Parse(control.Name.Substring(8, control.Name.Length - 8));
                            control.Name = "setPanel" + (btnOrder - 1);
                        }
                    }
                }
                foreach (Control exercise in toRemove) {
                    panel1.Controls.Remove(exercise);
                }
                int newScroll = panel1.AutoScrollPosition.Y;
                addExercise.Location = new System.Drawing.Point(addExercise.Parent.Size.Width / 2 - 100, exerciseCount(dateTimePicker1.Value.ToString("yyyy-MM-dd")) * spaceBetweenExercises + 50 + newScroll);
            }
        }
        private void CreateExercise(int exerciseOrder, int xOffset, int yOffset, bool late) {
            int horizontalSpace = 20;
            int verticalSpace = 20;
            int xSize = panel1.Size.Width - horizontalSpace * 2, ySize = 130;
            if (late) xSize = xSize - horizontalSpace;
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            Panel newGroupBox = new Panel();
            int setIndex = int.Parse(setInd(dateTimePicker1.Value.ToString("yyyy-MM-dd"), exerciseOrder));
            int exerciseCount_ = exerciseCount(date);

            // Copy properties from the original GroupBox
            newGroupBox.Location = new System.Drawing.Point(horizontalSpace + xOffset, verticalSpace + yOffset);
            newGroupBox.Size = new System.Drawing.Size(xSize, ySize);
            newGroupBox.Name = "exercise" + exerciseOrder;
            newGroupBox.BackColor = Color.LightGray;
            newGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            newGroupBox.AutoScroll = false;


            // Create exerciseNameTxt
            TextBox exerciseNameTxt = new TextBox();
            exerciseNameTxt.Name = "_exerciseNameTxt" + exerciseOrder;
            exerciseNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20);
            exerciseNameTxt.Size = new System.Drawing.Size(250, 40);
            exerciseNameTxt.BackColor = Color.Red;
            exerciseNameTxt.ForeColor = Color.White;
            exerciseNameTxt.TextAlign = HorizontalAlignment.Center;
            exerciseNameTxt.Text = NameOfExercise(date, exerciseOrder);
            exerciseNameTxt.KeyUp += exerciseNameTxt_KeyUp;
            exerciseNameTxt.Anchor = AnchorStyles.Top;
            exerciseNameTxt.Location = new System.Drawing.Point(50, 20);
            newGroupBox.Controls.Add(exerciseNameTxt);
            // Create extraNote
            TextBox extraNoteTxt = new TextBox();
            extraNoteTxt.Name = "extraNoteTxt" + exerciseOrder;
            extraNoteTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20);
            extraNoteTxt.Size = new System.Drawing.Size(250, 40);
            extraNoteTxt.BackColor = Color.White;
            extraNoteTxt.Location = new System.Drawing.Point(330, 20);
            extraNoteTxt.TextAlign = HorizontalAlignment.Center;
            extraNoteTxt.Text = ExtraNote(date, exerciseOrder);
            extraNoteTxt.KeyUp += ExerciseNote;
            extraNoteTxt.Anchor = AnchorStyles.Top;
            newGroupBox.Controls.Add(extraNoteTxt);
            // Create addSetBtn
            Button addSetBtn = new Button();
            addSetBtn.Name = "addSetBtn" + exerciseOrder;
            addSetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16);
            addSetBtn.Size = new System.Drawing.Size(32, 32);
            addSetBtn.Location = new System.Drawing.Point(setIndex * 140 + 20, 10);
            addSetBtn.BackColor = Color.Red;
            addSetBtn.ForeColor = Color.White;
            addSetBtn.TextAlign = ContentAlignment.MiddleCenter;
            addSetBtn.Text = "+";
            addSetBtn.Click += addSet_Click;

            // Create removeExerciseBtn
            Button removeExerciseBtn = new Button();
            removeExerciseBtn.Name = "removeExerciseBtn" + exerciseOrder;
            removeExerciseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20);
            removeExerciseBtn.Size = new System.Drawing.Size(40, 40);
            removeExerciseBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            removeExerciseBtn.Location = new System.Drawing.Point(newGroupBox.Size.Width - 50, 10);
            removeExerciseBtn.BackColor = Color.Gray;
            removeExerciseBtn.ForeColor = Color.White;
            removeExerciseBtn.TextAlign = ContentAlignment.TopCenter;
            removeExerciseBtn.Text = "x";
            removeExerciseBtn.Click += removeExercise;
            newGroupBox.Controls.Add(removeExerciseBtn);

            // Create removeSetBtn
            Button removeSetBtn = new Button();
            removeSetBtn.Name = "removeSetBtn" + exerciseOrder;
            removeSetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16);
            removeSetBtn.Size = new System.Drawing.Size(32, 32);
            removeSetBtn.Location = new System.Drawing.Point(setIndex * 140 + 60, 10);
            removeSetBtn.BackColor = Color.Red;
            removeSetBtn.ForeColor = Color.White;
            removeSetBtn.TextAlign = ContentAlignment.TopCenter;
            removeSetBtn.Text = "-";
            removeSetBtn.Click += removeSet_Click;

            //Create Panel for sets
            Panel setPanel = new Panel();
            setPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            setPanel.Location = new System.Drawing.Point(horizontalSpace, 60);
            setPanel.Size = new System.Drawing.Size(newGroupBox.Size.Width - horizontalSpace * 2, 65);
            setPanel.Name = "setPanel" + exerciseOrder;
            setPanel.AutoScroll = true;
            setPanel.BackColor = Color.Gray;
            setPanel.Controls.Add(addSetBtn);
            setPanel.Controls.Add(removeSetBtn);
            newGroupBox.Controls.Add(setPanel);
            panel1.Controls.Add(newGroupBox);

            for (int i = 1; i<= setIndex; i++) {
                TextBox weightTxt = AddWeightTxt( i, 0);
                TextBox repTxt = AddRepTxt(i, 0);
                weightTxt.Text = WeightOfSet(date, i, exerciseOrder);
                repTxt.Text = RepsOfSet(date, i, exerciseOrder);
                weightTxt.TextAlign = HorizontalAlignment.Center;
                repTxt.TextAlign = HorizontalAlignment.Center;
                setPanel.Controls.Add(weightTxt);
                setPanel.Controls.Add(repTxt);
            }
            addExercise.Location = new System.Drawing.Point(addExercise.Parent.Size.Width / 2 - 100, exerciseCount_ * spaceBetweenExercises + 50);
            
        }
        private TextBox AddWeightTxt(int setIndex_, int scroll) {
            // Create weightTxt
            TextBox weightTxt = new TextBox();
            weightTxt.Name = "weightTxt" + setIndex_;
            weightTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16);
            weightTxt.Size = new System.Drawing.Size(65, 32);
            weightTxt.Location = new System.Drawing.Point(20 + (setIndex_-1) * 140 + scroll, 10);
            weightTxt.BackColor = Color.White;
            weightTxt.KeyUp += weightChanged;
            weightTxt.LostFocus += weightTextLostFocus;
            weightTxt.Text = "0kg";
            weightTxt.TextAlign = HorizontalAlignment.Center;
            return weightTxt;
            

        }
        private TextBox AddRepTxt(int setIndex_, int scroll) {
            // Create setTxt

            TextBox repTxt = new TextBox();
            repTxt.Name = "repTxt" + setIndex_;
            repTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16);
            repTxt.Size = new System.Drawing.Size(65, 32);
            repTxt.Location = new System.Drawing.Point(80 + (setIndex_ - 1) * 140 + scroll, 10);
            repTxt.BackColor = Color.White;
            repTxt.KeyUp += repChanged;
            repTxt.LostFocus += repTextLostFocus;
            repTxt.TextAlign = HorizontalAlignment.Center;
            repTxt.Text = "x0";
            return repTxt;

        }
        private void weightTextLostFocus(object sender, EventArgs e) {
            if (sender is TextBox textBox) {
                int exerciseOrder = int.Parse(textBox.Parent.Parent.Name.Substring(8));
                int setInd = int.Parse(textBox.Name.Substring(9));
                textBox.Text = WeightOfSet(dateTimePicker1.Value.ToString("yyyy-MM-dd"), setInd, exerciseOrder);
                textBox.ForeColor = Color.Black;
            }
        }
        private void repTextLostFocus(object sender, EventArgs e) {
            if (sender is TextBox textBox) {
                int exerciseOrder = int.Parse(textBox.Parent.Parent.Name.Substring(8));
                int setInd = int.Parse(textBox.Name.Substring(6));
                textBox.Text = RepsOfSet(dateTimePicker1.Value.ToString("yyyy-MM-dd"), setInd, exerciseOrder);
                textBox.ForeColor = Color.Black;
            }
        }
        private void weightChanged(object sender, EventArgs e) {
            if (sender is TextBox textBox) {
                int exerciseOrder = int.Parse(textBox.Parent.Parent.Name.Substring(8));
                int setInd = int.Parse(textBox.Name.Substring(9));
                string textWithoutKg = textBox.Text;
                if(textWithoutKg.Length >= 2) {
                    if (textWithoutKg.Substring(textWithoutKg.Length - 2, 2) == "kg") {
                        textWithoutKg = textWithoutKg.Substring(0, textWithoutKg.Length - 2);
                    };
                }
                try {
                    changeWeight(int.Parse(textWithoutKg), exerciseOrder, dateTimePicker1.Value.ToString("yyyy-MM-dd"), setInd);
                    textBox.ForeColor = Color.Black;
                    calculateSetsAndVolume();
                }
                catch {
                    textBox.ForeColor = Color.Red;
                }
            }
        }
        private void repChanged(object sender, EventArgs e) {
            if (sender is TextBox textBox) {
                int exerciseOrder = int.Parse(textBox.Parent.Parent.Name.Substring(8));
                int setInd = int.Parse(textBox.Name.Substring(6));
                string textWithoutX = textBox.Text;
                if(textWithoutX.Length > 1) {
                    if (textWithoutX.Substring(0, 1) == "x") {
                        textWithoutX = textWithoutX.Substring(1, textWithoutX.Length - 1);
                    };
                }
                try {
                    changeReps(int.Parse(textWithoutX), exerciseOrder, dateTimePicker1.Value.ToString("yyyy-MM-dd"), setInd);
                    textBox.ForeColor = Color.Black;
                    calculateSetsAndVolume();
                }
                catch {
                    Console.WriteLine("Couldnt update rep on the database2");
                    textBox.ForeColor = Color.Red;
                }
            }
        }
        private void changeWeight(int weight, int exerciseOrder, string date, int setInd) {
            try {
                SqlCommand add = new SqlCommand("UPDATE Sets SET Weight = " + weight + " WHERE ExerciseOrder = " + exerciseOrder + " AND WorkoutDate = '" + date + "' AND SetInd = "+ setInd + "AND UserId = " + userId + ";", sqlConnection);
                add.ExecuteNonQuery();
            }
            catch {
                Console.WriteLine("Couldnt update set on the database2");
            }
        }
        private void changeReps(int reps, int exerciseOrder, string date, int setInd) {
            try {
                SqlCommand add = new SqlCommand("UPDATE Sets SET Reps = " + reps + " WHERE ExerciseOrder = " + exerciseOrder + " AND WorkoutDate = '" + date + "' AND SetInd = " + setInd + "AND UserId = " + userId + ";", sqlConnection);
                add.ExecuteNonQuery();
            }
            catch {
                Console.WriteLine("Couldnt update rep on the database2");
            }
        }
        private void exerciseNameTxt_KeyUp(object sender, KeyEventArgs e) {
            if (sender is TextBox textBox) {
                string exerciseName = textBox.Name;
                string numbers = exerciseName.Substring(16);
                int exerciseOrder = int.Parse(numbers);
                changeExerciseName(textBox.Text, exerciseOrder, dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            }
        }
        private void ExerciseNote(object sender, KeyEventArgs e) {
            if (sender is TextBox textBox) {
                string exerciseNote = textBox.Text;
                string exerciseName = textBox.Name;
                string numbers = exerciseName.Substring(12);
                int exerciseOrder = int.Parse(numbers);
                try {
                    SqlCommand add = new SqlCommand("UPDATE Sets SET Note = '" + exerciseNote + "' WHERE ExerciseOrder = " + exerciseOrder + " AND WorkoutDate = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND UserId = " + userId + ";", sqlConnection);
                    add.ExecuteNonQuery();
                }
                catch {
                    Console.WriteLine("Coudlnt update Note in database");
                }
            }
        }
        private void changeExerciseName(string exerciseName, int exerciseOrder, string date) {
            try {
                SqlCommand add = new SqlCommand("UPDATE Sets SET ExerciseName = '" + exerciseName + "' WHERE ExerciseOrder = " + exerciseOrder + " AND WorkoutDate = '" + date + "' AND UserId = " + userId + ";", sqlConnection);
                add.ExecuteNonQuery();
            }
            catch {
                Console.WriteLine("Couldnt update exercise name in database");
            }
        }
        private void changeDayName(object sender, KeyEventArgs e) {
            if (sender is TextBox textBox) {
                string dayName = textBox.Text;
                try {
                    SqlCommand add = new SqlCommand("UPDATE Sets SET DayName = '" + dayName + "' WHERE  WorkoutDate = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND UserId = " + userId + ";", sqlConnection);
                    add.ExecuteNonQuery();
                }
                catch {
                    Console.WriteLine("couldnt update day name in database");
                }
            }
        }
        private void calculateSetsAndVolume() {
            string query = "SELECT Reps, Weight FROM Sets WHERE WorkoutDate = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND UserId = " + userId + ";";
            List<int> repsList = new List<int>();
            List<int> weightList = new List<int>();
            SqlCommand getRepsAndWeights = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = getRepsAndWeights.ExecuteReader();
            while(reader.Read()) {
                int reps = reader.GetInt32(0);
                int weights = reader.GetInt32(1);
                repsList.Add(reps);
                weightList.Add(weights);
            }
            reader.Close();
            int setCount = repsList.Count;
            float volume = 0;
            for (int i = 0;  i < repsList.Count; i++) {
                volume += repsList[i] * weightList[i];
            }
            sets_volume.Text = "Sets: " + setCount.ToString() + " \nVolume: " + volume.ToString() + "kg";
        }

        private void signupBtn_Click(object sender, EventArgs e) {
            SqlCommand command = new SqlCommand("SELECT * FROM Users;", sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<string> usernames = new List<string>();
            while (reader.Read()) {
                usernames.Add(reader["Username"].ToString());
            }
            reader.Close();
            if (usernames.Contains(signupUsername.Text)){
                MessageBox.Show("Username already taken!");
            }
            else if (signupPassword.Text != signupPasswordVerification.Text) {
                MessageBox.Show("Passwords do not match!");
            }
            else if (signupPassword.Text == "" || signupUsername.Text == "") {
                MessageBox.Show("Please fill in the user information!");
            }
            else if (signupPassword.Text.Length < 8) {
                MessageBox.Show("Please choose a password longer than 8 characters!");
            }
            else {
                try {
                    SqlCommand addUser = new SqlCommand("INSERT INTO Users (Username, Password) VALUES ('" + signupUsername.Text + "' , '"+ signupPassword.Text + "');", sqlConnection);
                    addUser.ExecuteNonQuery();
                    loginPagePanel.Visible = true;
                    SignupPagePanel.Visible = false;
                }
                catch {
                    Console.WriteLine("Couldn't insert the new user.");
                    Console.WriteLine(signupUsername.Text);
                    Console.WriteLine(signupPassword.Text);
                }
            }
        }

        private void label6_Click(object sender, EventArgs e) {
            loginPagePanel.Visible = true;
            SignupPagePanel.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e) {
            loginPagePanel.Visible = false;
            SignupPagePanel.Visible = true;

        }

        private void loginBtn_Click(object sender, EventArgs e) {
            SqlCommand setInd = new SqlCommand("SELECT * FROM Users WHERE Username = '" + loginUsername.Text + "'  AND Password = '" + loginPassword.Text + "';", sqlConnection);
            SqlDataReader reader = setInd.ExecuteReader();
            reader.Read();
            try {
                int loggedUser = (int.Parse(reader["UserId"].ToString()));
                reader.Close();
                SqlCommand session = new SqlCommand("UPDATE Session SET LoggedUser = " + loggedUser + ";", sqlConnection);
                session.ExecuteNonQuery();
                Console.WriteLine(userId);
                loginPagePanel.Visible = false;
                UserPage.Visible = false;
            }
            catch {
                MessageBox.Show("Incorrect username or password!");
                reader.Close();
            }
            updatePage();
        }

        private void button1_Click(object sender, EventArgs e) {
            SqlCommand session = new SqlCommand("UPDATE Session SET LoggedUser = 0 ;", sqlConnection);
            session.ExecuteNonQuery();
            LoggedUser();
        }

        private void passwordVisible_CheckedChanged(object sender, EventArgs e) {
            if (passwordVisible.Checked) {
                loginPassword.PasswordChar = '\0';
            }
            else loginPassword.PasswordChar = '*';
        }
    }
}