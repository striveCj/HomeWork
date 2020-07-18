using HomeWork_1.Attributes;
using System;
namespace HomeWork_1.CodeGenerator
{
    public class Company:BaseModel.BaseModel
    {
        public int CreatorId {get;set;}
        public int LastModifierId {get;set;}
        public DateTime CreateTime {get;set;}
        public DateTime LastModifyTime {get;set;}
        [StateValidate(1, 5)]
        public string Name {get;set;}
    }
}

