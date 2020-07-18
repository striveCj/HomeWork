using HomeWork_1.Attributes;
using System;
namespace HomeWork_1.CodeGenerator
{
    [TableName("User")]
    public class User:BaseModel.BaseModel
    {
        public int CompanyId {get;set;}
        public int State {get;set;}
        public int UserType {get;set;}
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

