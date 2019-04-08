/**
 *  @file           Form1.cs / FormMTPunchoutPassGen
 *  @brief          Password Generator for the Nintendo Entertainment System Game Mike Tyson's Punch-Out
 *  @copyright      Shawn M. Crawford 2019
 *  @date           04/08/2019
 *
 *  @remark Author  Shawn M. Crawford (sleepy9090)
 *
 *  @note           Uses the guide by Doug Babcock from https://www.dougbabcock.com/mtpo-passwords.txt (Attached)
 *
 */
using System;
using System.Windows.Forms;

namespace MTPunchoutPassGen
{
    public partial class FormMTPunchoutPassGen : Form
    {
        private const int MAGIC_NUMBER = 63;

        public FormMTPunchoutPassGen()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            populateComboBoxes();
            textBoxPassword.ReadOnly = true;
        }

        private void populateComboBoxes()
        {
            for (int x = 3; x <= 99; x++)
            {
                comboBoxWins.Items.Add(x);
            }

            for (int x = 0; x <= 99; x++)
            {
                comboBoxKOs.Items.Add(x);
            }

            for (int x = 0; x <=2; x++)
            {
                comboBoxLosses.Items.Add(x);
            }


            comboBoxWins.SelectedIndex = 0;
            comboBoxLosses.SelectedIndex = 0;
            comboBoxKOs.SelectedIndex = 0;
        }

