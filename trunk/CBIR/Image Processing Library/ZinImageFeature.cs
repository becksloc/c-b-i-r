using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Image_Processing_Library
{
    public class FeatureInfo
    {
        string m_BitSequence; //xâu nhị phân 0 & 1
        int m_Eccentricity; //Tâm = tỉ lệ Major Axis / Minor Axis
        string m_ImagePath; //Đường dẫn tới file ảnh

        public FeatureInfo()
        {

        }

        public FeatureInfo(string bitSequence, int Eccentricity, string imagePath)
        {
            m_BitSequence = bitSequence;
            m_Eccentricity = Eccentricity;
            m_ImagePath = imagePath;
        }

        public string BitSequence
        {
            get
            {
                return m_BitSequence;
            }
            set
            {
                m_BitSequence = value;
            }
        }

        public int Eccentricity
        {
            get
            {
                return m_Eccentricity;
            }
            set
            {
                m_Eccentricity = value;
            }
        }

        public string ImagePath
        {
            get
            {
                return m_ImagePath;
            }
            set
            {
                m_ImagePath = value;
            }
        }
    }
}
