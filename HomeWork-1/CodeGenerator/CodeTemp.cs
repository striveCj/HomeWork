using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HomeWork_1.Model;

namespace HomeWork_1.CodeGenerator
{
    public class CodeTemp
    {
        public static string ExePath = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;

        public static string RootDic = Path.Combine(ExePath, "dbModelCode");
        /// <summary>
        /// 获取生成模板字符串
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public string GetTempString(CodeTempDto dto)
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine(@"using System;");

            sb.AppendLine(@"namespace HomeWork_1.CodeGenerator");
            sb.AppendLine(@"{");
            sb.AppendLine($@"    public class {dto.TableName}:BaseModel.BaseModel");
            sb.AppendLine(@"    {");
            foreach (var dbField in dto.DbFieldResultList)
            {
                if (dbField.Name.ToLower()=="id")
                {
                    continue;
                }
                sb.AppendLine($@"        public {dbField.Type} {dbField.Name} {{get;set;}}");
            }
            sb.AppendLine(@"    }");
            sb.AppendLine(@"}");
            return sb.ToString();
        }

        /// <summary>
        /// 代码生成
        /// </summary>
        /// <param name="dto"></param>
        public void CodeGenerator(CodeGeneratorDto dto)
        {
            if (Directory.Exists(RootDic) == false)
            {
                Directory.CreateDirectory(RootDic);
                Console.WriteLine($"所属文件夹生成完毕。");
            }

            //创建文件路径
            string outputFile = Path.Combine(RootDic, dto.TableName) + ".cs";
            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
            }
            //代码写入
            using (StreamWriter sw = new StreamWriter(outputFile))
            {
                string code = dto.TempStr;
                sw.WriteLine(code);
                sw.Flush();
                Console.WriteLine($"文件：{dto.TableName}代码填充完毕");
            }
        }
    }
}
