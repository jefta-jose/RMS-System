using System;
using System.IO;
using System.Reflection;
using api.Helpers;

namespace api.Email
{
    public abstract class BaseEmail<T> : IEmail
    {
        public string To { get; set; }
        public string Cc { get; set; } = "";
        public string Bcc { get; set; } = "";
        public string Body { get; set; } = "";
        public abstract string Subject { get; set; }

        protected abstract string TemplateFile { get; }

        protected void GenerateTemplate(T data)
        {
            var templateFile = GetTemplateFile();
            Body = ReplaceVariables(templateFile, data);
        }

        private string GetTemplateFile()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = Path.Combine(executableLocation, @"html_templates/", TemplateFile);
            var content = File.ReadAllText(filePath);
            return content;
        }

        private static string ReplaceVariables(string source , T data)
        {
            var template = source;

            foreach(var property in ReflectionHelper.GetProperties<T>())
            {
                var value = property.GetValue(data)?.ToString();
                string replacement = "{{" + property.Name + "}}";
                template = template.Replace(replacement, value);
            }

            return template;
        }
    }
}
