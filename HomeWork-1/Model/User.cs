using HomeWork_1.Attributes;
using System;
namespace HomeWork_1.CodeGenerator
{
    [TableName("User")]
    public class User:BaseModel.BaseModel
    {
        [ColumnName("CompanyId")]
        public int CompanyId {get;set;}
        [ColumnName("State")]
        public int State {get;set;}
        [ColumnName("UserType")]
        public int UserType {get;set;}
        [ColumnName("CreatorId")]
        public int CreatorId {get;set;}
        public int LastModifierId {get;set;}
        public DateTime LastLoginTime {get;set;}
        public DateTime CreateTime {get;set;}
        public DateTime LastModifyTime {get;set;}
        public string Account {get;set;}
        public string Password {get;set;}
        public string Email {get;set;}
        public string Mobile {get;set;}
        [StateValidate(1,5)]
        public string Name {get;set;}
        public string CompanyName {get;set;}
    }
}

