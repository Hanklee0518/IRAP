﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IndexDefrag
{
    public class IndexState
    {
        public IndexState(DBhelp Dbhelp, int IndexID,int PartionID, double Avg_fragmentation_in_percent, long Fragment_count)
        {
            dbhelp = Dbhelp;
            this.IndexID = IndexID;
            this.partionID = PartionID;
            this.Avg_fragmentation_in_percent = Avg_fragmentation_in_percent;
            this.Fragment_count = Fragment_count;
        }
        private int indexID;
        private int partionID;
        private double avg_fragmentation_in_percent;
        private long fragment_count;
        public DBhelp dbhelp;

        public int IndexID
        {
            get
            {
                return indexID;
            }

            set
            {
                indexID = value;
            }
        }

        public double Avg_fragmentation_in_percent
        {
            get
            {
                return avg_fragmentation_in_percent;
            }

            set
            {
                avg_fragmentation_in_percent = value;
            }
        }

        public long Fragment_count
        {
            get
            {
                return fragment_count;
            }

            set
            {
                fragment_count = value;
            }
        }

        public int PartionID
        {
            get
            {
                return partionID;
            }

            set
            {
                partionID = value;
            }
        }

        public void Defrag(int databaseid,int tableid,string tablename,CancellationToken cts)
        {
            if (cts.IsCancellationRequested)
            {
                return;
            }
            Debug.WriteLine("Defraging Table:" + tablename);
            ScanningTask.Instance.SetAccumTask(tablename + "/" + indexID);
            try
            {
                string sql = $"DBCC INDEXDEFRAG ({databaseid},{tableid},{indexID},{partionID})";// WITH NO_INFOMSGS
                string r =dbhelp.GetSingle(sql).ToString();
                Debug.WriteLine(r);
            }
            catch(Exception e)
            {
                throw e;
            }

        }
        

        public IndexState Clone()
        {
            return MemberwiseClone() as IndexState;
        }
    }
}
