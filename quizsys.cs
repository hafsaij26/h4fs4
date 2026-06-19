using System;
using System.Windows.Forms;

namespace QuizSystem
{
    public partial class Form1 : Form
    {
        int questionNo = 0;
        int score = 0;

        string[] questions =
        {
            "What is the capital of Pakistan?",
            "2 + 2 = ?",
            "Which language is used for Windows Forms?",
            "What does CPU stand for?",
            "Which company developed C#?"
        };

        string[,] options =
        {
            {"Lahore","Islamabad","Karachi","Peshawar"},
            {"3","4","5","6"},
            {"Python","Java","C#","PHP"},
            {"Central Processing Unit","Computer Process Unit","Central Program Unit","Control Processing Unit"},
            {"Google","Microsoft","Apple","IBM"}
        };

        int[] answers =
        {
            1,
            1,
            2,
            0,
            1
        };

        public Form1()
        {
            InitializeComponent();
            LoadQuestion();
        }

        private void LoadQuestion()
        {
            lblQuestion.Text = questions[questionNo];

            rdoA.Text = options[questionNo, 0];
            rdoB.Text = options[questionNo, 1];
            rdoC.Text = options[questionNo, 2];
            rdoD.Text = options[questionNo, 3];

            rdoA.Checked = false;
            rdoB.Checked = false;
            rdoC.Checked = false;
            rdoD.Checked = false;

            lblScore.Text = "Score : " + score;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int selectedAnswer = -1;

            if (rdoA.Checked)
                selectedAnswer = 0;
            else if (rdoB.Checked)
                selectedAnswer = 1;
            else if (rdoC.Checked)
                selectedAnswer = 2;
            else if (rdoD.Checked)
                selectedAnswer = 3;

            if (selectedAnswer == -1)
            {
                MessageBox.Show("Please select an answer.");
                return;
            }

            if (selectedAnswer == answers[questionNo])
            {
                score++;
            }

            questionNo++;

            if (questionNo < questions.Length)
            {
                LoadQuestion();
            }
            else
            {
                MessageBox.Show(
                    "Quiz Completed!\n\nScore: "
                    + score + " / "
                    + questions.Length);

                lblQuestion.Text = "Quiz Finished!";
                rdoA.Visible = false;
                rdoB.Visible = false;
                rdoC.Visible = false;
                rdoD.Visible = false;
                btnNext.Enabled = false;

                lblScore.Text =
                    "Final Score: "
                    + score + " / "
                    + questions.Length;
            }
        }
    }
}
