using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Image_Processing_Library
{
    //Lop thao tac voi XML (luu du lieu vao  m_xmlDocument)
    public class FeatureController
    {
        private XmlDocument m_xmlDocument;
        private string m_filePath;

        private void createEmptyXMLDocument()
        {
            // Create a new DOM-based XML document
            m_xmlDocument = new XmlDocument();
            // Add the XML declaration
            XmlDeclaration dec = m_xmlDocument.CreateXmlDeclaration("1.0", "utf-8", "yes");
            m_xmlDocument.PrependChild(dec);
            // Add the root element
            XmlElement nodeElem = m_xmlDocument.CreateElement("FeatureDB");
            m_xmlDocument.AppendChild(nodeElem);
        }

        private XmlElement addTextElement(XmlDocument doc, XmlElement nodeParent, string strTag, string strValue)
        {
            // Create a new element with tag passed in
            XmlElement nodeElem = doc.CreateElement(strTag);
            // Create a text node using value passed in
            XmlText nodeText = doc.CreateTextNode(strValue);
            // Add the element as a child of parent passed in
            nodeParent.AppendChild(nodeElem);
            // Add the text node as a child of the new element
            nodeElem.AppendChild(nodeText);
            return nodeElem;
        }

        //Ham khoi tao (New & Edit)
        public FeatureController(string filePath)
        {
            //Khoi tao file XML
            m_filePath = filePath;

            createEmptyXMLDocument();
        }

        #region "Public Methods"

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// retrieves a Phao from the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public FeatureInfo Get(int FeatureID)
        {
            return null;   
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// retrieves a collection of Phaos from the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public List<FeatureInfo> GetAll()
        {
            List<FeatureInfo> listFeatureInfo = new List<FeatureInfo>();

            //LocNT: doc file XML vao List<ZinImageFeatureInfo>
            m_xmlDocument.Load(m_filePath);

            XmlElement root = m_xmlDocument.DocumentElement;
            //Lay danh sach cac Node level 1
            XmlNodeList nodeList1 = root.ChildNodes;

            XmlNode node1;
            XmlNodeList nodeList2;
            //Luu thong tin Level 1 vao List<ZinImageFeatureInfo>
            listFeatureInfo.Clear();
            for (int i = 0; i < nodeList1.Count; i++)
            {
                node1 = nodeList1.Item(i);
                nodeList2 = node1.ChildNodes;
                //Luu tung Node leaf vao ZinImageFeatureInfo
                FeatureInfo objFeatureInfo = new FeatureInfo();
                objFeatureInfo.BitSequence = nodeList2.Item(0).InnerText;
                objFeatureInfo.MinorAxis = Convert.ToInt32(nodeList2.Item(1).InnerText);
                objFeatureInfo.ImagePath = nodeList2.Item(2).InnerText;
                //Add vao List
                listFeatureInfo.Add(objFeatureInfo);
            }

            return listFeatureInfo;
        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        /// adds a new FeatureInfo to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public int Add(FeatureInfo objFeatureInfo)
        {
            //Tao 1 qua FeatureInfo hoa moi. Dua vao parent tag LUNG_LINH_SONG_HAN
            XmlElement nodeParent = m_xmlDocument.DocumentElement;
            XmlElement elemFeatureInfo = m_xmlDocument.CreateElement("FeatureInfo");
            nodeParent.AppendChild(elemFeatureInfo);
            //Them cac element cho node PHAO_HOA
            addTextElement(m_xmlDocument, elemFeatureInfo, "BitSequence", objFeatureInfo.BitSequence);
            addTextElement(m_xmlDocument, elemFeatureInfo, "MinorAxis", objFeatureInfo.MinorAxis.ToString());
            addTextElement(m_xmlDocument, elemFeatureInfo, "ImagePath", objFeatureInfo.ImagePath);

            return 0;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// saves a Phao to the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void Update(FeatureInfo objFeatureInfo)
        {
            
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// deletes a Phao from the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void Delete(FeatureInfo objFeatureInfo)
        {
            return;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Luu danh sach phao (m_xmlDoc) ra XML
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public void WriteXML()
        {
            m_xmlDocument.Save(m_filePath);

            return;
        }


        #endregion
    }
}
