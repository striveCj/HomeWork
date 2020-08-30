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
        [ColumnName("LastModifierId")]
        public int LastModifierId {get;set;}
        [ColumnName("LastLoginTime")]
        public DateTime LastLoginTime {get;set;}
        [ColumnName("CreateTime")]
        public DateTime CreateTime {get;set;}
        [ColumnName("LastModifyTime")]
        public DateTime LastModifyTime {get;set;}
        [ColumnName("Account")]
        public string Account {get;set;}
        [ColumnName("Password")]
        public string Password {get;set;}
        [ColumnName("Email")]
        public string Email {get;set;}
        [ColumnName("Mobile")]
        public string Mobile {get;set;}
        [StateValidate(1,5)]
        public string Name {get;set;}
        public string CompanyName {get;set;}
    }
}

