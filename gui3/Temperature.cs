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
вывод значения в любом типе
4
Скорость заданная в виде пары (значение*/
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
            return String.Format("{0} {1}", this.value, typeVerbose);
        }

        public static Temperature operator+(Temperature temp, double number)
        {
            var newValue = temp.value + number;
            var temperature = new Temperature(newValue, temp.type);
            return temperature;
        }

        public static Temperature operator +(double number, Temperature temp) {
            return temp + number;

    }

    
}
