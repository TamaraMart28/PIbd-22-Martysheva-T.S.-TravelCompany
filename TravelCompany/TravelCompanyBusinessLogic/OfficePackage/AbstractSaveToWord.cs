using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyBusinessLogic.OfficePackage.HelperEnums;
using TravelCompanyBusinessLogic.OfficePackage.HelperModels;


namespace TravelCompanyBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToWord
    {
        public void CreateDoc(WordInfo info)
        {
            CreateWord(info);

            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24", }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });

            foreach (var travel in info.Travels)
            {
                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)> { (travel.TravelName + " ", new WordTextProperties { Bold = true, Size = "24", }), (travel.Price.ToString(), new WordTextProperties { Size = "24", }) },
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationType = WordJustificationType.Both
                    }
                });
            }

            SaveWord(info);
        }

        public void CreateDocCompany(WordInfo info)
        {
            CreateWord(info);

            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24" }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });

            CreateTable(new List<string>() { "Название", "ФИО ответственного", "Дата создания" });

            foreach (var company in info.Companies)
            {
                AddRowTable(new List<string>() {
                    company.CompanyName,
                    company.NameResponsible,
                    company.DateCreate.ToShortDateString()
                });
            }

            SaveWord(info);
        }

        // Создание doc-файла
        protected abstract void CreateWord(WordInfo info);

        // Создание абзаца с текстом
        protected abstract void CreateParagraph(WordParagraph paragraph);

        // Сохранение файла
        protected abstract void SaveWord(WordInfo info);

        // Создание таблицы
        protected abstract void CreateTable(List<string> tableHeaderInfo);

        // Создание и заполнение строки
        protected abstract void AddRowTable(List<string> tableRowInfo);
    }
}
