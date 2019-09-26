using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using IRAP.Client.Global.GUI;
using IRAP.Entities.IRAP;
using IRAP.WCF.Client.Method;
using IRAP.Client.User;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using IRAP.Client.Global;
using System.Linq;
using System.IO;
using IRAP.Global;
using IRAP.Entities.MDM;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList;

namespace IRAP.Client.GUI.FVS
{
    public partial class frmProductWIUpload : frmCustomFuncBase
    {
        private List<TreeViewEntity> nodes = new List<TreeViewEntity>();
        private bool allowTreeLideNodeChanged = false;

        public frmProductWIUpload()
        {
            InitializeComponent();

            TWaitting.Instance.ShowWaitForm("正在初始化数据...");
            GetAllT102Entities();
            if (nodes.Count <= 5000)
            {
                InitTreeListNodes(nodes);
            }
            TWaitting.Instance.CloseWaitForm();
        }

        private void GetAllT102Entities()
        {
            nodes.Clear();

            int errCode = 0;
            string errText = "";
            IRAPTreeClient.Instance.sfn_TreeView(
                IRAPUser.Instance.CommunityID,
                102,
                IRAPUser.Instance.SysLogID,
                true,
                0,
                ref nodes,
                out errCode,
                out errText);
            if (errCode != 0)
            {
                XtraMessageBox.Show(
                    errText,
                    "出错啦",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void InitTreeListNodes(List<TreeViewEntity> datas)
        {
            tlProducts.Nodes.Clear();
            allowTreeLideNodeChanged = false;

            if (datas != null)
            {
                foreach (TreeViewEntity entity in datas)
                {
                    if (entity.NodeID >= 0)
                    {
                        continue;
                    }

                    TreeListNode node =
                        tlProducts.AppendNode(
                            new object[]
                            {
                            $"[{entity.NodeCode}]-{entity.NodeName}",
                            },
                            null);
                    node.Tag = entity;
                }
            }
            allowTreeLideNodeChanged = true;
            
            if (tlProducts.Nodes.Count <= 0)
            {
                tlProducts_FocusedNodeChanged(
                    tlProducts,
                    new FocusedNodeChangedEventArgs(null, null));
            }
            else
            {
                tlProducts.FocusedNode = tlProducts.Nodes[0];
                tlProducts_FocusedNodeChanged(
                    tlProducts,
                    new FocusedNodeChangedEventArgs(null, tlProducts.FocusedNode));
            }
        }

        private void AppendLog(string message)
        {
            if (tlLogs.Nodes.Count > 500)
            {
                tlLogs.Nodes.RemoveAt(0);
            }

            TreeListNode node = tlLogs.AppendNode(new object[] { message, }, null);
            tlLogs.FocusedNode = node;
        }

        private void edtFilterText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TWaitting.Instance.ShowWaitForm("正在过滤......");
                try
                {
                    if (edtFilterText.Text == "")
                    {
                        if (nodes.Count <= 5000)
                        {
                            InitTreeListNodes(nodes);
                        }
                        else
                        {
                            XtraMessageBox.Show(
                                "由于产品数量太多，因此不支持显示全部产品。请输入关键字来筛选产品",
                                "提示",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            InitTreeListNodes(null);
                        }
                    }
                    else
                    {
                        var rlt =
                            (from r in nodes
                             where r.NodeName.Contains(edtFilterText.Text) ||
                                r.NodeCode.Contains(edtFilterText.Text)
                             select r).ToList();
                        InitTreeListNodes(rlt);
                    }
                }
                finally
                {
                    TWaitting.Instance.CloseWaitForm();
                }
            }
        }

        private void tlProducts_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null && e.Node.Tag != null && allowTreeLideNodeChanged)
            {
                if (e.Node.Tag is TreeViewEntity)
                {
                    splitContainerControl2.Panel1.Text =
                        $"[{e.Node.GetDisplayText(0)}] 的工序列表";

                    TWaitting.Instance.ShowWaitForm("正在获取并加载工序列表...");
                    try
                    {
                        TreeViewEntity entity = e.Node.Tag as TreeViewEntity;
                        List<OperationOfAProduct> operations = new List<OperationOfAProduct>();
                        int errCode = 0;
                        string errText = "";

                        IRAPMDMClient.Instance.ufn_GetList_OperationsOfAProduct(
                            IRAPUser.Instance.CommunityID,
                            -entity.NodeID,
                            ref operations,
                            out errCode,
                            out errText);
                        if (errCode != 0)
                        {
                            XtraMessageBox.Show(
                                errText,
                                "出错啦",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            tlOperations.Nodes.Clear();

                            try
                            {
                                tlOperations.BeginUpdate();
                                foreach (OperationOfAProduct operation in operations)
                                {
                                    TreeListNode node =
                                        tlOperations.AppendNode(
                                            new object[]
                                            {
                                                $"[{operation.T216Code}]{operation.T216Name}",
                                            },
                                            null);
                                    node.Tag = operation;
                                }
                            }
                            finally
                            {
                                tlOperations.EndUpdate();

                            }
                        }
                    }
                    finally
                    {
                        TWaitting.Instance.CloseWaitForm();
                    }
                }
            }
            else
            {
                splitContainerControl2.Panel1.Text = "工序列表";
                tlOperations.BeginUpdate();
                tlOperations.Nodes.Clear();
                tlOperations.EndUpdate();
            }
        }

        private void edtUploadPath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            switch ((string)e.Button.Tag)
            {
                case "GetFileName":
                    using (OpenFileDialog dialog = new OpenFileDialog())
                    {
                        dialog.Title = "打开";
                        dialog.Filter =
                            "Microsoft Office Excel 文件(*.xls)|*.xls|" +
                            "Adobe PDF 文件(*.pdf)|*.pdf|" +
                            "JPEG 图片文件(*.jpg)|*.jpg";
                        dialog.CheckFileExists = true;
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            switch (Path.GetExtension(dialog.FileName).ToUpper())
                            {
                                case ".XLS":
                                case ".PDF":
                                case ".JPG":
                                    edtUploadPath.Text = dialog.FileName;
                                    break;
                                default:
                                    XtraMessageBox.Show(
                                        "现在只支持 Excel/PDF/JPG 格式的文件，其它格式的文件暂不支持",
                                        "提示",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                                    break;
                            }
                        }
                    }
                    break;
            }
        }

