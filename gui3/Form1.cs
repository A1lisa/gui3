namespace gui3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var measureItems = new string[]
           {
                "°C",
                "°F",
                "°Ra",
                "K"
           };

            cmbFirstType.DataSource = new List<string>(measureItems);
            cmbSecondType.DataSource = new List<string>(measureItems);
            cmbResultType.DataSource = new List<string>(measureItems);
        }

        private MeasureType GetMeasureTemp(ComboBox comboBox)
        {
            MeasureType measureType;
            switch (comboBox.Text)
            {
                case "°C":
                    measureType = MeasureType.C;
                    break;
                case "°F":
                    measureType = MeasureType.F;
                    break;
                case "°Ra":
                    measureType = MeasureType.Ra;
                    break;
                case "K":
                    measureType = MeasureType.K;
                    break;
                default:
                    measureType = MeasureType.C;
                    break;
            }
            return measureType;
        }
        private void Calculate()
        {
            try
            {
                var firstValue = double.Parse(txtFirst.Text);
                var secondValue = double.Parse(txtSecond.Text);


                MeasureType firstType = GetMeasureTemp(cmbFirstType);
                MeasureType secondType = GetMeasureTemp(cmbSecondType);
                MeasureType resultType = GetMeasureTemp(cmbResultType);

                var firstTemp = new Temperature(firstValue, firstType);
                var secondTemp = new Temperature(secondValue, secondType);

                Temperature sumTemp;

                switch (cmbOperation.Text)
                {
                    case "+":
                        // если плюсик выбрали, то складываем
                        sumTemp = firstTemp + secondTemp;
                        break;
                    case "-":
                        // если минус, то вычитаем
                        sumTemp = firstTemp - secondTemp;
                        break;
                    default:
                        // а если что-то другое, то просто 0 выводим,
                        // такое маловероятно, но надо указать иначе не скомпилится
                        sumTemp = new Temperature(0, MeasureType.K);
                        break;
                }
                txtResult.Text = sumTemp.To(resultType).Verbose();
            }
            catch (FormatException)
            {

            }
        }
        private void txtFirst_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtSecond_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void cmbOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void cmbSecondType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void cmbResultType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }
    }
}

