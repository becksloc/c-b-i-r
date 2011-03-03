using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Image_Processing_Library
{
    public class FeatureInfo
    {
        string m_BitSequence; //xâu nhị phân 0 & 1
        int m_MinorAxis; //Trục phụ (độ cao của ảnh), để kiểm tra
        string m_ImagePath; //Đường dẫn tới file ảnh

        public FeatureInfo()
        {

        }

        public FeatureInfo(string bitSequence, int minorAxis, string imagePath)
        {
            m_BitSequence = bitSequence;
            m_MinorAxis = minorAxis;
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

        public int MinorAxis
        {
            get
            {
                return m_MinorAxis;
            }
            set
            {
                m_MinorAxis = value;
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
