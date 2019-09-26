using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace IRAP.Client.GUI.MESPDC.Actions
{
    public class PlaySoundAction : CustomAction, IUDFAction
    {
        string soundType = "";

        public PlaySoundAction(
            XmlNode actionParam, 
            ExtendEventHandler extendAction, 
            ref object tag)
            : base(actionParam, extendAction, ref tag)
        {
            soundType = actionParam.Attributes["SoundType"].Value;
        }

        public void DoAction()
        {
            switch (soundType)
            {
                case "Error":
                    IRAP.Global.Tools.Play(
                        Global.Resources.Properties.Resources.ALARM9);
                    break;
                default:
                    break;
            }
        }
    }

    public class PlaySoundFactory : CustomActionFactory, IUDFActionFactory
    {
        public IUDFAction CreateAction(
            XmlNode actionParams, 
            ExtendEventHandler extendAction, 
            ref object tag)
        {
            return new PlaySoundAction(actionParams, extendAction, ref tag);
        }
    }
}
