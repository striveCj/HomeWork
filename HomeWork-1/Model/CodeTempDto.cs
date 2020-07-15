using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_1.Model
{
    /// <summary>
    /// 模板入参Dto
    /// </summary>
    public class CodeTempDto
    {
        public string TableName { get; set; }

        public List<DbFieldResultDto> DbFieldResultList { get; set; }
    }
}
