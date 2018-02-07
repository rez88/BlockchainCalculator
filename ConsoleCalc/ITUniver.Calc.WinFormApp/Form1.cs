using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITUniver.Calc.WinFormApp
{
    public partial class Form1 : Form
    {

        private ConsoleCalc.Calc calc { get; set; }

        public class Operation
        {
            public string Name { get; set; }
            
        }

        public Form1()
        {
            InitializeComponent();
            
            #region Загрузка операций

            calc = new ConsoleCalc.Calc();
            var operations = calc.GetOperNames();
            List<string> op = new List<string>(operations);
            cbOperation.Items.Clear();
            cbOperation.Items.AddRange(op.ToArray());

            #endregion

            if (cbOperation.Text=="")
            {
                btnCalc.Enabled = false;
            }
            
        }



        private void btnLuck_Click(object sender, EventArgs e)
        {
            tbResult.Text = "Успех!";
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            // получить операцию
            var oper = $"{cbOperation.SelectedItem}";

            // получить данные
            var args = tbInput.Text
                .Trim()
                .Split(' ')
                .Select(str => Convert.ToDouble(str))
                .ToArray();

            // вычислить результат
            var result = calc.Exec(oper, args);

            // показать результат
            tbResult.Text = $"{result}";
        }

        private void cbOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbInput.Text == "")
            {
                btnCalc.Enabled = false;
            }
            else
            {
                btnCalc.Enabled = true;
            }
        }

        private void tbInput_ControlAdded(object sender, ControlEventArgs e)
        {
            if (cbOperation.Text == "")
            {
                btnCalc.Enabled = false;
            }
            else
            {
                btnCalc.Enabled = true;
            }

        }
    }
}
