using HomeWork_1.Attributes;
using System;
namespace HomeWork_1.CodeGenerator
{
    public class Company:BaseModel.BaseModel
    {
        [ColumnName("CreatorId")]
        public int CreatorId {get;set;}
        [ColumnName("LastModifierId")]
        public int LastModifierId {get;set;}
        [ColumnName("CreateTime")]
        public DateTime CreateTime {get;set;}
        [ColumnName("LastModifyTime")]
        public DateTime LastModifyTime {get;set;}
        [StateValidate(1, 5)]
        public string Name {get;set;}
    }
}

