using System;
using System.Collections.Generic;

namespace AnnexMigration.SNKModel
{
    public partial class FCasematerial
    {
        public int Id { get; set; }
        public string Caseno { get; set; }
        public string Casetitle { get; set; }
        public int Tiid { get; set; }
        public string Aid { get; set; }
        public int? Materialid { get; set; }
        public string Materialname { get; set; }
        public string Subtype { get; set; }
        public int? Must { get; set; }
        public int? Original { get; set; }
        public int? Sign { get; set; }
        public int Orderid { get; set; }
        public string Remark { get; set; }
        public int? Filesource { get; set; }
        public int Copies { get; set; }
        public string 入库批次 { get; set; }
        public string 预编宗地代码 { get; set; }
    }
}
