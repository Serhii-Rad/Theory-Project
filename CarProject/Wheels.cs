using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject
{
    public class Wheeles
    {
        private string typeOfWheels;
        public Wheeles(TypeOfWheelsEnum type)
        {
            if (type == TypeOfWheelsEnum.Summer)
            {
                typeOfWheels = "Summer";
            }
            else if (type == TypeOfWheelsEnum.Winter)
            {
                typeOfWheels = "Winter";
            }
            else if (type == TypeOfWheelsEnum.Universal)
            {
                typeOfWheels = "Universal";
            }
        }
        public enum TypeOfWheelsEnum
        {
            Winter, Summer, Universal
        }
        public string TypeOfWheels
        {
            get
            {
                return typeOfWheels;
            }
        }
        public void ChangeWheelsType(TypeOfWheelsEnum newType)
        {
            if (newType == TypeOfWheelsEnum.Summer)
            {
                typeOfWheels = "Summer";
            }
            else if (newType == TypeOfWheelsEnum.Winter)
            {
                typeOfWheels = "Winter";
            }
            else if (newType == TypeOfWheelsEnum.Universal)
            {
                typeOfWheels = "Universal";
            }
        }
    }
}
