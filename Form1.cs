using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string isNegative = "";
            lblValue.Text = "";
            try
            {
                string number = Convert.ToInt64(textBox1.Text).ToString();

                if (number.Contains("-"))
                {
                    isNegative = "Minus ";
                    number = number.Substring(1, number.Length - 1);
                }

                if (number == "0")                
                    lblValue.Text = "Zero";                
                else                
                    lblValue.Text = isNegative + ConvertToWords(number);
                
            }
            catch (Exception ex)
            {
                lblValue.Text = ex.Message+" Enter Numaric Values only.";
            }
        }
        
        private String ConvertToWords(String numb)
        {
            String val = "", wholeNo = numb, andStr = "", pointStr = "";
            
            try
            {               
                val = String.Format("{0} {1}{2}.", ConvertToNumber(wholeNo).Trim(), andStr, pointStr);
            }
            catch (Exception ex) { lblValue.Text = ex.Message; }
            return val;
        }

        private String ConvertToNumber(String Number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;
                bool isDone = false;
                double dblAmt = (Convert.ToDouble(Number));
               
                if (dblAmt > 0)
                {
                    beginsZero = Number.StartsWith("0");

                    int numDigits = Number.Length;
                    int pos = 0;
                    String place = "";
                    switch (numDigits)
                    {
                        case 1:

                            word = ones(Number);
                            isDone = true;
                            break;
                        case 2:   
                            word = tens(Number);
                            isDone = true;
                            break;
                        case 3:    
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4:    
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7:    
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10:   
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                      
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {
                        if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertToNumber(Number.Substring(0, pos)) + place + ConvertToNumber(Number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertToNumber(Number.Substring(0, pos)) + ConvertToNumber(Number.Substring(pos));
                        }
                                             
                    }
                    
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch(Exception ex) { lblValue.Text = ex.Message; }            
            return word.Trim();
        }

        private String ones(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = "";
            switch (_Number)
            {

                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        private String tens(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = null;
            switch (_Number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_Number > 0)
                    {
                        name = tens(Number.Substring(0, 1) + "0") + " " + ones(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }
    }
}
