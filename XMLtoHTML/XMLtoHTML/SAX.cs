using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;

namespace XMLtoHTML
{
    class SAX : IXmlStrategy
    {
        public List<Students> search(Students s)
        {
            List<Students> result = new List<Students>();
            var xmlReader = new XmlTextReader(@"D:\лабы по проге\курс 2\XMLtoHTML\XMLtoHTML\XMLFile1.xml");
            while (xmlReader.Read())
            {
                if (xmlReader.HasAttributes)
                {
                    while (xmlReader.MoveToNextAttribute())
                    {
                        string Name = "";
                        string Faculty = "";
                        string Group = "";
                        string Subject = "";
                        string Mark = "";
                        if (xmlReader.Name.Equals("Name") && (xmlReader.Value.Equals(s.Name) || s.Name.Equals(String.Empty)))
                        {
                            Name = xmlReader.Value;
                            xmlReader.MoveToNextAttribute();

                            if (xmlReader.Name.Equals("Faculty") && (xmlReader.Value.Equals(s.Faculty) || s.Faculty.Equals(String.Empty)))
                            {
                                Faculty = xmlReader.Value;
                                xmlReader.MoveToNextAttribute();

                                if (xmlReader.Name.Equals("Group") && (xmlReader.Value.Equals(s.Group) || s.Group.Equals(String.Empty)))
                                {
                                    Group = xmlReader.Value;
                                    xmlReader.MoveToNextAttribute();

                                    if (xmlReader.Name.Equals("Subject") && (xmlReader.Value.Equals(s.Subject) || s.Subject.Equals(String.Empty)))
                                    {
                                        Subject = xmlReader.Value;
                                        xmlReader.MoveToNextAttribute();

                                        if (xmlReader.Name.Equals("Mark") && (xmlReader.Value.Equals(s.Mark) || s.Mark.Equals(String.Empty)))
                                        {
                                            Mark = xmlReader.Value;
                                        }
                                    }
                                }
                            }

                        }


                        if (Name != "" && Faculty != "" && Group != "" && Subject != "" && Mark != "")
                        {
                            Students student = new Students();
                            student.Name = Name;
                            student.Faculty = Faculty;
                            student.Group = Group;
                            student.Subject = Subject;
                            student.Mark = Mark;
                            result.Add(student);
                        }
                    }
                }
            }
            xmlReader.Close();
            return result;
        }
        
    }
}
