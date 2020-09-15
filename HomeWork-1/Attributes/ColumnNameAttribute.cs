using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_1.Attributes
{
    public class ColumnNameAttribute: MapDbAttribute
    {
        public ColumnNameAttribute(string columnName)
        {
            ColumnName = columnName;
        }
        public string ColumnName { get; set; }
    }
}
