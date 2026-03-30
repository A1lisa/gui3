using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Температура, задаваемая в виде пары (значение, тип), допустимые типы:
градус Цельсия, градус Фаренгейта, градус Ранкина, Кельвины
сложение
вычитание
умножение на число
сравнение
вывод значения в любом типе*/
namespace gui3
{
    public enum MeasureType { C, F, Ra, K };

    public class Temperature
    {
        private double value;
        private MeasureType type;

        public Temperature(double value, MeasureType type)
        {
            this.value = value;
            this.type = type;
        }
        public string Verbose()
        {
            string typeVerbose = "";
            switch (this.type)
            {
                case MeasureType.C:
                    typeVerbose = "°C";
                    break;
                case MeasureType.F:
                    typeVerbose = "°F";
                    break;
                case MeasureType.Ra:
                    typeVerbose = "°Ra";
                    break;
                case MeasureType.K:
                    typeVerbose = "K";
                    break;
            }
            return String.Format("{0} {1}", Math.Round(this.value, 2), typeVerbose);
        }

        public Temperature To(MeasureType newType)
        {
            var newValue = this.value;
            if (this.type == MeasureType.K)
            {
                switch (newType)
                {
                    case MeasureType.K:
                        newValue = this.value;
                        break;
                    case MeasureType.C:
                        newValue = this.value - 273.15;
                        break;
                    case MeasureType.F:
                        newValue = this.value * 9.0 / 5.0 - 459.67;
                        break;
                    case MeasureType.Ra:
                        newValue = this.value * 9.0 / 5.0;
                        break;
                }
            }
 
            else if (newType == MeasureType.K)
            {
                switch (this.type)
                {
                    case MeasureType.K:
                        newValue = this.value;
                        break;
                    case MeasureType.C:
                        newValue = this.value + 273.15;
                        break;
                    case MeasureType.F:
                        newValue = (this.value + 459.67) * 5.0 / 9.0;
                        break;
                    case MeasureType.Ra:
                        newValue = this.value * 5.0 / 9.0;
                        break;
                }
            }
            else
            {
                newValue = this.To(MeasureType.K).To(newType).value;
            }

            return new Temperature(newValue, newType);
        }
        //число
        public static Temperature operator +(Temperature temp, double number)
        {
            var newValue = temp.value + number;
            var temperature = new Temperature(newValue, temp.type);
            return temperature;
        }
        public static Temperature operator +(double number, Temperature temp)
        {
            return temp + number;

        }

        public static Temperature operator *(Temperature temp, double number)
        {
            return new Temperature(temp.value * number, temp.type);
        }
        public static Temperature operator *(double number, Temperature temp)
        {
            return temp * number;
        }

        public static Temperature operator -(Temperature temp, double number)
        {
            return new Temperature(temp.value - number, temp.type);
        }
        public static Temperature operator -(double number, Temperature temp)
        {
            return temp - number;
        }

        public static Temperature operator /(Temperature temp, double number)
        {
            return new Temperature(temp.value / number, temp.type);
        }
        public static Temperature operator /(double number, Temperature temp)
        {
            return temp / number;
        }

        //между собой
        public static Temperature operator +(Temperature t1, Temperature t2)
        {
            return t1 + t2.To(t1.type).value;
        }

        public static Temperature operator -(Temperature t1, Temperature t2)
        {
            return t1 - t2.To(t1.type).value;
        }

        //сравнение
        public static bool operator ==(Temperature t1, Temperature t2)
        {
            return t1.To(MeasureType.K).value == t2.To(MeasureType.K).value;
        }

        public static bool operator !=(Temperature t1, Temperature t2)
        {
            return !(t1 == t2);
        }

        public static bool operator >(Temperature t1, Temperature t2)
        {
            return t1.To(MeasureType.K).value > t2.To(MeasureType.K).value;
        }
        public static bool operator <(Temperature t1, Temperature t2)
        {
            return t1.To(MeasureType.K).value < t2.To(MeasureType.K).value;
        }
    }
}