        private void edtUploadPath_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !File.Exists(edtUploadPath.Text);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            int versionNo = 0;
            string ipAddress = "";
            int port = 0;
            string userID = "";
            string userPWD = "";
            string remoteDirectory = "";
            string remoteFilePath = "";
            int errCode = 0;
            string errText = "";

            #region 从数据库中获取 FTP 登录信息，以及上传后的目标文件名
            if (tlProducts.FocusedNode == null ||
                tlProducts.FocusedNode.Tag == null)
            {
                XtraMessageBox.Show("未选择产品！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tlOperations.FocusedNode == null ||
                tlOperations.FocusedNode.Tag == null)
            {
                XtraMessageBox.Show("未选择工序！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (edtUploadPath.Text.Trim() == "" ||
                !File.Exists(edtUploadPath.Text.Trim()))
            {
                XtraMessageBox.Show("未指定上传的文件，或者指定的上传文件不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int t102LeafID = (tlProducts.FocusedNode.Tag as TreeViewEntity).NodeID * -1;
            int t216LeafID = (tlOperations.FocusedNode.Tag as OperationOfAProduct).T216LeafID;

            IRAPMDMClient.Instance.usp_WIUpLoad(
                IRAPUser.Instance.CommunityID,
                t102LeafID,
                t216LeafID,
                IRAPUser.Instance.SysLogID,
                out versionNo,
                out ipAddress,
                out port,
                out userID,
                out userPWD,
                out remoteDirectory,
                out remoteFilePath,
                out errCode,
                out errText);
            if (errCode != 0)
            {
                XtraMessageBox.Show(
                    errText,
                    "出错啦",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            else
            {
                string srcFileExt = Path.GetExtension(edtUploadPath.Text);
                string dstFileExt = Path.GetExtension(remoteFilePath);
                if (dstFileExt != srcFileExt)
                {
                    remoteFilePath = 
                        Path.GetFileNameWithoutExtension(remoteFilePath) + srcFileExt;
                }
            }
            #endregion

            try
            {
                //TWaitting.Instance.ShowWaitForm("登录FTP服务器...");
                //FTPClient client = new FTPClient(ipAddress, port, userID, userPWD);
                //if (!client.Connect())
                //{
                //    XtraMessageBox.Show(
                //        client.errormessage,
                //        "出错啦",
                //        MessageBoxButtons.OK,
                //        MessageBoxIcon.Error);
                //    return;
                //}

                //TWaitting.Instance.ShowWaitForm("切换FTP服务器的当前目录");
                //if (!client.ChangeDir(remoteDirectory))
                //{
                //    XtraMessageBox.Show(
                //        client.errormessage,
                //        "出错啦",
                //        MessageBoxButtons.OK,
                //        MessageBoxIcon.Error);
                //    return;
                //}

                FTPHelper client = new FTPHelper(ipAddress, userID, userPWD);

                TWaitting.Instance.ShowWaitForm("正在上传文件......");

                try
                {
                    if (
                        !client.Upload(
                            new FileInfo(edtUploadPath.Text),
                            $"{remoteDirectory}{remoteFilePath}"))
                    {
                        XtraMessageBox.Show(
                            "上传文件失败",
                            "出错啦",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception error)
                {
                    XtraMessageBox.Show(
                        error.Message,
                        "出错啦",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                //client.Disconnect();
            }
            finally
            {
                TWaitting.Instance.CloseWaitForm();
            }

            string message =
                $"文件上传完毕，原文件名[{Path.GetFileName(edtUploadPath.Text)}]" +
                $"更名为[{remoteFilePath}]，位于FTP服务器的[{remoteDirectory}]中";
            edtUploadPath.Text = "";

            XtraMessageBox.Show(
                message,
                "提示",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            AppendLog(message);
        }

        private void edtFilterText_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            switch (e.Button.Kind)
            {
                case ButtonPredefines.Delete:
                    edtFilterText.Text = "";
                    InitTreeListNodes(null);

                    break;
            }
        }
    }
}
