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
                        sumTemp = firstTemp + secondTemp;
                        break;
                    case "-":
                        sumTemp = firstTemp - secondTemp;
                        break;
                    case "*":
                        sumTemp = firstTemp*secondValue;
                        break;
                    case "/":
                        sumTemp = firstTemp / secondValue;
                        break;
                    default: 
                        sumTemp = new Temperature(0, MeasureType.K);
                        break;
                }
                txtResult.Text = sumTemp.To(resultType).Verbose();
            }
            catch (FormatException)
            {

            }
        }
      
        private void onValueChanged(object sender, EventArgs e)
        {
            Calculate();
        }
    }
}