        private void buttonGeneratePassword_Click(object sender, EventArgs e)
        {
            int numberOfWins = (int)comboBoxWins.SelectedItem;
            int numberOfLosses = (int)comboBoxLosses.SelectedItem;
            int numberOfKOs = (int)comboBoxKOs.SelectedItem;
            int title = 0;

            if (numberOfKOs > numberOfWins)
            {
                MessageBox.Show("The KOs must be less than or equal to the wins.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                return;
            }

            /**
             * TITLE NUMBER-TO-NAME KEY
             * 
             * Title number     Title name
             * ---------------------------
             * 0       "Minor"
             * 1       "Major"
             * 2       "World"
             **/
            if (radioButtonMinorCircuit.Checked)
            {
                title = 0;
            }
            else if (radioButtonMajorCircuit.Checked)
            {
                title = 1;
            }
            else if (radioButtonWorldCircuit.Checked)
            {
                title = 2;
            }

            /**
             * Title Held:  Losses:  Use:
             * ----------------------------
             * "Minor"        0     TABLE I
             * "Minor"        1     TABLE II
             * "Minor"        2     TABLE III
             * "Major"        0     TABLE II
             * "Major"        1     TABLE III
             * "Major"        2     TABLE I
             * "World"        0     TABLE III
             * "World"        1     TABLE I
             * "World"        2     TABLE II
             **/
            if ((title == 0 && numberOfLosses == 0) || (title == 1 && numberOfLosses == 2) || (title == 2 && numberOfLosses == 1))
            {
                // table 1
                calcUsingTable1(numberOfWins, numberOfLosses, numberOfKOs, title);
            }
            else if ((title == 0 && numberOfLosses == 1) || (title == 1 && numberOfLosses == 0) || (title == 2 && numberOfLosses == 2))
            {
                // table 2
                calcUsingTable2(numberOfWins, numberOfLosses, numberOfKOs, title);
            }
            else if ((title == 0 && numberOfLosses == 2) || (title == 1 && numberOfLosses == 1) || (title == 2 && numberOfLosses == 0))
            {
                // table 3
                calcUsingTable3(numberOfWins, numberOfLosses, numberOfKOs, title);
            }
        }

        /**
         * TABLE I. (Base code: 635 791 5429)
         * 
         * +-------------+-------------+-------------+
         * | Checksum +16|     Wins +80|     Wins +40|
         * |        KO +2|        KO +1|  Checksum +8|
         * |  Checksum +4|        KO +8|        KO +4|
         * |             |             |             |
         * |     Wins +20|     Wins +10|  Checksum +2|
         * |  Checksum +1|       KO +80|       KO +40|
         * |      Wins +2|      Wins +1|XXXXXXXXXXXXX|
         * |             |             |             |
         * |XXXXXXXXXXXXX|      Wins +8|      Wins +4|
         * |       KO +20|       KO +10|    Losses +2|
         * |    Losses +1|     Title +2|     Title +1|
         * | Checksum +32|XXXXXXXXXXXXX|XXXXXXXXXXXXX|
         * +-------------+-------------+-------------+
         **/
        private void calcUsingTable1(int numberOfWins, int numberOfLosses, int numberOfKOs, int title)
        {
            int[] baseCode = { 6, 3, 5, 7, 9, 1, 5, 4, 2, 9 };
            int[] bits1 = new int[3];
            int[] bits2 = new int[3];
            int[] bits3 = new int[3];

            int[] bits4 = new int[3];
            int[] bits5 = new int[3];
            int[] bits6 = new int[3];

            int[] bits7 = new int[3];
            int[] bits8 = new int[3];
            int[] bits9 = new int[3];
            int[] bits10 = new int[3];

            #region Checksum
            // add wins, losses, and KOs
            int numberOfWinsDigit1 = 0;
            int numberOfWinsDigit2 = 0;
            int numberOfKOsDigit1 = 0;
            int numberOfKOsDigit2 = 0;

            if (numberOfWins >= 10)
            {
                string numberOfWinsString1 = numberOfWins.ToString().Substring(0, 1);
                string numberOfWinsString2 = numberOfWins.ToString().Substring(1, 1);
                numberOfWinsDigit1 = Convert.ToInt32(numberOfWinsString1);
                numberOfWinsDigit2 = Convert.ToInt32(numberOfWinsString2);
            }
            else
            {
                numberOfWinsDigit1 = numberOfWins;
            }

            if (numberOfKOs >= 10)
            {
                string numberOfKOsString1 = numberOfKOs.ToString().Substring(0, 1);
                string numberOfKOsString2 = numberOfKOs.ToString().Substring(1, 1);
                numberOfKOsDigit1 = Convert.ToInt32(numberOfKOsString1);
                numberOfKOsDigit2 = Convert.ToInt32(numberOfKOsString2);
            }
            else
            {
                numberOfKOsDigit1 = numberOfKOs;
            }

            int winLossKOTotal = numberOfWinsDigit1 + numberOfWinsDigit2 + numberOfLosses + numberOfKOsDigit1 + numberOfKOsDigit2;
            int checksumDecimal = MAGIC_NUMBER - winLossKOTotal;

            if (checksumDecimal >= 32)
            {
                bits10[0] = 1;
                checksumDecimal -= 32;
            }
            else
            {
                bits10[0] = 0;
            }

            if (checksumDecimal >= 16)
            {
                bits1[0] = 1;
                checksumDecimal -= 16;
            }
            else
            {
                bits1[0] = 0;
            }

            if (checksumDecimal >= 8)
            {
                bits2[2] = 1;
                checksumDecimal -= 8;
            }
            else
            {
                bits2[2] = 0;
            }

            if (checksumDecimal >= 4)
            {
                bits3[0] = 1;
                checksumDecimal -= 4;
            }
            else
            {
                bits3[0] = 0;
            }

            if (checksumDecimal >= 2)
            {
                bits4[2] = 1;
                checksumDecimal -= 2;
            }
            else
            {
                bits4[2] = 0;
            }

            if (checksumDecimal >= 1)
            {
                bits5[0] = 1;
                checksumDecimal -= 1;
            }
            else
            {
                bits5[0] = 0;
            }
            #endregion

            #region Unassigned
            bits6[2] = 0;
            bits7[0] = 0;
            bits10[1] = 0;
            bits10[2] = 0;
            #endregion

            #region Wins
            if (numberOfWins >= 80)
            {
                bits1[1] = 1;
                numberOfWins -= 80;
            }
            else
            {
                bits1[1] = 0;
            }

            if (numberOfWins >= 40)
            {
                bits1[2] = 1;
                numberOfWins -= 40;
            }
            else
            {
                bits1[2] = 0;
            }

            if (numberOfWins >= 20)
            {
                bits4[0] = 1;
                numberOfWins -= 20;
            }
            else
            {
                bits4[0] = 0;
            }

            if (numberOfWins >= 10)
            {
                bits4[1] = 1;
                numberOfWins -= 10;
            }
            else
            {
                bits4[1] = 0;
            }

            if (numberOfWins >= 8)
            {
                bits7[1] = 1;
                numberOfWins -= 8;
            }
            else
            {
                bits7[1] = 0;
            }

            if (numberOfWins >= 4)
            {
                bits7[2] = 1;
                numberOfWins -= 4;
            }
            else
            {
                bits7[2] = 0;
            }

            if (numberOfWins >= 2)
            {
                bits6[0] = 1;
                numberOfWins -= 2;
            }
            else
            {
                bits6[0] = 0;
            }

            if (numberOfWins >= 1)
            {
                bits6[1] = 1;
                numberOfWins -= 1;
            }
            else
            {
                bits6[1] = 0;
            }
            #endregion

            #region Losses
            if (numberOfLosses == 2)
            {
                bits8[2] = 1;
                numberOfLosses -= 2;
            }
            else
            {
                bits8[2] = 0;
            }

            if (numberOfLosses == 1)
            {
                bits9[0] = 1;
                numberOfLosses -= 1;
            }
            else
            {
                bits9[0] = 0;
            }
            #endregion

            #region KOs
            if (numberOfKOs >= 80)
            {
                bits5[1] = 1;
                numberOfKOs -= 80;
            }
            else
            {
                bits5[1] = 0;
            }

            if (numberOfKOs >= 40)
            {
                bits5[2] = 1;
                numberOfKOs -= 40;
            }
            else
            {
                bits5[2] = 0;
            }

            if (numberOfKOs >= 20)
            {
                bits8[0] = 1;
                numberOfKOs -= 20;
            }
            else
            {
                bits8[0] = 0;
            }

            if (numberOfKOs >= 10)
            {
                bits8[1] = 1;
                numberOfKOs -= 10;
            }
            else
            {
                bits8[1] = 0;
            }

            if (numberOfKOs >= 8)
            {
                bits3[1] = 1;
                numberOfKOs -= 8;
            }
            else
            {
                bits3[1] = 0;
            }

            if (numberOfKOs >= 4)
            {
                bits3[2] = 1;
                numberOfKOs -= 4;
            }
            else
            {
                bits3[2] = 0;
            }

            if (numberOfKOs >= 2)
            {
                bits2[0] = 1;
                numberOfKOs -= 2;
            }
            else
            {
                bits2[0] = 0;
            }

            if (numberOfKOs >= 1)
            {
                bits2[1] = 1;
                numberOfKOs -= 1;
            }
            else
            {
                bits2[1] = 0;
            }
            #endregion

            #region Title
            if (title == 2)
            {
                bits9[1] = 1;
            }
            else
            {
                bits9[1] = 0;
            }

            if (title == 1)
            {
                bits9[2] = 1;
            }
            else
            {
                bits9[2] = 0;
            }
            #endregion
            
            #region Password
            int code1 = ((Convert.ToInt32(bits1[0].ToString() + bits1[1].ToString() + bits1[2].ToString(), 2)) + baseCode[0]) % 10;
            int code2 = ((Convert.ToInt32(bits2[0].ToString() + bits2[1].ToString() + bits2[2].ToString(), 2)) + baseCode[1]) % 10;
            int code3 = ((Convert.ToInt32(bits3[0].ToString() + bits3[1].ToString() + bits3[2].ToString(), 2)) + baseCode[2]) % 10;
            int code4 = ((Convert.ToInt32(bits4[0].ToString() + bits4[1].ToString() + bits4[2].ToString(), 2)) + baseCode[3]) % 10;
            int code5 = ((Convert.ToInt32(bits5[0].ToString() + bits5[1].ToString() + bits5[2].ToString(), 2)) + baseCode[4]) % 10;
            int code6 = ((Convert.ToInt32(bits6[0].ToString() + bits6[1].ToString() + bits6[2].ToString(), 2)) + baseCode[5]) % 10;
            int code7 = ((Convert.ToInt32(bits7[0].ToString() + bits7[1].ToString() + bits7[2].ToString(), 2)) + baseCode[6]) % 10;
            int code8 = ((Convert.ToInt32(bits8[0].ToString() + bits8[1].ToString() + bits8[2].ToString(), 2)) + baseCode[7]) % 10;
            int code9 = ((Convert.ToInt32(bits9[0].ToString() + bits9[1].ToString() + bits9[2].ToString(), 2)) + baseCode[8]) % 10;
            int code10 = ((Convert.ToInt32(bits10[0].ToString() + bits10[1].ToString() + bits10[2].ToString(), 2)) + baseCode[9]) % 10;

            textBoxPassword.Text = code1.ToString() + code2.ToString() + code3.ToString() + " " + code4.ToString() + code5.ToString() + code6.ToString() + " " + code7.ToString() + code8.ToString() + code9.ToString() + code10.ToString();
            #endregion

        }

        /**
         * TABLE II. (Base code: 635 793 1420)
         * 
         * +-------------+-------------+-------------+
         * |     Wins +80|     Wins +40|        KO +2|
         * |        KO +1|  Checksum +8|  Checksum +4|
         * |        KO +8|        KO +4|     Wins +20|
         * |             |             |             |
         * |     Wins +10|  Checksum +2|  Checksum +1|
         * |       KO +80|       KO +40|      Wins +2|
         * |      Wins +1|XXXXXXXXXXXXX|XXXXXXXXXXXXX|
         * |             |             |             |
         * |      Wins +8|      Wins +4|       KO +20|
         * |       KO +10|    Losses +2|    Losses +1|
         * |     Title +2|     Title +1| Checksum +32|
         * | Checksum +16|XXXXXXXXXXXXX|XXXXXXXXXXXXX|
         * +-------------+-------------+-------------+
         **/
            private void calcUsingTable2(int numberOfWins, int numberOfLosses, int numberOfKOs, int title)
        {
            int[] baseCode = { 6, 3, 5, 7, 9, 3, 1, 4, 2, 0 };
            int[] bits1 = new int[3];
            int[] bits2 = new int[3];
            int[] bits3 = new int[3];

            int[] bits4 = new int[3];
            int[] bits5 = new int[3];
            int[] bits6 = new int[3];

            int[] bits7 = new int[3];
            int[] bits8 = new int[3];
            int[] bits9 = new int[3];
            int[] bits10 = new int[3];

            #region Checksum
            // add wins, losses, and KOs
            int numberOfWinsDigit1 = 0;
            int numberOfWinsDigit2 = 0;
            int numberOfKOsDigit1 = 0;
            int numberOfKOsDigit2 = 0;

            if (numberOfWins >= 10)
            {
                string numberOfWinsString1 = numberOfWins.ToString().Substring(0, 1);
                string numberOfWinsString2 = numberOfWins.ToString().Substring(1, 1);
                numberOfWinsDigit1 = Convert.ToInt32(numberOfWinsString1);
                numberOfWinsDigit2 = Convert.ToInt32(numberOfWinsString2);
            }
            else
            {
                numberOfWinsDigit1 = numberOfWins;
            }

            if (numberOfKOs >= 10)
            {
                string numberOfKOsString1 = numberOfKOs.ToString().Substring(0, 1);
                string numberOfKOsString2 = numberOfKOs.ToString().Substring(1, 1);
                numberOfKOsDigit1 = Convert.ToInt32(numberOfKOsString1);
                numberOfKOsDigit2 = Convert.ToInt32(numberOfKOsString2);
            }
            else
            {
                numberOfKOsDigit1 = numberOfKOs;
            }

            int winLossKOTotal = numberOfWinsDigit1 + numberOfWinsDigit2 + numberOfLosses + numberOfKOsDigit1 + numberOfKOsDigit2;
            int checksumDecimal = MAGIC_NUMBER - winLossKOTotal;

            if (checksumDecimal >= 32)
            {
                bits9[2] = 1;
                checksumDecimal -= 32;
            }
            else
            {
                bits9[2] = 0;
            }

            if (checksumDecimal >= 16)
            {
                bits10[0] = 1;
                checksumDecimal -= 16;
            }
            else
            {
                bits10[0] = 0;
            }

            if (checksumDecimal >= 8)
            {
                bits2[1] = 1;
                checksumDecimal -= 8;
            }
            else
            {
                bits2[1] = 0;
            }

            if (checksumDecimal >= 4)
            {
                bits2[2] = 1;
                checksumDecimal -= 4;
            }
            else
            {
                bits2[2] = 0;
            }

            if (checksumDecimal >= 2)
            {
                bits4[1] = 1;
                checksumDecimal -= 2;
            }
            else
            {
                bits4[1] = 0;
            }

            if (checksumDecimal >= 1)
            {
                bits4[2] = 1;
                checksumDecimal -= 1;
            }
            else
            {
                bits4[2] = 0;
            }
            #endregion

            #region Unassigned
            bits6[1] = 0;
            bits6[2] = 0;
            bits10[1] = 0;
            bits10[2] = 0;
            #endregion

            #region Wins
            if (numberOfWins >= 80)
            {
                bits1[0] = 1;
                numberOfWins -= 80;
            }
            else
            {
                bits1[0] = 0;
            }

            if (numberOfWins >= 40)
            {
                bits1[1] = 1;
                numberOfWins -= 40;
            }
            else
            {
                bits1[1] = 0;
            }

            if (numberOfWins >= 20)
            {
                bits3[2] = 1;
                numberOfWins -= 20;
            }
            else
            {
                bits3[2] = 0;
            }

            if (numberOfWins >= 10)
            {
                bits4[0] = 1;
                numberOfWins -= 10;
            }
            else
            {
                bits4[0] = 0;
            }

            if (numberOfWins >= 8)
            {
                bits7[0] = 1;
                numberOfWins -= 8;
            }
            else
            {
                bits7[0] = 0;
            }

            if (numberOfWins >= 4)
            {
                bits7[1] = 1;
                numberOfWins -= 4;
            }
            else
            {
                bits7[1] = 0;
            }

            if (numberOfWins >= 2)
            {
                bits5[2] = 1;
                numberOfWins -= 2;
            }
            else
            {
                bits5[2] = 0;
            }

            if (numberOfWins >= 1)
            {
                bits6[0] = 1;
                numberOfWins -= 1;
            }
            else
            {
                bits6[0] = 0;
            }
            #endregion

            #region Losses
            if (numberOfLosses == 2)
            {
                bits8[1] = 1;
                numberOfLosses -= 2;
            }
            else
            {
                bits8[1] = 0;
            }

            if (numberOfLosses == 1)
            {
                bits8[2] = 1;
                numberOfLosses -= 1;
            }
            else
            {
                bits8[2] = 0;
            }
            #endregion

            #region KOs
            if (numberOfKOs >= 80)
            {
                bits5[0] = 1;
                numberOfKOs -= 80;
            }
            else
            {
                bits5[0] = 0;
            }

            if (numberOfKOs >= 40)
            {
                bits5[1] = 1;
                numberOfKOs -= 40;
            }
            else
            {
                bits5[1] = 0;
            }

            if (numberOfKOs >= 20)
            {
                bits7[2] = 1;
                numberOfKOs -= 20;
            }
            else
            {
                bits7[2] = 0;
            }

            if (numberOfKOs >= 10)
            {
                bits8[0] = 1;
                numberOfKOs -= 10;
            }
            else
            {
                bits8[0] = 0;
            }

            if (numberOfKOs >= 8)
            {
                bits3[0] = 1;
                numberOfKOs -= 8;
            }
            else
            {
                bits3[0] = 0;
            }

            if (numberOfKOs >= 4)
            {
                bits3[1] = 1;
                numberOfKOs -= 4;
            }
            else
            {
                bits3[1] = 0;
            }

            if (numberOfKOs >= 2)
            {
                bits1[2] = 1;
                numberOfKOs -= 2;
            }
            else
            {
                bits1[2] = 0;
            }

            if (numberOfKOs >= 1)
            {
                bits1[0] = 1;
                numberOfKOs -= 1;
            }
            else
            {
                bits1[0] = 0;
            }
            #endregion

            #region Title
            if (title == 2)
            {
                bits9[0] = 1;
            }
            else
            {
                bits9[0] = 0;
            }

            if (title == 1)
            {
                bits9[1] = 1;
            }
            else
            {
                bits9[1] = 0;
            }
            #endregion
            
            #region Password
            int code1 = ((Convert.ToInt32(bits1[0].ToString() + bits1[1].ToString() + bits1[2].ToString(), 2)) + baseCode[0]) % 10;
            int code2 = ((Convert.ToInt32(bits2[0].ToString() + bits2[1].ToString() + bits2[2].ToString(), 2)) + baseCode[1]) % 10;
            int code3 = ((Convert.ToInt32(bits3[0].ToString() + bits3[1].ToString() + bits3[2].ToString(), 2)) + baseCode[2]) % 10;
            int code4 = ((Convert.ToInt32(bits4[0].ToString() + bits4[1].ToString() + bits4[2].ToString(), 2)) + baseCode[3]) % 10;
            int code5 = ((Convert.ToInt32(bits5[0].ToString() + bits5[1].ToString() + bits5[2].ToString(), 2)) + baseCode[4]) % 10;
            int code6 = ((Convert.ToInt32(bits6[0].ToString() + bits6[1].ToString() + bits6[2].ToString(), 2)) + baseCode[5]) % 10;
            int code7 = ((Convert.ToInt32(bits7[0].ToString() + bits7[1].ToString() + bits7[2].ToString(), 2)) + baseCode[6]) % 10;
            int code8 = ((Convert.ToInt32(bits8[0].ToString() + bits8[1].ToString() + bits8[2].ToString(), 2)) + baseCode[7]) % 10;
            int code9 = ((Convert.ToInt32(bits9[0].ToString() + bits9[1].ToString() + bits9[2].ToString(), 2)) + baseCode[8]) % 10;
            int code10 = ((Convert.ToInt32(bits10[0].ToString() + bits10[1].ToString() + bits10[2].ToString(), 2)) + baseCode[9]) % 10;

            textBoxPassword.Text = code1.ToString() + code2.ToString() + code3.ToString() + " " + code4.ToString() + code5.ToString() + code6.ToString() + " " + code7.ToString() + code8.ToString() + code9.ToString() + code10.ToString();
            #endregion
        }

        /**
         * TABLE III. (Base code: 635 790 7428)
         * 
         * +-------------+-------------+-------------+
         * | Checksum +32| Checksum +16|     Wins +80|
         * |     Wins +40|        KO +2|        KO +1|
         * |  Checksum +8|  Checksum +4|        KO +8|
         * |             |             |             |
         * |        KO +4|     Wins +20|     Wins +10|
         * |  Checksum +2|  Checksum +1|       KO +80|
         * |       KO +40|      Wins +2|      Wins +1|
         * |             |             |             |
         * |XXXXXXXXXXXXX|XXXXXXXXXXXXX|      Wins +8|
         * |      Wins +4|       KO +20|       KO +10|
         * |    Losses +2|    Losses +1|     Title +2|
         * |     Title +1|XXXXXXXXXXXXX|XXXXXXXXXXXXX|
         * +-------------+-------------+-------------+
         **/
        private void calcUsingTable3(int numberOfWins, int numberOfLosses, int numberOfKOs, int title)
        {
            int[] baseCode = { 6, 3, 5, 7, 9, 0, 7, 4, 2, 8 };
            int[] bits1 = new int[3];
            int[] bits2 = new int[3];
            int[] bits3 = new int[3];

            int[] bits4 = new int[3];
            int[] bits5 = new int[3];
            int[] bits6 = new int[3];

            int[] bits7 = new int[3];
            int[] bits8 = new int[3];
            int[] bits9 = new int[3];
            int[] bits10 = new int[3];

            #region Checksum
            // add wins, losses, and KOs
            int numberOfWinsDigit1 = 0;
            int numberOfWinsDigit2 = 0;
            int numberOfKOsDigit1 = 0;
            int numberOfKOsDigit2 = 0;

            if (numberOfWins >= 10)
            {
                string numberOfWinsString1 = numberOfWins.ToString().Substring(0, 1);
                string numberOfWinsString2 = numberOfWins.ToString().Substring(1, 1);
                numberOfWinsDigit1 = Convert.ToInt32(numberOfWinsString1);
                numberOfWinsDigit2 = Convert.ToInt32(numberOfWinsString2);
            }
            else
            {
                numberOfWinsDigit1 = numberOfWins;
            }

            if (numberOfKOs >= 10)
            {
                string numberOfKOsString1 = numberOfKOs.ToString().Substring(0, 1);
                string numberOfKOsString2 = numberOfKOs.ToString().Substring(1, 1);
                numberOfKOsDigit1 = Convert.ToInt32(numberOfKOsString1);
                numberOfKOsDigit2 = Convert.ToInt32(numberOfKOsString2);
            }
            else
            {
                numberOfKOsDigit1 = numberOfKOs;
            }

            int winLossKOTotal = numberOfWinsDigit1 + numberOfWinsDigit2 + numberOfLosses + numberOfKOsDigit1 + numberOfKOsDigit2;
            int checksumDecimal = MAGIC_NUMBER - winLossKOTotal;

            if (checksumDecimal >= 32)
            {
                bits1[0] = 1;
                checksumDecimal -= 32;
            }
            else
            {
                bits1[0] = 0;
            }

            if (checksumDecimal >= 16)
            {
                bits1[1] = 1;
                checksumDecimal -= 16;
            }
            else
            {
                bits1[1] = 0;
            }

            if (checksumDecimal >= 8)
            {
                bits3[0] = 1;
                checksumDecimal -= 8;
            }
            else
            {
                bits3[0] = 0;
            }

            if (checksumDecimal >= 4)
            {
                bits3[1] = 1;
                checksumDecimal -= 4;
            }
            else
            {
                bits3[1] = 0;
            }

            if (checksumDecimal >= 2)
            {
                bits5[0] = 1;
                checksumDecimal -= 2;
            }
            else
            {
                bits5[0] = 0;
            }

            if (checksumDecimal >= 1)
            {
                bits5[1] = 1;
                checksumDecimal -= 1;
            }
            else
            {
                bits5[1] = 0;
            }
            #endregion

            #region Unassigned
            bits7[0] = 0;
            bits7[1] = 0;
            bits10[1] = 0;
            bits10[2] = 0;
            #endregion

            #region Wins
            if (numberOfWins >= 80)
            {
                bits1[2] = 1;
                numberOfWins -= 80;
            }
            else
            {
                bits1[2] = 0;
            }

            if (numberOfWins >= 40)
            {
                bits2[0] = 1;
                numberOfWins -= 40;
            }
            else
            {
                bits2[0] = 0;
            }

            if (numberOfWins >= 20)
            {
                bits4[1] = 1;
                numberOfWins -= 20;
            }
            else
            {
                bits4[1] = 0;
            }

            if (numberOfWins >= 10)
            {
                bits4[2] = 1;
                numberOfWins -= 10;
            }
            else
            {
                bits4[2] = 0;
            }

            if (numberOfWins >= 8)
            {
                bits7[2] = 1;
                numberOfWins -= 8;
            }
            else
            {
                bits7[2] = 0;
            }

            if (numberOfWins >= 4)
            {
                bits8[0] = 1;
                numberOfWins -= 4;
            }
            else
            {
                bits8[0] = 0;
            }

            if (numberOfWins >= 2)
            {
                bits6[1] = 1;
                numberOfWins -= 2;
            }
            else
            {
                bits6[1] = 0;
            }

            if (numberOfWins >= 1)
            {
                bits6[2] = 1;
                numberOfWins -= 1;
            }
            else
            {
                bits6[2] = 0;
            }
            #endregion

            #region Losses
            if (numberOfLosses == 2)
            {
                bits9[0] = 1;
                numberOfLosses -= 2;
            }
            else
            {
                bits9[0] = 0;
            }

            if (numberOfLosses == 1)
            {
                bits9[1] = 1;
                numberOfLosses -= 1;
            }
            else
            {
                bits9[1] = 0;
            }
            #endregion

            #region KOs
            if (numberOfKOs >= 80)
            {
                bits5[2] = 1;
                numberOfKOs -= 80;
            }
            else
            {
                bits5[2] = 0;
            }

            if (numberOfKOs >= 40)
            {
                bits6[0] = 1;
                numberOfKOs -= 40;
            }
            else
            {
                bits6[0] = 0;
            }

            if (numberOfKOs >= 20)
            {
                bits8[1] = 1;
                numberOfKOs -= 20;
            }
            else
            {
                bits8[1] = 0;
            }

            if (numberOfKOs >= 10)
            {
                bits8[2] = 1;
                numberOfKOs -= 10;
            }
            else
            {
                bits8[2] = 0;
            }

            if (numberOfKOs >= 8)
            {
                bits3[2] = 1;
                numberOfKOs -= 8;
            }
            else
            {
                bits3[2] = 0;
            }

            if (numberOfKOs >= 4)
            {
                bits4[0] = 1;
                numberOfKOs -= 4;
            }
            else
            {
                bits4[0] = 0;
            }

            if (numberOfKOs >= 2)
            {
                bits2[1] = 1;
                numberOfKOs -= 2;
            }
            else
            {
                bits2[1] = 0;
            }

            if (numberOfKOs >= 1)
            {
                bits2[2] = 1;
                numberOfKOs -= 1;
            }
            else
            {
                bits2[2] = 0;
            }
            #endregion

            #region Title
            if (title == 2)
            {
                bits9[2] = 1;
            }
            else
            {
                bits9[2] = 0;
            }

            if (title == 1)
            {
                bits10[0] = 1;
            }
            else
            {
                bits10[0] = 0;
            }
            #endregion
            
            #region Password
            int code1 = ((Convert.ToInt32(bits1[0].ToString() + bits1[1].ToString() + bits1[2].ToString(), 2)) + baseCode[0]) % 10;
            int code2 = ((Convert.ToInt32(bits2[0].ToString() + bits2[1].ToString() + bits2[2].ToString(), 2)) + baseCode[1]) % 10;
            int code3 = ((Convert.ToInt32(bits3[0].ToString() + bits3[1].ToString() + bits3[2].ToString(), 2)) + baseCode[2]) % 10;
            int code4 = ((Convert.ToInt32(bits4[0].ToString() + bits4[1].ToString() + bits4[2].ToString(), 2)) + baseCode[3]) % 10;
            int code5 = ((Convert.ToInt32(bits5[0].ToString() + bits5[1].ToString() + bits5[2].ToString(), 2)) + baseCode[4]) % 10;
            int code6 = ((Convert.ToInt32(bits6[0].ToString() + bits6[1].ToString() + bits6[2].ToString(), 2)) + baseCode[5]) % 10;
            int code7 = ((Convert.ToInt32(bits7[0].ToString() + bits7[1].ToString() + bits7[2].ToString(), 2)) + baseCode[6]) % 10;
            int code8 = ((Convert.ToInt32(bits8[0].ToString() + bits8[1].ToString() + bits8[2].ToString(), 2)) + baseCode[7]) % 10;
            int code9 = ((Convert.ToInt32(bits9[0].ToString() + bits9[1].ToString() + bits9[2].ToString(), 2)) + baseCode[8]) % 10;
            int code10 = ((Convert.ToInt32(bits10[0].ToString() + bits10[1].ToString() + bits10[2].ToString(), 2)) + baseCode[9]) % 10;

            textBoxPassword.Text = code1.ToString() + code2.ToString() + code3.ToString() + " " + code4.ToString() + code5.ToString() + code6.ToString() + " " + code7.ToString() + code8.ToString() + code9.ToString() + code10.ToString();
            #endregion
        }
    }
}
