﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.Global;

namespace IRAP_FVS_SPCO.XBarR
{
    /// <summary>
    /// XBar-R 的判定准则
    /// </summary>
    public class XBarRCriteria
    {
        private Quantity ucl;
        private Quantity highLimitA;
        private Quantity highLimitB;
        private Quantity middle;
        private Quantity lowLimitB;
        private Quantity lowLimitA;
        private Quantity lcl;

        private bool criteria1Judged = false;
        private bool criteria2Judged = false;
        private bool criteria3Judged = false;
        private bool criteria4Judged = false;
        private bool criteria5Judged = false;
        private bool criteria6Judged = false;
        private bool criteria7Judged = false;
        private bool criteria8Judged = false;

        public XBarRCriteria(
            Quantity lcl,
            Quantity ucl,
            int rule)
        {
            this.ucl = ucl;
            this.lcl = lcl;
            highLimitA = ucl.Clone();
            highLimitA.IntValue = 0;
            highLimitB = highLimitA.Clone();
            middle = highLimitA.Clone();
            lowLimitB = highLimitA.Clone();
            lowLimitA = highLimitA.Clone();

            double splitter = (ucl.DoubleValue - lcl.DoubleValue) / 6;
            highLimitA.DoubleValue = ucl.DoubleValue - splitter;
            highLimitB.DoubleValue = ucl.DoubleValue - splitter * 2;
            lowLimitB.DoubleValue = lcl.DoubleValue + splitter * 2;
            lowLimitA.DoubleValue = lcl.DoubleValue + splitter;
            middle.DoubleValue = (ucl.DoubleValue + lcl.DoubleValue) / 2;

            criteria1Judged = (rule & 1) == 1;
            criteria2Judged = (rule & 2) == 2;
            criteria3Judged = (rule & 4) == 4;
            criteria4Judged = (rule & 8) == 8;
            criteria5Judged = (rule & 16) == 16;
            criteria6Judged = (rule & 32) == 32;
            criteria7Judged = (rule & 64) == 64;
            criteria8Judged = (rule & 128) == 128;
        }

        /// <summary>
        /// 准则1:1点落在A区以外
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool Criteria1Passed(long point)
        {
            if (criteria1Judged)
                return point <= ucl.IntValue && point >= lcl.IntValue;
            else
                return true;
        }

        /// <summary>
        /// 准则2：连续6点递增或递减
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public bool Criteria2Passed(List<long> points)
        {
            if (!criteria2Judged)
                return true;
            if (points.Count < 6)
                return true;

            int increasing = 0;
            int decreasing = 0;
            int equation = 0;
            for (int i = 0; i < 5; i++)
            {
                if (points[i] < points[i + 1])
                    increasing++;
                else if (points[i] > points[i + 1])
                    decreasing++;
                else
                    equation++;
            }

            if (increasing == 0 && decreasing == 0)
                return true;
            else if (increasing != 0 && decreasing != 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 准则3：连续7点落在中心线同一侧
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public bool Criteria3Passed(List<long> points)
        {
            if (!criteria3Judged)
                return true;
            if (points.Count < 7)
                return true;

            int cntOfHighArea = 0;
            int cntOfLowArea = 0;
            for (int i = 0; i < 7; i++)
            {
                if (points[i] > middle.IntValue)
                    cntOfHighArea++;
                else if (points[i] < middle.IntValue)
                    cntOfLowArea++;
            }

            if (cntOfHighArea == 7 || cntOfLowArea == 7)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 准则4：连续14点中相邻点交替上下
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public bool Criteria4Passed(List<long> points)
        {
            if (!criteria4Judged)
                return true;
            if (points.Count < 14)
                return true;

            for (int i = 0; i < 12; i++)
            {
                if ((points[i] - points[i + 1]) *
                    (points[i + 1] - points[i + 2]) >= 0)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 准则5：连续3点中有2点落在中心线同一侧的B区以外，如果最后一点落在B区内则不算
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public bool Criteria5Passed(List<long> points)
        {
            if (!criteria5Judged)
                return true;
            if (points.Count < 3)
                return true;

            int cntOfHighAreaA = 0;
            int cntOfLowAreaA = 0;
            for (int i = 0; i < 3; i++)
            {
                if (points[i] > highLimitA.IntValue)
                    cntOfHighAreaA++;
                if (points[i] < lowLimitA.IntValue)
                    cntOfLowAreaA++;
            }

            if ((cntOfHighAreaA >= 2 ||
                cntOfLowAreaA >= 2) &&
                (points[2] > highLimitA.IntValue ||
                points[2] < lowLimitA.IntValue))
                return false;
            else
                return true;
        }

        /// <summary>
        /// 准则6：连续5点中有4点落在中心线同一侧的C区以外
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public bool Criteria6Passed(List<long> points)
        {
            if (!criteria6Judged)
                return true;
            if (points.Count < 5)
                return true;

            int cntOfHighArea = 0;
            int cntOfLowArea = 0;
            for (int i = 0; i < 5; i++)
            {
                if (points[i] > highLimitB.IntValue)
                    cntOfHighArea++;
                if (points[i] < lowLimitB.IntValue)
                    cntOfLowArea++;
            }

            if (cntOfHighArea >= 4 || cntOfLowArea >= 4)
                return false;
            else
                return true;
        }
        
        /// <summary>
        /// 准则7：连续15点落在中心线两侧的C区之内
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public bool Criteria7Passed(List<long> points)
        {
            if (!criteria7Judged)
                return true;
            if (points.Count < 15)
                return true;

            int cntOfPerfectArea = 0;
            for (int i = 0; i < 15; i++)
            {
                if (points[i] <= highLimitB.IntValue &&
                    points[i] >= lowLimitB.IntValue)
                    cntOfPerfectArea++;
            }

            return cntOfPerfectArea != 15;
        }

        /// <summary>
        /// 准则8：连续8点落在中心线两侧且无一在C区之内
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public bool Criteria8Passed(List<long> points)
        {
            if (!criteria8Judged)
                return true;
            if (points.Count < 8)
                return true;

            int cntOfOutPerfectArea = 0;
            for (int i = 0; i < 8; i++)
            {
                if (points[i] > highLimitB.IntValue ||
                    points[i] < lowLimitB.IntValue)
                    cntOfOutPerfectArea++;
            }

            return cntOfOutPerfectArea != 8;
        }
    }
}
