using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    [Serializable]
    public class PC
    {
        public string Mark { get; set; }
        public string SerialNumber { get; set; }
        public string ModelCP { get; set; }
        public string ModelGPU { get; set; }
        public bool IsOn { get; set; }

        #region ctor
        public PC()
        {
            IsOn = false;
        }

        public PC(string mark, string serialNumber, string modelCP, string modelGPU)
        {
            Mark = mark;
            SerialNumber = serialNumber;
            ModelCP = modelCP;
            ModelGPU = modelGPU;
        }
        #endregion

        #region Method
        public void ON()
        {
            IsOn = true;
        }

        public void OFF()
        {
            IsOn = false;
        }

        public void Reboot()
        {
            OFF();
            ON();
        }
        #endregion
    }
}
