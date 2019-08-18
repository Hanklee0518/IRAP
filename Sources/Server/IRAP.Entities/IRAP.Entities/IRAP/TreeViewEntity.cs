﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.IRAP
{
    /// <summary>
    /// 一般树视图实体对象
    /// </summary>
    public class TreeViewEntity
    {
        /// <summary>
        /// 分区键
        /// </summary>
        public long PartitioningKey { get; set; }
        /// <summary>
        /// 结点标识
        /// </summary>
        public int NodeID { get; set; }
        /// <summary>
        /// 树视图类型
        /// </summary>
        public int TreeViewType { get; set; }
        /// <summary>
        /// 结点类型
        /// </summary>
        public int NodeType { get; set; }
        /// <summary>
        /// 结点代码
        /// </summary>
        public string NodeCode { get; set; }
        /// <summary>
        /// 结点名称
        /// </summary>
        public string NodeName { get; set; }
        /// <summary>
        /// 父结点标识
        /// </summary>
        public int Parent { get; set; }
        /// <summary>
        /// 结点深度
        /// </summary>
        public int NodeDepth { get; set; }
        /// <summary>
        /// 权限控制点
        /// </summary>
        public int CSTRoot { get; set; }
        /// <summary>
        /// 自定义遍历序
        /// </summary>
        public double UDFOrdinal { get; set; }
        /// <summary>
        /// 结点状态
        /// </summary>
        public int NodeStatus { get; set; }
        /// <summary>
        /// 可访问性  0=不可选  1=可单选  2=可复选
        /// </summary>
        public int Accessibility { get; set; }
        /// <summary>
        /// 选中状态  0=未选中  1=已选中
        /// </summary>
        public int SelectStatus { get; set; }
        /// <summary>
        /// 第一检索码
        /// </summary>
        public string SearchCode1 { get; set; }
        /// <summary>
        /// 第二检索码
        /// </summary>
        public string SearchCode2 { get; set; }
        /// <summary>
        /// 助记码
        /// </summary>
        public string HelpMemoryCode { get; set; }
        /// <summary>
        /// 图标文件
        /// </summary>
        public string IconFile { get; set; }
        /// <summary>
        /// 图标图像
        /// </summary>
        public byte[] IconImage { get; set; }

        public TreeViewEntity Clone()
        {
            return MemberwiseClone() as TreeViewEntity;
        }
    }
}
