    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    namespace TpCalculette
    {
        public partial class frmCalculette : Form
        {
            public frmCalculette()
            {
                InitializeComponent();

            }


            double result;
            double[] numbers = new double[2];
            double currentNumber;
            string operatorSymbol;
            bool isNewCalculation = true;
            private void button25_Click(object sender, EventArgs e)//test
            {
                NumberButtonClick(sender, e);

            }

            private void button26_Click(object sender, EventArgs e)
            {
                NumberButtonClick(sender, e);


            }


            private void button9_Click(object sender, EventArgs e)
            {
                NumberButtonClick(sender, e);

            }

            private void button4_Click(object sender, EventArgs e)
            {
                NumberButtonClick(sender, e);

            }

            private void button5_Click(object sender, EventArgs e)
            {
                NumberButtonClick(sender, e);


            }

            private void button6_Click(object sender, EventArgs e)
            {
                NumberButtonClick(sender, e);

            }

            private void button3_Click(object sender, EventArgs e)
            {
                NumberButtonClick(sender, e);


            }

            private void button2_Click(object sender, EventArgs e)
            {
                NumberButtonClick(sender, e);


            }

            private void button1_Click(object sender, EventArgs e)
            {
                NumberButtonClick(sender, e);

            }
            private void button0_Click(object sender, EventArgs e)
            {
                NumberButtonClick(sender, e);

            }


            private void buttonNegate_Click(object sender, EventArgs e)
            {
                double currentValue = double.Parse(textBoxAffichage.Text);
                currentValue = -currentValue;
                textBoxAffichage.Text = currentValue.ToString();
                currentNumber = currentValue;

                if (!isNewCalculation)
                {
                    numbers[0] = currentValue;
                }
            }

            private void buttonM_Click(object sender, EventArgs e)
            {
                PerformOperation();
                operatorSymbol = "*";
            }

            private double runningTotal = 0.0;


            private void textBoxAffichage_TextChanged(object sender, EventArgs e)
            {

            }

            private void NumberButtonClick(object sender, EventArgs e)
            {
                Button button = (Button)sender;

                if (isNewCalculation)
                {
                    textBoxAffichage.Text = button.Text;
                    isNewCalculation = false;
                }
                else
                {
                    textBoxAffichage.Text += button.Text;
                }

                currentNumber = double.Parse(textBoxAffichage.Text);
            }

            private void buttonPoint_Click(object sender, EventArgs e)
            {
                if (!textBoxAffichage.Text.Contains("."))
                {
                    textBoxAffichage.Text += ".";
                }
            }


            private void buttonPlus_Click(object sender, EventArgs e)
            {
                PerformOperation();
                operatorSymbol = "+";
            }

            private void buttonLess_Click(object sender, EventArgs e)
            {
                PerformOperation();
                operatorSymbol = "-";
            }

            private void buttonDivision_Click(object sender, EventArgs e)
            {
                PerformOperation();
                operatorSymbol = "/";
            }
            private void PerformOperation()
            {
                if (!isNewCalculation)
                {
                    numbers[1] = currentNumber;

                    if (numbers.Length >= 2)
                    {
                        switch (operatorSymbol)
                        {
                            case "+":
                                currentNumber = numbers[0] + numbers[1];
                                break;
                            case "-":
                                currentNumber = numbers[0] - numbers[1];
                                break;
                            case "*":
                                currentNumber = numbers[0] * numbers[1];
                                break;
                            case "/":
                                if (numbers[1] != 0)
                                    currentNumber = numbers[0] / numbers[1];
                                else if (numbers[1] == 0)
                                {
                                    MessageBox.Show("Cannot divide by zero.");
                                }


                                break;
                        }

                        numbers[0] = currentNumber;

                        textBoxAffichage.Text = currentNumber.ToString();
                        isNewCalculation = true;
                    }
                }
                else
                {
                    // Reset the array
                    numbers = new double[2];
                    numbers[0] = currentNumber;
                }
            }


            private void buttonEqual_Click(object sender, EventArgs e)
            {
                PerformOperation();
                isNewCalculation = true;
            }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!isNewCalculation)
            {
                if (textBoxAffichage.Text.Length > 1)
                {
                    textBoxAffichage.Text = textBoxAffichage.Text.Substring(0, textBoxAffichage.Text.Length - 1);
                    currentNumber = double.Parse(textBoxAffichage.Text);
                }
                else
                {
                    textBoxAffichage.Text = "0";
                    currentNumber = 0;
                    isNewCalculation = true;
                }
            }
        }


        private void buttonDeleteAll_Click(object sender, EventArgs e)
            {
                numbers = new double[2];
                currentNumber = 0;
                operatorSymbol = "";
                isNewCalculation = true;
                textBoxAffichage.Text = "0";
            }



            private void frmCalculette_KeyPress(object sender, KeyPressEventArgs e)
            {
                // Handle numeric keys
                if (char.IsDigit(e.KeyChar))
                {
                    NumberKeyPress(e.KeyChar);
                }
                else if (e.KeyChar == '.')
                {
                    buttonPoint_Click(sender, e);
                }
                else if (e.KeyChar == (char)Keys.Enter)
                {
                    buttonEqual_Click(sender, e);
                }
                else if (e.KeyChar == (char)Keys.Back)
                {
                    buttonDelete_Click(sender, e);
                }
                else if (e.KeyChar == '+')
                {
                    buttonPlus_Click(sender, e);
                }
                else if (e.KeyChar == '-')
                {
                    buttonLess_Click(sender, e);
                }
                else if (e.KeyChar == '*')
                {
                    buttonM_Click(sender, e);
                }
                else if (e.KeyChar == '/')
                {
                    buttonDivision_Click(sender, e);
                }
            }

            private void NumberKeyPress(char key)
            {
                if (isNewCalculation)
                {
                    textBoxAffichage.Text = key.ToString();
                    isNewCalculation = false;
                }
                else
                {
                    textBoxAffichage.Text += key;
                }

                currentNumber = double.Parse(textBoxAffichage.Text);
            }

            private void frmCalculette_Load(object sender, EventArgs e)
            {
                // Subscribe to the KeyPress event when the form loads
                this.KeyPress += frmCalculette_KeyPress;
                // Set KeyPreview property of the form to true to capture key events
                this.KeyPreview = true;
            }

            private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

            private void textBox1_TextChanged_1(object sender, EventArgs e)
            {

            }


        private void RERDED_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
    }
