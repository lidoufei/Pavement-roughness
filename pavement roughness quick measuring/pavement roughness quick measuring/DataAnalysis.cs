using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pavement_roughness_quick_measuring
{
    public partial class Form1 : Form
    {
        //均方根计算
        private double RMScalculate(double[] acc1)
        {

            double avg = 0;
            for (int i = 0; i < acc1.Length; i++)
            {
                acc1[i] = acc1[i] * 9.8 / 128;
                avg += acc1[i];
            }
            avg = avg / acc1.Length;
            double rms = 0;
            for (int i = 0; i < acc1.Length; i++)
            {
                rms += (acc1[i] - avg) * (acc1[i] - avg);
            }
            rms = Math.Sqrt(rms / acc1.Length);
            return rms;

        }

        private double IRI_calculate(double rms1,double rms2)
        {
            if (radioButton3.Checked)
            {
                double iri = a1 * rms1 + a2 * rms2 + c;
                return iri;
            }
            else
            {
                double iri = a1 * rms1 + a2 * rms2 + c;
                return iri;
            }
        }

        private double GetIRI()
        {
            double[] acc1 = new double[accdata1.Count];
            double[] acc2 = new double[accdata2.Count];
            for (int i = 0; i < accdata1.Count; i++)
            {
                acc1[i] = (accdata1[i])[2];
            }
            for (int i = 0; i < accdata2.Count; i++)
            {
                acc2[i] = (accdata2[i])[2];
            }
            double iri_result = IRI_calculate(RMScalculate(acc1), RMScalculate(acc2));
            return iri_result;

        }

        public double getDistance(GPSdata gd1, GPSdata gd2)
        {
            double lat1 = gd1.latitude;
            double lat2 = gd2.latitude;
            double log1 = gd1.longitude;
            double log2 = gd2.longitude;
            double radLat1 = lat1 * Math.PI / 180;
            double radLog1 = log1 * Math.PI / 180;
            double radLat2 = lat2 * Math.PI / 180;
            double radLog2 = log2 * Math.PI / 180;
            double r = 6380693.5;
            double dx = r * Math.Cos(radLat1) * Math.Abs(radLog1 - radLog2);
            double dy = r * Math.Abs(radLat1 - radLat2);
            double GPSDist = Math.Sqrt(dx * dx + dy * dy);
            if (GPSDist < 2.5)
                return 0;
            else
                return GPSDist;
        }

        private int IRILevel(double IRI)
        {
            int index = 10;
            for (int i = 0; i < 5; i++)
            {
                double upper = IRIThreshold[i];
                double lowwer = IRIThreshold[i + 1];
                if (IRI <= upper && IRI > lowwer)
                    index = i;     
            }
            return index;
            
        }

    }
}
