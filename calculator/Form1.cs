using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        public string CurrentText { get { return txtBoxCurrent.Text; } set { txtBoxCurrent.Text = value; } }
        public List<string> CalcHistory { get { return txtBoxHistory.Lines.ToList<string>(); } set { txtBoxHistory.Lines = value.ToArray(); } }

        private enum Operator
        {
            PLUS = 0,
            MINUS = 1,
            DIVIDE = 2,
            MULTIPLY = 3
        }

        private string[] operators = new string[] { " + ", " - ", " / ", " * " };

        public Form1()
        {
            InitializeComponent();
            NumberButtonSetup();
            OperatorButtonSetup();
            CalcHistory = new List<string>();
        }

        private void NumberButtonSetup()
        {
            List<Button> nbrButtons = GetControlsOfType(this, typeof(Button)).Where(x => x.Name.StartsWith("btnNmbr")).Cast<Button>().ToList<Button>();
            foreach (Button btn in nbrButtons)
            {
                btn.Tag = int.Parse(btn.Name.Last().ToString());
                btn.Click += numberButton_Click;
            }
        }

        private void OperatorButtonSetup()
        {
            List<Button> fncButtons = GetControlsOfType(this, typeof(Button)).Where(x => x.Name.StartsWith("btnOp")).Cast<Button>().ToList<Button>();
            foreach (Button btn in fncButtons)
            {
                string name = btn.Name.Replace("btnOp", "");
                switch (name)
                {
                    case "Plus": btn.Tag = Operator.PLUS;
                        break;
                    case "Minus": btn.Tag = Operator.MINUS;
                        break;
                    case "Multiply": btn.Tag = Operator.MULTIPLY;
                        break;
                    case "Divide": btn.Tag = Operator.DIVIDE;
                        break;
                }
                btn.Click += funcButton_Click;
            }
        }

        private List<Control> GetControlsOfType(Control parent, Type controlType)
        {
            return parent.Controls.Cast<Control>().Where(x => x.GetType() == controlType).ToList<Control>();
        }

        public void AddToHistory(string s)
        {
            txtBoxHistory.AppendText(s + Environment.NewLine);
        }

        public void funcButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            CurrentText += GetFunctionStringOfButton(btn);
        }

        public string GetFunctionStringOfButton(Button btn)
        {
            return operators[Convert.ToInt32(btn.Tag)];
        }

        public void numberButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            CurrentText += btn.Tag.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (CurrentText.Length > 0)
            {
                CurrentText = CurrentText.Remove(CurrentText.Length - 1);
            }
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            AddToHistory(CurrentText);
            CurrentText = String.Empty;
        }
    }
}
