using System;
using System.Collections.Generic;

namespace AnnexMigration.SNKModel
{
    public partial class FUpfile
    {
        public int Id { get; set; }
        public string Caseno { get; set; }
        public int Materialid { get; set; }
        public string Materialname { get; set; }
        public int? Fileno { get; set; }
        public string Filename { get; set; }
        public string Filesize { get; set; }
        public string Filepath { get; set; }
        public DateTime Upfiletime { get; set; }
        public byte[] Filecontent { get; set; }
        public string Remark { get; set; }
        public int? Userid { get; set; }
        public string Uptype { get; set; }
        public string Downloadstatu { get; set; }
        public string Ftpkeyname { get; set; }
        public string 入库批次 { get; set; }
        public string Fileid { get; set; }
        public string 预编宗地代码 { get; set; }
    }
}
