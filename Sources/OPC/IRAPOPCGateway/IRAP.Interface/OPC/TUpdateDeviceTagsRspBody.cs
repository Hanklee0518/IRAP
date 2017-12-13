﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using IRAP.Global;

namespace IRAP.Interface.OPC
{
    public class TUpdateDeviceTagsRspBody : TSoftlandBody
    {
        public string ExCode
        {
            get { return "UpdateDeviceTags"; }
        }
        public string ErrCode { get; set; }
        public string ErrText { get; set; }

        protected override XmlNode GenerateUserDefineNode()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode node = xml.CreateElement("Param");
            return IRAPXMLUtils.GenerateXMLAttribute(node, this);
        }
    }
}